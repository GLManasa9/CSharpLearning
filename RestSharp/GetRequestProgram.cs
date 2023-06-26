using NUnit.Framework;
using System;

namespace RestSharp {

    [TestFixture]
    public class Program
    {
        [Test]
        public void GetRequest()
        {
            // Create a RestClient instance
            var client = new RestClient("https://jsonplaceholder.typicode.com");

            // Create a RestRequest instance with the resource URL
            var request = new RestRequest("/posts", Method.Get);

            // Optionally, you can add parameters to the request
            request.AddParameter("id", 10);
            request.AddParameter("userId", 1);

            // Execute the request and get the response
            var response = client.Execute(request);

            // Check the response status code
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Process the response data
                var content = response.Content;
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed. Status code: " + response.StatusCode);
            }
        }
    }
}