using FreeCheck.DTO.Common;

namespace FreeCheck.Helper
{
    public static class ResponseHelper<TResultData>
    {
        public static ResponseResultData<TResultData?> ResOK(TResultData? dataInput)
        {
            return new ResponseResultData<TResultData?>
            {
                Data = dataInput,
                Message = "SUCCESS"
            };
        }

        public static ResponseResultData<TResultData?> ResFailed(List<Message>? messageDetails)
        {
            return new ResponseResultData<TResultData?>
            {
                Message = "FAILED",
                MessageDetail = messageDetails
            };
        }
    }

    public class ResponseResultData<ResultData>
    {
        public ResultData? Data { get; set; }
        public required string Message { get; set; }
        public List<Message>? MessageDetail { get; set; }
    }
}
