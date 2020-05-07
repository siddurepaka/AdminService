using AdminClientServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminClientServices.Manager
{
    public interface IAdminClientManager
    {
        List<Users> getAllUsers();
        List<Seller> getAllSellers();
    }
}
