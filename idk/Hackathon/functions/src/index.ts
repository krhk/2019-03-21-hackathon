import * as functions from 'firebase-functions';
import * as admin from 'firebase-admin';
import * as parser from 'fast-xml-parser';

import axios from 'axios';

admin.initializeApp({
    storageBucket: 'hackathon-hk-2019.appspot.com'
});

const bucket = admin.storage().bucket();

interface Event {
    id: number;
    data: {
        [key: string]: any;
    };
}

interface LooseObject {
    [key: string]: any;
}

export const parseData = functions.pubsub.topic('parse-data-hk').onPublish(() => {
    console.log('Parse data');

    return parseDataAsync();
    // TODO Parser
});

async function parseDataAsync() {
    console.log('Downloading XML from Hradec servers...');
    const events_raw = await axios.get('http://www.hkregion.cz/bs/data_repository/export/events.php?nomenclatures=show');

    try {
        console.log('Checking if old file is present in Cloud Storage...');

        const file = await bucket.file('events.xml').download();

        if (file[0].toString() !== events_raw.data) {
            throw new Error('Diff');
        }
    } catch {
        console.log('Parsing new data...');
        const event_object = parser.parse(events_raw.data, {
            attributeNamePrefix: '',
            attrNodeName: '__attr',
            textNodeName: '__value',
            cdataTagName: '__cdata',
            ignoreAttributes: false,
            allowBooleanAttributes: true,
            parseAttributeValue: true,
            trimValues: false
        });
        const events = event_object.events.event;

        console.log(`Writing ${events.length} event records to Firestore...`);

        // tslint:disable-next-line: prefer-for-of
        for (let i = 0; i < events.length; i++) {
            const event: Event = {
                id: events[i].__attr.id,
                data: {
                    index: i,
                    superior_event: events[i].__attr.superior_event,
                    source_id: events[i].__attr.source_id,
                    source_event_id: events[i].__attr.source_event_id,
                    bsid: events[i].__attr.bsid
                }
            };

            const created = parseValueToUTCDateToTimestamp(events[i].__attr.create);
            if (created) event.data.created = created;

            const last_modified = parseValueToUTCDateToTimestamp(events[i].__attr.last_modif);
            if (last_modified) event.data.last_modified = last_modified;

            const top = events[i].__attr.top;
            if (top) event.data.top = top;

            const event_name = parseArrayedCDATA(events[i].name);
            if (event_name) event.data.name = event_name;

            const character = events[i].character;
            if (character) event.data.character = character;

            const event_anotation = parseArrayedCDATA(events[i].anotation);
            if (event_anotation) event.data.anotation = event_anotation;

            const event_description = parseArrayedCDATA(events[i].description);
            if (event_description) event.data.description = event_description;

            const event_url = parseArrayedCDATA(events[i].url);
            if (event_url) event.data.url = event_url;

            const place = events[i].place;
            const place_id = place.__attr.id;

            if (place) event.data.place = place_id;

            const organizer = parseOrganizer(events[i].organizer);
            if (organizer) event.data.organizer = organizer.id;

            const date_times = parseDateTimes(events[i].date_time);
            if (date_times) {
                event.data.date_times = date_times;
                event.data.date_time_start_first = date_times[0].start;
                event.data.date_time_start_last = date_times[date_times.length - 1].start;
            }

            const admission = undefinedIfEmpty(events[i].admission);
            if (admission) event.data.admission = admission;

            const event_type = events[i].events_type;
            if (event_type) event.data.type = event_type;

            const categories = parseCategories(events[i].thematic_category);
            if (categories.primary) event.data.primary_categories = categories.primary;
            if (categories.secondary) event.data.secondary_categories = categories.secondary;
            if (categories.groups) event.data.category_groups = categories.groups;

            const photos = parsePhotos(events[i].photogalery);
            if (photos) event.data.photos = photos;

            const attachments = parseAttachments(events[i].attachments);
            if (attachments) event.data.attachments = attachments;

            if (place) {
                const place_from_db = await admin
                    .firestore()
                    .collection('places')
                    .doc(String(place_id))
                    .get();

                if (!place_from_db.exists) {
                    const data: LooseObject = {};

                    const place_name = parseArrayedCDATA(place.name_place);
                    if (place_name) data.name = place_name;

                    const gps = parseGPS(place.gps);
                    if (gps) data.gps = new admin.firestore.GeoPoint(gps.latitude, gps.longtitude);

                    const uir = undefinedIfEmpty(place.obec_uir);
                    if (uir) data.uir = uir;

                    const street = undefinedIfEmpty(place.ulice);
                    if (street) data.street = street;

                    const care_of = undefinedIfEmpty(place.co);
                    if (care_of) data.care_of = care_of;

                    const number_of_descriptive = undefinedIfEmpty(place.cp);
                    if (number_of_descriptive) data.number_of_descriptive = number_of_descriptive;

                    const town = undefinedIfEmpty(place.obec);
                    if (town) data.town = town;

                    const postal_code = undefinedIfEmpty(place.psc);
                    if (postal_code) data.postal_code = postal_code;

                    await admin
                        .firestore()
                        .collection('places')
                        .doc(String(place_id))
                        .set(data);
                }
            }

            if (organizer) {
                const organizer_from_db = await admin
                    .firestore()
                    .collection('organizers')
                    .doc(String(organizer.id))
                    .get();

                if (!organizer_from_db.exists) {
                    await admin
                        .firestore()
                        .collection('organizers')
                        .doc(String(organizer.id))
                        .set({
                            name: organizer.name ? organizer.name : null,
                            ico: organizer.ico ? organizer.ico : null
                        });
                }
            }

            await admin
                .firestore()
                .collection('events')
                .doc(String(event.id))
                .set(event.data);
        }

        console.log(`Uploading raw XML file from Hradec to Cloud Storage...`);
        await bucket.file('events.xml').save(new Buffer(events_raw.data), {
            metadata: { contentType: 'text/xml' },
            private: true,
            resumable: false
        });
        console.log(`Done!`);
    }

    return 0;
} 

function parseArrayedCDATA(object: any): string | undefined {
    if (object instanceof Array) {
        for (const data of object) {
            if (data.__attr.lang === 'cs') return data.__cdata as string;
        }
    } else if (object !== undefined) {
        return object.__cdata as string;
    }

    return undefined;
}

function parseValueToUTCDateToTimestamp(date: string): admin.firestore.Timestamp | null {
    if (!date) return null;

    const splitted = date.split(' ');

    if (splitted[0] === '0000-00-00' && splitted[1] === '00:00:00') return null;

    return admin.firestore.Timestamp.fromDate(new Date(`${splitted[0]}T${splitted[1]}Z`));
}

function parseGPS(object: any) {
    return object ? { latitude: object[1].__value, longtitude: object[0].__value } : undefined;
}

function parseOrganizer(object: any) {
    return object.__attr.id === 0 && object.__attr.ico.length === 0 ? undefined : { id: object.__attr.id, ico: object.__attr.ico, name: object.__value };
}

function parseDateTimes(object: any) {
    if (!object) return undefined;

    if (object.start instanceof Array && object.start instanceof Array) {
        const date_times = [];

        for (let i = 0; i < object.start.length; i++) {
            const date_time = {
                start: parseValueToUTCDateToTimestamp(object.start[i].__value),
                end: parseValueToUTCDateToTimestamp(object.end[i].__value)
            };

            date_times.push(date_time);
        }

        return date_times;
    } else {
        const date_time = {
            start: parseValueToUTCDateToTimestamp(object.start.__value),
            end: parseValueToUTCDateToTimestamp(object.end.__value)
        };

        return [date_time];
    }
}

function parseCategories(object: any) {
    if (!object) return { primary: undefined, secondary: undefined, groups: undefined };

    let primary = undefined;
    let secondary = undefined;
    let groups = undefined;

    if (object.tcp) {
        if (object.tcp instanceof Array) {
            primary = [];

            for (const tcp of object.tcp) {
                primary.push(tcp.__value);
            }
        } else {
            primary = [object.tcp.__value];
        }
    }

    if (object.tcs) {
        if (object.tcs instanceof Array) {
            secondary = [];
            groups = [];

            let id = 0;
            let counter = 0;

            for (const tcs of object.tcs) {
                secondary.push(tcs.__value);

                if (id === tcs.__attr.id) {
                    counter++;
                } else {
                    groups.push(counter);
                    id = tcs.__attr.id;
                    counter = 0;
                }
            }

            groups.push(counter);
        } else {
            secondary = [object.tcs.__value];
            groups = [secondary.length];
        }
    }

    return { primary: primary, secondary: secondary, groups: groups };
}

function parsePhotos(object: any) {
    if (!object) return undefined;

    if (object.image_thumb instanceof Array && object.image_full instanceof Array) {
        const photos = [];

        for (const image_thumb of object.image_thumb) {
            const photo = getPhotoIDFromURL(image_thumb.__value);
            photos.push(photo);
        }

        return photos;
    } else {
        const photo = getPhotoIDFromURL(object.image_thumb.__value);

        return [photo];
    }
}

function parseAttachments(object: any) {
    if (!object) return undefined;

    if (object.attachment instanceof Array) {
        const files = [];

        for (const attachment of object.attachment) {
            const file = getFileIDFromURL(attachment.__value);
            files.push(file);
        }

        return files;
    } else {
        const file = getFileIDFromURL(object.attachment.__value);

        return [file];
    }
}

function getPhotoIDFromURL(value: string): string {
    const startIndex = value.indexOf('img=') + 4;
    const endIndex = value.indexOf('&amp;');

    const result = value.slice(startIndex, endIndex);

    return result;
}

function getFileIDFromURL(value: string): string {
    const startIndex = value.indexOf('file=') + 5;

    const result = value.slice(startIndex, value.length);

    return result;
}

function undefinedIfEmpty(value: string): string | undefined {
    return value ? (value.length === 0 ? undefined : value) : undefined;
}