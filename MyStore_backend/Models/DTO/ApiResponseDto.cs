namespace MyStore_backend.Models.DTO
{
    public class ApiResponseDto<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
