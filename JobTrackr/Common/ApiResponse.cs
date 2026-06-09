namespace JobTrackr.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        // static helpers
        public static ApiResponse<T> Ok(T data, string message = "Success")
        {
            // Return Success & success message & data
            // Not Errors coz no error occurs.
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data

            };
        }
        public static ApiResponse<T> Fail(string message, IEnumerable<string>? errors = null)
        {
            // Return Fail & and the message(Every function call fail cause different reason)
            // Errors give more detail of fail reason coz there could be multiple Error occurs.
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}