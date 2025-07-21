using VigilanceClearance.Application.DTOs.RequestModel;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Application.Interfaces.DropDownServiceInterface
{
    public interface IDropdownService
    {
        public Task<List<DropDownResponseModel>> VcPostGetAll();
        public Task<List<DropDownResponseModel>> VcReferenceGetAll();
        public Task<VcPostInsert> VcPostGetById(string Id);

        public Task<List<DropDownResponseModel>> VcPostSubCategoryGetById(string Id);
        public Task<List<DropDownResponseModel>> VcPostGetByReferenceNumber(string Refnumber);
        public Task<List<DropDownResponseModel>> MinistryNewGetBySection(string Section); 
        public Task<List<DropDownResponseModel>> GetMinistryByOrgCode(string orgcode);

        public Task<List<DropDownResponseModel>> GetAllService();
        public Task<List<DropDownResponseModel>> GetAllCadre();
        public Task<List<DropDownResponseModel>> GetOrgByMinCode(string Mincode);
    }
}
