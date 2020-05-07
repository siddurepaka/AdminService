using AdminClientServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClientServices.Repositories
{
    public interface IAdminClientRepository
    {
        List<Users> getAllUsers();
        List<Seller> getAllSellers();

    }
}
