namespace EXE201.SmartThrive.Domain.Models
{
    public class DecodedToken
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public long? Exp { get; set; }
    }
}
