namespace LearnHub.Application.Responses
{
    public class BaseCommandResponse
    {
        public object Data { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public int StatusCode { get; set; }

        public List<string>? Errors { get; set; }


        public void Success(object? data = null, string? message = null, List<string>? errors = null)
        {
            IsSuccess = true;
            Message = message ?? "Success...";
            Errors = errors;
            StatusCode = 0;
            Data = data;

        }


        public void Failure(object? data = null, string? message = null, List<string>? errors = null)
        {
            IsSuccess = false;
            Message = message ?? "Failure...";
            Errors = errors;
            StatusCode = -1;
            Data = data;
        }
    }
}
