using System.Threading.Tasks;
using OBS.API.Contexts;
using OBS.API.Repositories;

namespace OBS.API.Uwp
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        Task<int> CompleteAsync();
        int Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IAuthorRepository _authorRepository;

        public IAuthorRepository AuthorRepository =>
            _authorRepository ?? (_authorRepository = new AuthorRepository(_context));
        
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose() => _context.Dispose();
    }
}