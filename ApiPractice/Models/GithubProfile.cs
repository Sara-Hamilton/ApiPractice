using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiPractice.Models
{
    public class GithubProfile
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Location { get; set; }
        //public List<string> Repos { get; set; }
        public string Full_Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Html_Url { get; set; }

        public static GithubProfile GetGithubProfile()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/Sara-Hamilton", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("header", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", "Sara-Hamilton");
            var response = new RestResponse();
       
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            Console.WriteLine(response);

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var profile = JsonConvert.DeserializeObject<GithubProfile>(jsonResponse.ToString());
          
            return profile;
         
        }

        public static List<GithubProfile> GetGithubRepos()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/Sara-Hamilton/repos", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("header", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", "Sara-Hamilton");
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            Console.WriteLine(response);

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<GithubProfile>>(jsonResponse.ToString());

            return repoList;

        }

        //public static List<GithubProfile> GetProfile()
        //{
        //    var client = new RestClient("https://api.github.com");
        //    var request = new RestRequest("users/Sara-Hamilton", Method.GET) { RequestFormat = DataFormat.Json };
        //    request.AddHeader("Accept", "application/vnd.github.v3+json");
        //    request.AddHeader("User-Agent", "Sara-Hamilton");
        //    var response = new RestResponse();
        //    var content = response.Content;
        //    //var response = new RestResponse();


        //    Task.Run(async () =>
        //    {
        //        response = await GetResponseContentAsync(client, request) as RestResponse;
        //    }).Wait();
        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
        //    var profileList = JsonConvert.DeserializeObject<List<GithubProfile>>(jsonResponse["githubProfiles"].ToString());
        //    return profileList;

        //}

        public void Send()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/Sara-Hamilton", Method.POST); request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("User Agent", "Sara Hamilton");
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("User Agent", "Sara Hamilton");
            //request.AddParameter("Name", Name);
            //request.AddParameter("Url", Url);
            //request.AddParameter("Body", Body);
            //client.Authenticator = new HttpBasicAuthenticator("{{Account SID}}", "{{Auth Token}}");
            client.ExecuteAsync(request, response => {
                Console.WriteLine(response.Content);
            });
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
