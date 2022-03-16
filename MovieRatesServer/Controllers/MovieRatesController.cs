using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRatesBL.Models;

namespace MovieRatesServer.Controllers
{
    [Route("MovieRatesAPI")]
    [ApiController]
    public class MovieRatesController : Controller
    {
        #region Add connection to the db context using dependency injection
        MovieRatesDBContext context;
        public MovieRatesController(MovieRatesDBContext context)
        {
            this.context = context;
        }
        [Route("Login")]
        [HttpGet]
        public User Login([FromQuery] string userName,[FromQuery] string pass)
        {
            User user = context.GetUser(userName, pass);

            //Check user name and password
            if (user != null)
            {
                HttpContext.Session.SetObject("theUser", user);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return user;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
        [Route("Register")]
        [HttpPost]
        public bool Register([FromBody] User u)
        {
            if(HttpContext.Session.GetObject<User>("theUser") != null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
            try
            {
                context.Register(u);
            }
            catch
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
            HttpContext.Session.SetObject("theUser", u);
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return true;
        }
        [Route("EmailExist")]
        [HttpGet]
        public bool EmailExist([FromQuery] string email)
        {
            if (!context.EmailExist(email))
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return false;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return true;
        }
        [Route("UserNameExist")]
        [HttpGet]
        public bool UserNameExist([FromQuery] string userName)
        {
            if (!context.UserNameExist(userName))
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return false;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return true;
        }
        #endregion
    }
}
