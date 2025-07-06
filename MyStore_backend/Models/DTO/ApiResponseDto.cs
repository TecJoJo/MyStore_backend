namespace MyStore_backend.Models.Dto
{
    public class ApiResponseDto<T>
    {
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }

    public class ApiResponseDto
    {
        public string Message { get; set; }
        public bool Success { get; set; } = true;
        public IEnumerable<string>? Errors { get; set; }
    }
}
