using AutoMapper;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BooksGetDetailsResponse> CreateAsync(BooksCreateRequest book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            var result = await _repository.Create(bookEntity);
            
            return _mapper.Map<BooksGetDetailsResponse>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = await _repository.Get(id);
            if(exists == null)
            {
                return false;
            }

            await _repository.Delete(exists);

            return true;
        }

        public async Task<IEnumerable<BooksGetDetailsResponse>> GetAsync()
        {
            var books = await _repository.GetAll();
            return _mapper.Map<IEnumerable<BooksGetDetailsResponse>>(books);
        }

        public async Task<BooksGetDetailsResponse> GetDetailsAsync(int id)
        {
            var book = await _repository.Get(id);
            if (book == null)
                return null;

            return _mapper.Map<BooksGetDetailsResponse>(book);
        }
    }
}
