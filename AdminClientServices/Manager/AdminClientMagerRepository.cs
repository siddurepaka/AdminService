using AdminClientServices.Entities;
using AdminClientServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using AdminClientServices.Extensions;

namespace AdminClientServices.Manager
{
    public class AdminClientMagerRepository : IAdminClientManager
    {
        private readonly IAdminClientRepository _manager;
        public AdminClientMagerRepository(IAdminClientRepository manager)
        {
            _manager = manager;
        }
        public List<Seller> getAllSellers()
        {
            try
            {
                List<Seller> seller = _manager.getAllSellers().ToList();
                return seller;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public List<Users> getAllUsers()
        {
            try
            {
                List<Users> user = _manager.getAllUsers().ToList();
                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
