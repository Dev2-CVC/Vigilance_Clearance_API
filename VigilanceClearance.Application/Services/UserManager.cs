using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models;

namespace VigilanceClearance.Application.Services
{
    public class UserManager : IUserManager
    {
        private readonly VCDbContext _vCDbContext;
        public UserManager(VCDbContext vCDbContext)
        {
            _vCDbContext = vCDbContext;
        }
        public async Task<List<TblMasterVcUser>> GetAllUsers()
        {
            var result = _vCDbContext.TblMasterVcUsers.ToList();
            return result;
        }
    }
}
