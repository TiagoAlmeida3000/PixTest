namespace PixTest.Application.DTOs
{
    public class TransferDTO
    {
        public int Id { get;  set; }

        public decimal? Value { get;  set; }

        public string PixOriginKey { get;  set; }

        public string PixDestinationKey { get;  set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }
    }
}
