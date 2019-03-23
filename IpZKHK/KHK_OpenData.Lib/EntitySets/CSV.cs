using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KHK_OpenData.Lib.EntitySets
{
    public sealed class CSV<T> : EntitySet<T>, IEntitySet<T> where T : ICSVEntity, new()
    {
        private bool HasHeader { get; set; }

        private readonly List<PropertyInfo> properties;
        public CSV(IDataProvider dataProvider, bool hasHeader) : base(dataProvider)
        {
            HasHeader = hasHeader;

            properties = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.GetCustomAttribute<ColumnAttribute>() != null)
                {
                    this.properties.Add(propertyInfo);
                }
            }
            Entities = ToList();
        }
        public override List<T> ToList()
        {
            List<T> list = new List<T>();
            Stream stream = DataProvider.GetStream().Result;
            using (var reader = new StreamReader(stream, DataProvider.GetEncoding()))
            {
                if (HasHeader)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    string[] values = line.Split(',');

                    if (line.Contains('"'))
                    {
                        List<string> temp = new List<string>();
                        for (int i = 0; i < values.Length; i++)
                        {
                            int findIndex;
                            bool open = true;
                            if (values[i].Contains('"'))
                            {
                                findIndex = i++;
                                while ((i < values.Length) && (open || !values[i].Contains('"')))
                                {
                                    values[findIndex] = values[findIndex] + "," + values[i];
                                    if (values[i].Contains('"'))
                                    {
                                        open = false;
                                        temp.Add(values[findIndex].Trim('"'));
                                    }
                                    i++;
                                }
                                open = true;
                            }
                            else
                            {
                                temp.Add(values[i]);
                            }
                        }
                        values = temp.ToArray();
                    }

                    T obj = new T();

                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        string value = values[propertyInfo.GetCustomAttribute<ColumnAttribute>().Index];
                        if (propertyInfo.PropertyType == typeof(string))
                            propertyInfo.SetValue(obj, value);
                        else if (propertyInfo.PropertyType.GetInterface(typeof(IFromStringConvertable).ToString()) != null)
                        {
                            propertyInfo.SetValue(obj, ((IFromStringConvertable)(propertyInfo.GetValue(obj))).CreateFromString(value));
                        }
                        else if (value != "")
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(value, propertyInfo.PropertyType));
                        }
                    }
                    list.Add(obj);
                }
            }
            stream.Dispose();
            return list;
        }
    }
}
