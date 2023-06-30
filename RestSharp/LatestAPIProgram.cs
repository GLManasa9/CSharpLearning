using NUnit.Framework;
using RestSharp;
using System;
using System.Text.Json;

namespace BankProject.RestSharp
{
    [TestFixture]
    internal class LatestAPIProgram
    {
        [Test]
        public void getMethod() {
            var client = new RestClient("https://reqres.in/api/");
            var request = new RestRequest("users",Method.Get);
            request.AddParameter("page", 2);
            var response = client.Execute(request);
            //Console.WriteLine(response.Content);

            client = new RestClient("https://reqres.in/api/");
            request = new RestRequest("users");
            request.AddParameter("page", 2);//https://reqres.in/api/users?page=2
            response = client.ExecuteGet(request);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var data = JsonSerializer.Deserialize<ListOfUsers>(response.Content,options);
            Console.WriteLine($"{data.data[0]}");
            Console.WriteLine($"{data.Support}");

        }
    }

 
    class ListOfUsers
    {
        public long page { get; set; }
        public long per_page { get; set; }
        public long total { get; set; }
        public long total_pages { get; set; }
        public Datum[] data { get; set; }
        public Support Support { get; set; }
    }



    class Datum
    {
        public long Id { get; set; }
        public string email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Uri Avatar { get; set; }

        public override string ToString()
        {
            return "\nData Object:\nId:" + Id + "\nemail:" + email;
        }
    }

    class Support
    {
        public Uri Url { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return "\nSupport object:\nUrl:" + Url + "\nText:" + Text;
        }
    }
}
