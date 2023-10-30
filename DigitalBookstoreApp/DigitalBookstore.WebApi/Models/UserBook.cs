namespace DigitalBookstore.WebApi.Models
{
    public class UserBook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Calification { get; set; }
        public string Review { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }   
    }
}
