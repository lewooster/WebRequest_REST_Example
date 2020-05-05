using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace REST_API_Example
{
    public class WebRequestExample
    {


        public class User
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }

        public string WebRequestMethod(string path)
        {
            WebRequest request = WebRequest.Create(path);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();

            string responseFromServer;

            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
            }

            // Close the response.
            response.Close();
            return responseFromServer;
        }



        static void Main(string[] args)
        {
            WebRequestExample testExample = new WebRequestExample();
            var WebRequestOutput = testExample.WebRequestMethod("https://jsonplaceholder.typicode.com/posts");

            List<User> fetch = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(WebRequestOutput);
        }


    }
}
