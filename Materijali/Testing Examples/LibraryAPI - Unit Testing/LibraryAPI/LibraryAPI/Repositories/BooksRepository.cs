using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class BooksRepository : IBooksRepository
    {

        public readonly AppDbContext _context;
        public readonly DbSet<Book> _collection;

        public BooksRepository(AppDbContext dbContext)
        {
            _context = dbContext;
            _collection = _context.Books;
        }

        public async Task<Book> Create(Book book)
        {
            book.CreatedAt = DateTime.Now;

            await _collection.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> Get(int id)
        {
            return await _collection.AsNoTracking().FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _collection.AsNoTracking().ToListAsync();
        }

        public async Task Delete(Book book)
        {
            _collection.Remove(book);
            await _context.SaveChangesAsync();
        }        
    }
}
