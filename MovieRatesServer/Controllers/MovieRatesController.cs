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
        #endregion
    }
}
