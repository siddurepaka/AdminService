using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminClientServices.Extensions;
using AdminClientServices.Entities;
using AdminClientServices.Models;

namespace AdminClientServices.Repository
{
    public class AdminRepositoty : IAdminRepository
    {
        private readonly EmartDBContext _context;
        public AdminRepositoty(EmartDBContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCategory(Category obj)
        {
            try
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return true;
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
                _context.Add(obj);
                var cat = await _context.SaveChangesAsync();
                if (cat > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletCategory(int cid)
        {
            Category c = _context.Category.SingleOrDefault(e => e.Cid == cid);
            _context.Remove(c);
            _context.SaveChanges();
        }


        public void DeletSubCategory(int subid)
        {
            SubCategory c = _context.SubCategory.SingleOrDefault(e => e.Subid == subid);

            _context.Remove(c);
            _context.SaveChanges();

        }
        public List<Category> GetAllCategories()
        {
            List<Category> c = _context.Category.ToList();
            return c;
           
        }

        public List<Entities.SubCategory> GetAllSubcategories()
        {

            List<Entities.SubCategory> c = _context.SubCategory.ToList();
                return c;
            
           
           
        }

        public Category getCategoryid(int cid)
        {
            return _context.Category.SingleOrDefault(e=>e.Cid==cid);
           

        }

        public SubCategory getsubcategorybyid(int subid)
        {
            return _context.SubCategory.Find(subid);

        }

        public async Task<bool> updatecategory(Category obj)
        {
            try
            {
                _context.Category.Update(obj);
               await _context.SaveChangesAsync();
                    return true;
            
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public async Task<bool> updatesubcategory(Entities.SubCategory obj)
        {

            try
            {
                _context.SubCategory.Update(obj);
                 await _context.SaveChangesAsync();
                
                    return true;
               
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
    }
}
