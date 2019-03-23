using ExcelDataReader;
using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace KHK_OpenData.Lib.EntitySets
{
    public sealed class Excel<T> : EntitySet<T>, IEntitySet<T> where T : IExcelEntity, new()
    {
        private bool HasHeader { get; set; }

        private readonly List<PropertyInfo> properties;
        public Excel(IDataProvider dataProvider, bool hasHeader) : base(dataProvider)
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
            
            Entities = this.ToList();

        }
        public override List<T> ToList()
        {
            List<T> list = new List<T>();
            var stream = DataProvider.GetStream().Result;
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                if (HasHeader)
                {
                    var lines = 1;
                    int headerLines = typeof(T).GetCustomAttribute<ColumnCountAttribute>().HeaderLines;
                    if (headerLines != 0)
                    {
                        lines = headerLines;
                    }
                    for (int i = 0; i < lines; i++)
                    {
                        reader.Read();
                    }
                }

                while (reader.Read())
                {
                    T obj = new T();

                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        object value = reader.GetValue(propertyInfo.GetCustomAttribute<ColumnAttribute>().Index);
                        if (propertyInfo.PropertyType.GetInterface(typeof(IFromStringConvertable).ToString()) != null)
                        {
                            propertyInfo.SetValue(obj, ((IFromStringConvertable)(propertyInfo.GetValue(obj))).CreateFromString((string)value));
                        }
                        else if (value != null)
                        {
                            if (value is string) value = ((string)value).Trim();
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
