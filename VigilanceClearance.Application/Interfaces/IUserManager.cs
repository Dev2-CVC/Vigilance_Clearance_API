using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models;

namespace VigilanceClearance.Application.Interfaces
{
    public interface IUserManager
    {

        public Task<List<TblMasterVcUser>> GetAllUsers();
    }
}
