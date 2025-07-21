using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Infrastructure.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {        
        public string UserProfile { get; set; }=string.Empty;
        
    }
}
