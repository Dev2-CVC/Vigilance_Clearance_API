namespace VigilanceClearance.Application.DTOs.Responses
{
    public class BaseResponseModel
    {
        public BaseResponseModel() {

            IsSuccess = true;
            Message = string.Empty;
        
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }

        public Object data { get; set; }
    }
}
