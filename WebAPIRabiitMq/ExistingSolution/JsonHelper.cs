using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Silmac.Core.Infrastructure
{
    public static class JsonHelper
    {
        public static async Task<string> SerializeAsync<T>(T item)
        {
            var stream = new MemoryStream();

            try
            {
                await JsonSerializer.SerializeAsync(stream, item, BuildJsonSerializerOptions());
                await stream.FlushAsync();

                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception)
            {
                // await stream.DisposeAsync();
                stream.Dispose();
                throw;
            }
        }

        public static async Task<T> DeserializeAsync<T>(string json)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            MemoryStream stream = new MemoryStream(byteArray);
            
            return await JsonSerializer.DeserializeAsync<T>(stream, BuildJsonSerializerOptions());
        }

        private static JsonSerializerOptions BuildJsonSerializerOptions()
        {
            return new JsonSerializerOptions();
        }
    }
}
