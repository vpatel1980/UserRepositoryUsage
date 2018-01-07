using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryResultApp.Models
{
    public class UserDetails{
        public string UserName { get; set; }
        public string Location { get; set; }
        public string Avatar { get; set; }    
        public IEnumerable<Repository> Repositories { get; set; }
    }
}