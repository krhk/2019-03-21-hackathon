using System.Collections.Generic;
namespace KHK_OpenData.Lib.Interfaces
{
    public interface IEntitySet<T> where T : IEntity
    {
        List<T> GetList();
        List<T> ToList();
    }
}
