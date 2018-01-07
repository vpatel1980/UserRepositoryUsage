using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryResultApp.Models.Json
{
    public class UserJSON
    {
        public int id { get; set; }
        public string login { get; set; }
        public string repos_url { get; set; }
        public string avatar_url { get; set; }
        public List<ReposJSON> Repos { get; set; }
    }
}