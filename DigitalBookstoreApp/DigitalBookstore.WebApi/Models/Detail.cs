namespace DigitalBookstore.WebApi.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public int qualification { get; set; }
        public string reviews { get; set; }
        public Book Book { get; set; }
    }
}
