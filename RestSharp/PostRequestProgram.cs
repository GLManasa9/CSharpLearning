using NUnit.Framework;
using System;

namespace RestSharp
{

    [TestFixture]
    public class PostRequestProgram
    {
        [Test]
        public void PostRequest()
        {
            // Create a RestClient instance
            var client = new RestClient("https://jsonplaceholder.typicode.com");

            // Create a RestRequest instance with the resource URL
            var request = new RestRequest("/posts");

            // Optionally, you can add parameters to the request
            request.AddHeader("Content-Type", "application/json");


            request.AddJsonBody(new
            {
                userId = 2,
                id = 12,
                title = "Test Manasa 2",
                body = "Body"
            });


            // Execute the request and get the response
            var response = client.ExecutePost(request);

            // Check the response status code
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                // Process the response data
                var content = response.Content;
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed. Status code: {0}",response.StatusCode);
            }
        }
    }
}