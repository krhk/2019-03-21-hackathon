using System;

namespace KHK_OpenData.Lib
{
    public class ColumnAttribute : Attribute
    {
        public int Index { get; set; }
        public ColumnAttribute(int index)
        {
            this.Index = index;
        }
    }
}