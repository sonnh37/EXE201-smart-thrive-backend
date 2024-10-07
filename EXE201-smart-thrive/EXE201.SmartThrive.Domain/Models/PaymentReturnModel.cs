namespace EXE201.SmartThrive.Domain.Models
{
    public enum Status
    {
        PAID,
        PENDING,
        PROCESSING,
        CANCELLED
    }
    public class PaymentReturnModel
    {

        public Guid orderId { get; set; }
        public int code { get; set; }
        public string id { get; set; }
        public bool cancel { get; set; }
        public Status status { get; set; }
        public long orderCode { get; set; }

        public PaymentReturnModel() { }
    }


}
