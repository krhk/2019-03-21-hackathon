using System;

namespace KHK_OpenData.Lib
{
    public class ColumnCountAttribute : Attribute
    {
        public int Count { get; set; }

        public int HeaderLines { get; set; }
        public ColumnCountAttribute(int count)
        {
            Count = count;
        }
        public ColumnCountAttribute(int count, int headerLines) : this(count)
        {
            HeaderLines = headerLines;
        }
    }
}