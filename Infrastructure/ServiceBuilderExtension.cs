using System.ComponentModel.Design;
using VigilanceClearance.Application.DropDownServices;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.AllegationOfMisconductExamined_9Interface;
using VigilanceClearance.Application.Interfaces.DropDownServiceInterface;
using VigilanceClearance.Application.Interfaces.IntegrityAgreedOrDoubtfuliNTERFACE;
using VigilanceClearance.Application.Interfaces.OfficerDetailsInterface;
using VigilanceClearance.Application.Interfaces.OfficerPostingDetailsInterface;
using VigilanceClearance.Application.Interfaces.VcPostServiceInterface;
using VigilanceClearance.Application.Interfaces.VcPostSubServiceInterface;
using VigilanceClearance.Application.Interfaces.VcReferenceInterface;
using VigilanceClearance.Application.Interfaces.VcReferenceReceivedForInterface;
using VigilanceClearance.Application.Services;
using VigilanceClearance.Application.Services.AllegationOfMisconductExamined_9Service;
using VigilanceClearance.Application.Services.IntegrityAgreedOrDoubtfulService;
using VigilanceClearance.Application.Services.OfficerDetailsService;
using VigilanceClearance.Application.Services.OfficerPostingDetailsService;
using VigilanceClearance.Application.Services.VcPostService;
using VigilanceClearance.Application.Services.VcPostSubService;
using VigilanceClearance.Application.Services.VcReferenceReceivedFor;
using VigilanceClearance.Application.Services.VcReferenceService;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.API.Infrastructure
{
    public static class ServiceBuilderExtension
    {
        public static void Dependencies(this IServiceCollection services)
        {
            services.AddScoped<VCDbContext>();

            services.AddScoped<IVcPostService, VcPostService>();

            services.AddScoped<IVcPostSubCategoryService, VcPostSubCategoryService>();
            services.AddScoped<IVcReference, VcReferenceService>();
            services.AddScoped<IVcReferenceReceivedFor, VcReferenceReceivedFor>();
            services.AddScoped<IDropdownService, DropDownService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IOfficerPostingDetails, OfficerPostingDetailsService>();
            services.AddScoped<IOfficerDetails, OfficerDetailsService>();
            services.AddScoped<IIntegrityAgreedOrDoubtful, IntegrityAgreedOrDoubtfulService>();
            services.AddScoped<IAllegationOfMisconductExamined_9, AllegationOfMisconductExamined_9Service>();
        }
    }
}
