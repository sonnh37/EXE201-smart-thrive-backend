namespace EXE201.SmartThrive.Domain.Models
{
    public class PayOsSettingModel
    {
        public static PayOsSettingModel Instance { get; set; }
        public string clientId { get; set; }
        public string apiKey { get; set; }
        public string checkSumKey { get; set; }
    }
}
