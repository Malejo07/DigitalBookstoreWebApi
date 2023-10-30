namespace DigitalBookstore.WebApi.DTOs
{
    public class UserBookDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Calification { get; set; }
        public string Review { get; set; }
    }
}
