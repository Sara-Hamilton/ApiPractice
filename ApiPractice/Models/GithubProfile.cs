using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models
{
    public class GithubProfile
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Location { get; set; }
        public string Full_Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Html_Url { get; set; }
        public string Created_At { get; set; }
        public string Id { get; set; }
        public int Public_Repos { get; set; }

        public static GithubProfile GetGithubProfile()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/Sara-Hamilton", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("header", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", EnvironmentVariables.AccountUserAgent);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var profile = JsonConvert.DeserializeObject<GithubProfile>(jsonResponse.ToString());
            return profile;
        }

        public static List<GithubProfile> GetGithubRepos()
        {
            //var repoCount = GetGithubProfile().Public_Repos;
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users/Sara-Hamilton/repos?per_page=100&sort=updated", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddHeader("header", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", EnvironmentVariables.AccountUserAgent);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            //Console.WriteLine(repoCount);
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<GithubProfile>>(jsonResponse.ToString());
            return repoList;
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
