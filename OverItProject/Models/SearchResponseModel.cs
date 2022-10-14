using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OverItProject.Models
{
    public class Photo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }
        private string server;

        [JsonProperty("server")]
        public string Server
        {
            get { return server; }
            set
            {
                server = value;
                ImageUrl = $"https://live.staticflickr.com/{Server}/{Id}_{Secret}_c.jpg";
            }
        }

        [JsonProperty("farm")]
        public int Farm { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("ispublic")]
        public int Ispublic { get; set; }

        [JsonProperty("isfriend")]
        public int Isfriend { get; set; }

        [JsonProperty("isfamily")]
        public int Isfamily { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Photos
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("perpage")]
        public int Perpage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("photo")]
        public List<Photo> Photo { get; set; }
    }

    public class SearchResponseModel
    {
        [JsonProperty("photos")]
        public Photos Photos { get; set; }

        [JsonProperty("stat")]
        public string Stat { get; set; }
    }




}
