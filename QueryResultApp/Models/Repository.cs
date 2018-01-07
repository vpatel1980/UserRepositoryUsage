using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryResultApp.Models
{
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int StargazersCount { get; set; }
    }
}