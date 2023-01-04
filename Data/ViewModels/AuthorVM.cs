namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
