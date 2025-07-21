using VigilanceClearance.Application.Common.Helpers;
using VigilanceClearance.Application.DTOs.Responses;

namespace VigilanceClearance.Infrastructure.Common.Helpers
{
    public static class BaseResponseFactory
    {
       
        public static BaseResponseModel Success(object? data = null, string? message = null)
        {
            return new BaseResponseModel
            {
                IsSuccess = true,
                Message = message ?? ApplicationMessages.InsertSuccess,
                data = data,
                MessageType = ApplicationMessages.TypeSuccess
            };
        }
        public static BaseResponseModel InsertFailed()
        {
            return new BaseResponseModel
            {
                IsSuccess = false,
                Message = ApplicationMessages.RecordNotInserted,
                MessageType = ApplicationMessages.TypeError
            };
        }
        public static BaseResponseModel UpdateFailed()
        {
            return new BaseResponseModel
            {
                IsSuccess = false,
                Message = ApplicationMessages.RecordNotUpdated,
                MessageType = ApplicationMessages.TypeError
            };
        }
      
        public static BaseResponseModel Error(string? message = null, object? data = null)
        {
            return new BaseResponseModel
            {
                IsSuccess = false,
                Message = message ?? ApplicationMessages.UnexpectedError,
                data = data,
                MessageType = ApplicationMessages.TypeError
            };
        }

        public static BaseResponseModel NotFound()
        {
            return new BaseResponseModel
            {
                IsSuccess = false,
                Message = ApplicationMessages.RecordNotFound,
                data = null,
                MessageType = ApplicationMessages.TypeError
            };
        }

        public static BaseResponseModel Unauthorized()
        {
            return new BaseResponseModel
            {
                IsSuccess = false,
                Message = ApplicationMessages.UnauthorizedAccess,
                data = null,
                MessageType = ApplicationMessages.TypeError
            };
        }

        public static BaseResponseModel AlreadyExists()
        {
            return new BaseResponseModel
            {
                IsSuccess = false,
                Message = ApplicationMessages.AlreadyExists,
                data = null,
                MessageType = ApplicationMessages.TypeWarring
            };
            }
    }
}
