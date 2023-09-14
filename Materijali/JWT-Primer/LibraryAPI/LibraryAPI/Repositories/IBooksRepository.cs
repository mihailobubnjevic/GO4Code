using LibraryAPI.Models;

namespace LibraryAPI.Repositories
{
    public interface IBooksRepository
    {
        public Task<Book> Create(Book book);
        public Task<IEnumerable<Book>> GetAll();
        public Task<Book> Get(int id);
        public Task Delete(Book book);
    }
}
