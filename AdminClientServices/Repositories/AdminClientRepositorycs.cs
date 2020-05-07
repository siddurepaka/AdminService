using AdminClientServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClientServices.Repositories
{
    public class AdminClientRepositorycs : IAdminClientRepository
    {
        private readonly EmartDBContext _context;
        public AdminClientRepositorycs(EmartDBContext context)
        {
            _context = context;
        }
        public List<Seller> getAllSellers()
        {
                return _context.Seller.ToList();            
        }

        public List<Users> getAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
