using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminClientServices.Repository;
using AdminClientServices.Entities;
using AdminClientServices.Models;

namespace AdminClientServices.Manager
{
    public class ManagerRepository:IManager
    {
        public readonly AdminRepositoty _manager;

        public ManagerRepository(AdminRepositoty repo)
        {
            _manager = repo;
        }

        public async Task<bool> AddCategory(Category obj)
        {
            try
            {
                bool cat = await _manager.AddCategory(obj);
                if (cat==true)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<bool> AddSubcategory(SubCategory obj)
        {
            try
            {
                bool subcat = await _manager.AddSubcategory(obj);
                if(subcat==true)
                {
                    return true;
                }
                else
                {
                   return  false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            public string DeletCategory(int cid)
             {
            _manager.DeletCategory(cid);
            return "Category deleted";
            }

        public string DeletSubCategory(int subid)
        {
            _manager.DeletSubCategory(subid);
            return "subcategory deleted";
        }

        public  List<Category> GetAllCategories()
        {
            try
            {
                List<Category> cat = _manager.GetAllCategories().ToList();
                return cat;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<SubCategory> GetAllSubcategories()
        {
            try
            {
                List<SubCategory> subcat = _manager.GetAllSubcategories().ToList();
                if (subcat.Count != 0)
                    return subcat;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category getCategoryid(int cid)
        {
            try
            {
                Category cat= _manager.getCategoryid(cid);
                if (cat!= null)
                {
                    return cat;
                }
                else
                    return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public SubCategory getsubcategorybyid(int subid)
        {
            try
            {
                SubCategory subcat = _manager.getsubcategorybyid(subid);
                if (subcat != null)
                {
                    return subcat;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  async Task<bool> updatecategory(Category obj)
        {
            try
            {
                bool cat = await _manager.updatecategory(obj);
                if (cat==true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public  async Task<bool> updatesubcategory(SubCategory obj)
        {
            try
            {
                bool subcat = await _manager.updatesubcategory(obj);
                if (subcat == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
