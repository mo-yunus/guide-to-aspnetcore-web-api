namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        //Navigation properties
        public List<Book_Author> Book_Authors { get; set; }
    }
}
