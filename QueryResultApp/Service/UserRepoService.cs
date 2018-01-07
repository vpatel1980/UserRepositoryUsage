using QueryResultApp.Models;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;
using System.Text;
using System.Net;
using QueryResultApp.Models.Json;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;

namespace QueryResultApp.Service
{
    public interface IUserRepoService
    {
        UserDetails GetUserRepo(User user);
    }

    public class UserRepoService : IUserRepoService
    {
        public UserDetails GetUserRepo(User user)        {
            var userData = GetUserInfo(user);
            return MapToUserDetails(userData);
        }

        private UserDetails MapToUserDetails(UserJSON userInfo)        {

            return new UserDetails
            {
                UserName = userInfo.login,
                Location = userInfo.repos_url,
                Avatar = userInfo.avatar_url,
                Repositories = userInfo.Repos.Select(x =>{
                    return new Repository { Name = x.name, FullName = x.full_name, StargazersCount = x.stargazers_count };
                }
                )
            };
        }

        private UserJSON GetUserInfo(User user){        
            var userInfo = new UserJSON();
            try {
                using (var wc = new WebClient()) {
                    wc.Headers.Add("user-agent", "Only a test!");
                    var url = "https://api.github.com/users/" + user.Name;                    
                    var result = wc.DownloadString(url);
                    userInfo = JsonConvert.DeserializeObject<UserJSON>(result.ToString());
                    wc.Headers.Add("user-agent", "Only a test 1");
                    result = wc.DownloadString(userInfo.repos_url);
                    var repos = JsonConvert.DeserializeObject<List<ReposJSON>>(result.ToString());
                    userInfo.Repos = GetTopRepos(repos);
                };
            }
            catch(System.Exception ex){
                throw ex;
            }
            return userInfo;
                       
        }

        private List<ReposJSON> GetTopRepos(IList<ReposJSON> repos){
            var result = repos.OrderByDescending(x => x.stargazers_count).AsQueryable().Take(5);
            return result.ToList();
        }

    }

}
