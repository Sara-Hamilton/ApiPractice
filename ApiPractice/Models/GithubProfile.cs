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
        public List<string> Repos { get; set; }

        public static List<GithubProfile> GetGithubProfile()
        {
            var client = new RestClient("https://developer.github.com/v3");
            var request = new RestRequest("users/Sara-Hamilton.json", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var profileList = JsonConvert.DeserializeObject<List<GithubProfile>>(jsonResponse["githubprofiles"].ToString());
            return profileList;
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
