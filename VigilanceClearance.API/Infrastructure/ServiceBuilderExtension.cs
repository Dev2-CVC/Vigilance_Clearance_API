using System.ComponentModel.Design;
using VigilanceClearance.Application.DropDownServices;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Application.Interfaces.ActionContemplatedAgainstTheOfficer_12Interface;
using VigilanceClearance.Application.Interfaces.AllegationOfMisconductExamined_9Interface;
using VigilanceClearance.Application.Interfaces.CBI_DealingHandInterface;
using VigilanceClearance.Application.Interfaces.ComplaintWithVigilanceAnglePending_13Interface;
using VigilanceClearance.Application.Interfaces.DisciplinaryCriminalProceedings_11Interface;
using VigilanceClearance.Application.Interfaces.DropDownServiceInterface;
using VigilanceClearance.Application.Interfaces.IntegrityAgreedOrDoubtfuliNTERFACE;
using VigilanceClearance.Application.Interfaces.OfficerDetailsInterface;
using VigilanceClearance.Application.Interfaces.OfficerPostingDetailsInterface;
using VigilanceClearance.Application.Interfaces.UserInterface;
using VigilanceClearance.Application.Interfaces.VcPostServiceInterface;
using VigilanceClearance.Application.Interfaces.VcPostSubServiceInterface;
using VigilanceClearance.Application.Interfaces.VcReferenceInterface;
using VigilanceClearance.Application.Interfaces.VcReferenceReceivedForInterface;
using VigilanceClearance.Application.Services;
using VigilanceClearance.Application.Services.ActionContemplatedAgainstTheOfficer_12Service;
using VigilanceClearance.Application.Services.AllegationOfMisconductExamined_9Service;
using VigilanceClearance.Application.Services.CBI_DealingHandService;
using VigilanceClearance.Application.Services.ComplaintWithVigilanceAnglePending_13Service;
using VigilanceClearance.Application.Services.Coord2_DealingHand;
using VigilanceClearance.Application.Services.DisciplinaryCriminalProceedings_11Service;
using VigilanceClearance.Application.Services.IntegrityAgreedOrDoubtfulService;
using VigilanceClearance.Application.Services.OfficerDetailsService;
using VigilanceClearance.Application.Services.OfficerPostingDetailsService;
using VigilanceClearance.Application.Services.PunishmentAwarded_10Service;
using VigilanceClearance.Application.Services.UserService;
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
            services.AddScoped<ICBI_DealingHand, CBI_DealingHandService>();
            services.AddScoped<ICoord2_DealingHand, Coord2_DealingHandService>();
            services.AddScoped<IPunishmentAwarded_10, PunishmentAwarded_10Service>();
            services.AddScoped<IDisciplinaryCriminalProceedings_11, DisciplinaryCriminalProceedings_11Service>();
            services.AddScoped<IActionContemplatedAgainstTheOfficer_12, ActionContemplatedAgainstTheOfficer_12Service>();
            services.AddScoped<IComplaintWithVigilanceAnglePending, ComplaintWithVigilanceAnglePending_13Service>();

            services.AddScoped<IUserInterface, UserService>();
        }
    }
}
