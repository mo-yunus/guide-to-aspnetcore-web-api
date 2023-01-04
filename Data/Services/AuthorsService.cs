using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM book)
        {
            Author _author = new()
            {
                FullName = book.FullName,
                Gender = book.Gender,
                Age = book.Age,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName=n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }

        public List<Author> GetAllAuthors() => _context.Authors.ToList();

        public Author GetAuthorById(int authorId) => _context.Authors.FirstOrDefault(n => n.Id == authorId);

        public Author UpdateAuthorById(int authorId, AuthorVM author)
        {
            var _author = _context.Authors.FirstOrDefault(n => n.Id == authorId);
            if(_author != null)
            {
                _author.FullName = author.FullName;
                _author.Age = author.Age;
                _author.Gender = author.Gender;

                _context.SaveChanges();
            }

            return _author;
        }

        public void DeleteAuthorById(int authorId)
        {
            var _author = _context.Authors.FirstOrDefault(n => n.Id == authorId);
            if (_author != null)
            {
                _context.Authors.Remove(_author);
                _context.SaveChanges();
            }
        }
    }
}
