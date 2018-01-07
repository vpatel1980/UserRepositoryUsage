using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryResultApp.Models.Json{
    public class ReposJSON    {
        public string name { get; set; }
        public string full_name { get; set; }
        public int stargazers_count { get; set; }
    }
}