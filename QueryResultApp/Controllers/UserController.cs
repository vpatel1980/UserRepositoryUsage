using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QueryResultApp.Models;
using QueryResultApp.Service;

namespace QueryResultApp.Controllers
{
    public class UserController : Controller
    {
       private IUserRepoService userRepoService;
        public UserController(){
            userRepoService = new UserRepoService();
        }
        
        public ActionResult Index(){            
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user){
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrEmpty(user.Name)) {
                ModelState.AddModelError("", "Please enter user name.");
                return View();
            }
            try {
                var result = userRepoService.GetUserRepo(user);
                ViewData.Add("details", result);
            }
            catch (Exception ex)            {
                ModelState.AddModelError("", "Error loading data. " + ex.Message);
            } 
                return View();
            }
        }       
    }

