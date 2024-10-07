namespace EXE201.SmartThrive.Domain.Models
{
    public class VerifyOtpRequest
    {
        public string? Email { get; set; }
        public string? Otp { get; set; }
    }
}
