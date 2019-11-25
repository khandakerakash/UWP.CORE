namespace OBS.API.Model
{
    public class BookCategory
    {
        public long BookId { get; set; }
        public Book Book { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}