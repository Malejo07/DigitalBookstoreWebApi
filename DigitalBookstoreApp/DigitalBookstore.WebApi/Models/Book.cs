namespace DigitalBookstore.WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Yearpublication { get; set; }
        public User User { get; set; }
        //public int Calificacion { get; set; }
    }
}
