namespace MyStore_backend.Models.Dto
{
    public class LoginResponseDto
    {
        public string Message { get; set; }
        public string JwtToken { get; set; }
        public string Username { get; set; }
    }
}
