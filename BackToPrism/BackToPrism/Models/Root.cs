using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackToPrism.Models
{
   
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Alias
        {
            [JsonProperty("sort-name")]
            public string SortName { get; set; }

            [JsonProperty("type-id")]
            public string TypeId { get; set; }
            public string name { get; set; }
            public string locale { get; set; }
            public string type { get; set; }
            public bool? primary { get; set; }

            [JsonProperty("begin-date")]
            public object BeginDate { get; set; }

            [JsonProperty("end-date")]
            public object EndDate { get; set; }
        }

        public class Area
        {
            public string id { get; set; }
            public string type { get; set; }

            [JsonProperty("type-id")]
            public string TypeId { get; set; }
            public string name { get; set; }

            [JsonProperty("sort-name")]
            public string SortName { get; set; }

            [JsonProperty("life-span")]
            public LifeSpan LifeSpan { get; set; }
        }

        public class Artist
        {
       // [PrimaryKey]
        public string id { get; set; }
        public string name { get; set; }        
       
    }

        public class BeginArea
        {
            public string id { get; set; }
            public string type { get; set; }

            [JsonProperty("type-id")]
            public string TypeId { get; set; }
            public string name { get; set; }

            [JsonProperty("sort-name")]
            public string SortName { get; set; }

            [JsonProperty("life-span")]
            public LifeSpan LifeSpan { get; set; }
        }

        public class LifeSpan
        {
            public object ended { get; set; }
            public string begin { get; set; }
            public string end { get; set; }
        }

        public class Root
        {
        [JsonIgnore]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Ignore]
        public Artist artistinfo
        {
            get
            {
                return artistinfo;
            }
            set
            {
                artistinfo = value;
                name = artistinfo.name;
                id = artistinfo.id;
            }
        }

        public string name { get; set; }
      
        public string id { get; set; }
        public DateTime created { get; set; }
            public int count { get; set; }
            public int offset { get; set; }
            public List<Artist> artists { get; set; }

        }

        public class Tag
        {
            public int count { get; set; }
            public string name { get; set; }
        }


    }

