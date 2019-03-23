using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KHK_OpenData.Lib.Interfaces
{
    public interface IDataProvider
    {
        Task<Stream> GetStream();
        Encoding GetEncoding();
    }
}
