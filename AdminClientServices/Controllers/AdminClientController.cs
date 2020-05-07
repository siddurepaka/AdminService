using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminClientServices.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminClientServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminClientController : ControllerBase
    {
        private readonly IAdminClientManager _manager;
        private readonly ILogger<AdminClientController> _logger;
        public AdminClientController(IAdminClientManager manager,ILogger<AdminClientController> logger)
        {
            _manager = manager;
            _logger = logger;
        }
        //Getting list of all sellers
        // <summary>
        // fetching all sellers  from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("GetAllSellers")]
        public IActionResult getSellers()
        {

            _logger.LogInformation("fetching  all subcategories");
            var seller = _manager.getAllSellers();
            return Ok(seller);
          //  throw new Exception("Exception while fetching all the sellers from the storage.");

        }

        //Getting list of all users
        // <summary>
        // fetching all sellers  from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult getUsers()
        {

            _logger.LogInformation("fetching  all sellers");
            var x = _manager.getAllUsers();
            return Ok(x);
            //throw new Exception("Exception while fetching all the subcategories from the storage.");

        }



    }
}