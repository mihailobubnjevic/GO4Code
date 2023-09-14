using LibraryAPI.DTOs;

namespace LibraryAPI.Services
{
    public interface IBooksService
    {
        public Task<BooksGetDetailsResponse> CreateAsync(BooksCreateRequest book);
        public Task<IEnumerable<BooksGetDetailsResponse>> GetAsync();
        public Task<BooksGetDetailsResponse> GetDetailsAsync(int id);
        public Task<bool> DeleteAsync(int id);
    }
}
