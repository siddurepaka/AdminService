using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using AdminClientServices.Entities;
using AdminClientServices.Models;
using AdminClientServices.Manager;

namespace AdminClientServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
       
        private readonly IManager _manager;
        private readonly ILogger<AdminController> _logger;


        public AdminController(IManager manager,ILogger<AdminController> logger)//Constructor
        {
            _logger = logger;
            _manager = manager;
        }
        //Adding Category
        // <summary>
        // To Add a new category to a table in EmartDB database
        // </summary>
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> Addcategory(Category obj)
        {
            
                await _manager.AddCategory(obj);
                return Ok("Category Added");
            throw new Exception("Exception while adding  the categories to the storage.");

        }

        //Adding Subcategory
        // <summary>
        // To Add a new subcategory to a table in EmartDB database
        // </summary>
        [HttpPost]
        [Route("AddSubCategory")]
        public async Task<IActionResult> Addsubcategory(SubCategory obj)
        {
                await _manager.AddSubcategory(obj);
                return Ok("SubCategory Added");
            throw new Exception("Exception while adding the subcategory  to the storage.");


        }
        //Fetching Category by id
        // <summary>
        // fetching a category from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("getcategory/{cid}")]
        public IActionResult getcategory(int cid)
        {
            //try and catch block using Global Exception handling 
                //implementing logging
                _logger.LogInformation("fetching categories by id");
                return Ok(_manager.getCategoryid(cid));
            throw new Exception("Exception while fetching  the categories from the storage.");


            ;        }
        //fetching sub category by id
        // <summary>
        // fetching a subcategory from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("getsubcategory/{subid}")]
        public IActionResult getsubcategory(int subid)
        {
            _logger.LogInformation("fetching   subcategories by id: ");
            return Ok(_manager.getsubcategorybyid(subid));
            throw new Exception("Exception while fetching  the subcategories from the storage.");

        }
        //Getting all the Category
        // <summary>
        // fetching all category from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("GetAllCategory")]
        public IActionResult Get()
        {
           

                var category = _manager.GetAllCategories();
                _logger.LogInformation($"Returning {category.Count} categories.");
                return Ok(category);
                throw new Exception("Exception while fetching all the subcategories from the storage.");


        }
        //Getting list of all the sub categories
        // <summary>
        // fetching all subcategory from the table in EmartDB database
        // </summary>
        [HttpGet]
        [Route("GetAllSubcategory")]
        public IActionResult GetSubcategories()
        {

            _logger.LogInformation("fetching  all subcategories");
            var subcategory =_manager.GetAllSubcategories();
            return Ok(subcategory);
            throw new Exception("Exception while fetching all the subcategories from the storage.");

        }
        //Deleting category
        // <summary>
        // Deleting  a category from the table in EmartDB database
        // </summary>
        [HttpDelete]
        [Route("DeleteCategory/{cid}")]
        public IActionResult DeleteCategory(int cid)
        {
            _manager.DeletCategory(cid);
            return Ok("Category Deleted");
            throw new Exception("Exception while deleting a category from the storage.");
        }

        //deleting sub category
        // <summary>
        // Deleting  a subcategory from the table in EmartDB database
        // </summary>
        [HttpDelete]
        [Route("DeleteSubCategory/{subid}")]
        public IActionResult DeleteSubCategory(int subid)
        {
            _manager.DeletSubCategory(subid);
            return Ok("subcategory deleted");
            throw new Exception("Exception while deleting a subcategories from the storage.");


        }
        //updating category
        // <summary>
        // updating a category from the table in EmartDB database
        // </summary>

        [HttpPut]
        [Route("updatecategory")]
        public async Task<IActionResult> updatecategory(Category obj)
        {
           
                await _manager.updatecategory(obj);
                return Ok("updated");
            throw new Exception("Exception while updating a category t0 the storage.");
        }
        //updating the subcategory
        // <summary>
        // updating  a subcategory from the table in EmartDB database
        // </summary>
        [HttpPut]
        [Route("updatesubcategory")]
        public async Task<IActionResult> updatesubcategory(SubCategory obj)
        {
            
              await  _manager.updatesubcategory(obj);
                return Ok("updated");
            throw new Exception("Exception while updating subcategory to the storage.");




        }

    }
}