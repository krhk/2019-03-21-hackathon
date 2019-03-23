using KHK_OpenData.Lib.Interfaces;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KHK_OpenData.Lib.Models
{
    public class HttpDataProvider : IDataProvider
    {
        public Uri Uri { get; set; }
        private Encoding Encoding { get; set; }

        public HttpDataProvider(Uri uri) : this(uri, Encoding.UTF8)
        {
        }
        public HttpDataProvider(Uri uri, Encoding encoding)
        {
            this.Uri = uri;
            this.Encoding = encoding;
        }


        public async Task<Stream> GetStream()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("IPZHK", "1.0.0"));
            HttpContent content = httpClient.GetAsync(Uri).Result.Content;
            httpClient.Dispose();
            Byte[] bytes = await content.ReadAsByteArrayAsync();
            content.Dispose();
            return new MemoryStream(bytes);
        }

        public Encoding GetEncoding()
        {
            return this.Encoding;
        }
    }
}