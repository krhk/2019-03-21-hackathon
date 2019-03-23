<?php
$xml = simplexml_load_string(file_get_contents("http://www.hkregion.cz/bs/data_repository/export/events.php?nomenclatures=show"));
#var_dump($xml->nomenclatures);
#ar_dump( $xml->nomenclatures->character);
#print_r($xml->nomenclatures->children()[0]->getName());


$language = "cs"; #cs, en, de, fr, ru, pl, nl, sp, it
$languages = ["cs", "en", "de", "fr", "ru", "pl", "nl", "sp", "it"];

function ConvertedEventCategoryInLanguage($xmlNomenclature, $language)
{
    $array = [];
    for($i = 0; $i < count($xmlNomenclature->data); $i++)
    {
        if($xmlNomenclature->data[$i]->attributes()[1] == $language)
            $array[(int)$xmlNomenclature->data[$i]->attributes()[0]] = (string)$xmlNomenclature->data[$i];
    }
    return $array;
}
function ConvertedEventCategory($xmlNomenclature)
{
    global $languages;
    $output = [];
    foreach($languages as $language)
    {
        $output[$language] = ConvertedEventCategoryInLanguage($xmlNomenclature, $language);
    }

    return $output;
}



#Categories
$character = ConvertedEventCategory($xml->nomenclatures->character);
$events_type = ConvertedEventCategory($xml->nomenclatures->events_type);
$events_subtype = ConvertedEventCategory($xml->nomenclatures->events_subtype);
$event_for = ConvertedEventCategory($xml->nomenclatures->event_for);
$thematic_category = ConvertedEventCategory($xml->nomenclatures->thematic_category);



#var_dump($xml->nomenclatures->character->data[0]);
#echo $xml->nomenclatures->character->data[0]->attributes()[1];
#echo $xml->nomenclatures->character->data[1];
#echo count($xml->nomenclatures->character->data);

#var_dump($xml->children()[2])



class Event
{
    # Internal
    public $id;
    public $created;
    public $lastModified;

    # Categories
    public $name;
    public $character;
    public $anotation;
    public $description;
    public $url;
    public $place;
    public $organizer;
    public $datetimeStart;
    public $datetimeEnd;
    public $admission;
    public $events_type;
    public $photogallery;

    function __construct($xmlEvent)
    {
        $this->id = (int)$xmlEvent->attributes()[0];
        $this->created = (string)$xmlEvent->attributes()[5];
        $this->lastModified = (string)$xmlEvent->attributes()[6];

        $this->name = GetAtribute($xmlEvent->name);
        $this->character = (int)$xmlEvent->character;
        $this->anotation = GetAtribute($xmlEvent->anotation);
        $this->description = GetAtribute($xmlEvent->description);
        $this->url = (string)$xmlEvent->url;
        $this->place = new Place($xmlEvent->place);
        $this->organizer = new Organizer($xmlEvent->organizer);
        $this->datetimeStart = (string)$xmlEvent->date_time[0];
        $this->datetimeEnd = (string)$xmlEvent->date_time[1];
        $this->admission = (string)$xmlEvent->admission;
        $this->events_type = (int)$xmlEvent->events_type;

    }
}

class Place
{
    public $id;
    public $name;
    public $gpsX;
    public $gpsY;
    public $obec_uir;
    public $ulice;
    public $co;
    public $cp;
    public $obec;
    public $psc;

    function __construct($xmlPlace)
    {
        $this->id = (int)$xmlPlace->attributes()[0];
        $this->name = GetAtribute($xmlPlace->name_place);
        $this->gpsX = (float)$xmlPlace->gps[0];
        $this->gpsY = (float)$xmlPlace->gps[1];
        $this->obec_uir = (string)$xmlPlace->obec_uir;
        $this->ulice = (string)$xmlPlace->ulice;
        $this->co = (string)$xmlPlace->co;
        $this->cp = (string)$xmlPlace->cp;
        $this->obec = (string)$xmlPlace->obec;
        $this->psc = (string)$xmlPlace->psc;
    }
}

class Organizer
{
    public $id;
    public $ico;

    function __construct($xmlOrganizer)
    {
        $this->id = (int)$xmlOrganizer->attributes()[0];
        $this->ico = (string)$xmlOrganizer->attributes()[1];
    }
}

function GetAtribute($xmlAtribute)
{
    $output = [];
    for($i = 0; $i < count($xmlAtribute); $i++)
         $output[(string)$xmlAtribute[$i]->attributes()[0]] = (string)$xmlAtribute[$i];
     return $output;
}

# Populate events list
$events = [];
for($i=2; $i < count($xml->children()); $i++)
{
    array_push($events, new Event($xml->children()[$i]));
}

function GetEventsWithProperty($fromArray, $propertyName, $value)
{
    $return = [];
    foreach($fromArray as $oneEvent)
    {
        if($oneEvent->$propertyName == $value)
        {
            array_push($return, $oneEvent);
        }
    }
    return $return;
}

#var_dump(GetEventsWithProperty($events, "name[cs]", 'Světový den vody / Voda voděnka'));
?>