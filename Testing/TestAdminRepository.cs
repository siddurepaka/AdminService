using System;
using System.Collections.Generic;
using AdminClientServices.Repository;
using Moq;
using NUnit.Framework;
using AdminClientServices.Entities;
using System.Threading.Tasks;


namespace TestAdminRepository
{
    [TestFixture]
    class TestAdminRepository
    {
       
        
        AdminRepositoty _repo;
        [SetUp]
        public void setup()
        {
            _repo = new AdminRepositoty(new EmartDBContext());

        }
        [TearDown]
        public void Teardown()
        {
            _repo = null;
        }


        //Testing Add Category Success
        [Test]
        [Description("get category")]
        [TestCase(203,"electronics","electric gadgets")]
        [TestCase(204, "clothings", "Wholesale")]
        [TestCase(205, "HomeNeeds", "All home needies")]
        public async Task TestAddCategory_success(int cid,string cname,string cdetails)
        {
            try
            {
                await _repo.AddCategory(new Category()
                {
                     Cid= cid,
                    Cname = cname,
                     Cdetails = cdetails,
                });
                var x = _repo.getCategoryid(cid);
                Assert.NotNull(x);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
            

        }






        [Test]
        [Description("Add Subcategory")]
        [TestCase(94,2,"def","pens",4)]
        [TestCase(95,1, "lkj", "cello", 5)]
        [TestCase(96,1, "dsa", "butterflow", 3)]
        public async Task TestAddsubcategory(int Subid,int Cid,string Sdetails,string Subname,int Gst)
        {
            try
            {
                await _repo.AddSubcategory(new SubCategory()
                {
                      Subid= Subid,
                      Cid= Cid,
                     Sdetails = Sdetails,
                    Subname= Subname,
                     Gst= Gst,


                });
                var result = _repo.getsubcategorybyid(89);
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        [Test]
        [Description("Testing Getby id for category")]
        [TestCase(2)]
        [TestCase(1)]
        public void TestGetbycategory_success(int cid)
        {
            try
            {
                Category result = _repo.getCategoryid(cid);
                Assert.IsNotNull(result,"test passed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Failure Test Cases
        [Test]
        [TestCase(105)]
        [TestCase(999)]
        public void TestGetbycategory_Failure(int cid)
        {

            Category result = _repo.getCategoryid(cid);
            Assert.IsNull(result);
        }



        //Success TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(1)]
        [TestCase(2)]
        public void TestGetbysubcategory_success(int subid)
        {
            try
            {
                var result = _repo.getsubcategorybyid(subid);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Failure TestCase
        [Test]
        [Description("Testing get by id for  Subcategory")]
        [TestCase(108)]
        [TestCase(171)]
        public void TestGetbysubcategory_Failure(int subid)
        {
            try
            {
                var result = _repo.getsubcategorybyid(subid);
                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }

        //Testing Delete Category
        [Test]
        [Description("Testing delete by id for  category")]
        [TestCase(203)]
        [TestCase(204)]
        public void TestDelete_Success(int cid)
        {
            try
            {
                _repo.DeletCategory(cid);
                var result= _repo.getCategoryid(cid);
                Assert.IsNull(result);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
        //Testing Delete subCategory
        [Test]
        [Description("Testing delete by id for  subcategory")]
        [TestCase(95)]
        [TestCase(96)]
        public void TestDeleteSubcategory_Success(int subid)
        {
            try
            {
                _repo.DeletSubCategory(subid);
                var result = _repo.getsubcategorybyid(subid);
                Assert.IsNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [Test]
        [Description("Getcategorylist")]
        public void TestGetcategorylist()
        {
            try
            {
                var result = _repo.GetAllCategories();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [Test]

        [Description("Getgetsubcategorylist")]
        public void TestGetsubcategorylist_success()
        {
            try
            {
                var result = _repo.GetAllSubcategories();
                Assert.NotNull(result);
                Assert.Greater(result.Count, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        // [TestCase)]  //setup teardown order
        [Test]
        [Description("to test the mock data")]
        public void AddMockCategory()
        {
            try
            {
                var cId = 113;
                var cName = "books";
                var CDetail = "all books";
                var cat = new Category {   Cid = cId,  Cname= cName,  Cdetails = CDetail };
                var mock = new Mock<IAdminRepository>();
                mock.Setup(x => x.AddCategory(cat));
                var result = mock.Setup(x => x.getCategoryid(cat.Cid));
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }


        }
        //Testing Update category
        [Test]
        [Description("update Category")]
        public async Task UpdateCategory()
        {
            try
            {
                Category cat = _repo.getCategoryid(2);
                cat.Cdetails = "Buy  best";
                await _repo.updatecategory(cat);
                Category cat1 = _repo.getCategoryid(2);
                Assert.AreSame(cat, cat1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }

        }
        //Testing update subcategory
        [Test]
        [TestCase(10, 2, "def", "pen", 4)]
        [TestCase(11, 1, "lkj", "cellopens", 5)]
        [TestCase(12, 1, "dsa", "butter", 3)]
        [Description("update subCategory")]
        public async Task UpdateSubCategory(int Subid, int Cid, string Sdetails, string Subname, int Gst)
        {
            try
            {
                SubCategory subcat = _repo.getsubcategorybyid(Subid);
                subcat.Subid = Subid;
                subcat.Subname = Subname;
                subcat.Sdetails = Sdetails;
                subcat.Gst = Gst;
                await _repo.updatesubcategory(subcat);
                SubCategory subcat1 = _repo.getsubcategorybyid(Subid);
               Assert.AreSame(subcat, subcat1);
               

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
       



    }
}
