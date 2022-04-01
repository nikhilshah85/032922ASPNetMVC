using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace consumeWebAPI.Models
{
    public class CommentsModel
    {
        #region properties
        public int Postid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Body { get; set; }
        #endregion

        public List<CommentsModel> GetCommentslist()
        {
            string url = "https://jsonplaceholder.typicode.com/comments";
            HttpClient client = new HttpClient();

            //remove all the default setting on client browser for data,and declare a new setting which will call data
            //in json format

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            
            var callService = client.GetAsync(url);
            List<CommentsModel> data = new List<CommentsModel>();
            var response = callService.Result;

            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsAsync<List<CommentsModel>>();
                read.Wait();
                data = read.Result;
            }
            return data;


        }
    }
}
