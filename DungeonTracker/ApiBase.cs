using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace DungeonTracker
{
    public static class ApiBase
    {
        /// <summary>
        /// Downloads a JsonString from a url.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <returns>JsonString from url.</returns>
        public static string DownloadJsonString(string url)
        {
            string jsonString = string.Empty;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.GetEncoding("utf-8");
                    jsonString = wc.DownloadString(url);
                }
            }
            catch (WebException exception)
            {
                if (exception.Response != null)
                {
                    var responseStream = exception.Response.GetResponseStream();

                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            string responseText = reader.ReadToEnd();
                            var c = responseText.ToString().Remove(0, 13);
                            var d = c.Remove(c.IndexOf("\""));
                            throw new Exception(d);
                        }
                    }
                }
            }

            return jsonString;
        }

        /// <summary>
        /// Deserializes a object.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="url">Endpoint url.</param>
        /// <returns>Converted object.</returns>
        public static T DeserializeObject<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(DownloadJsonString(url));
        }
    }
}
