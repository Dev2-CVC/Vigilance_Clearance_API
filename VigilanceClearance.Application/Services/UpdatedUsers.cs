using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models;

namespace VigilanceClearance.Application.Services
{
    public class UpdatedUsers : IUserManager
    {
        private readonly VCDbContext _vCDbContext;
        public UpdatedUsers(VCDbContext vCDbContext)
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
