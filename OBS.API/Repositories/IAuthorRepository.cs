using OBS.API.Contexts;
using OBS.API.Model;
using OBS.API.Uwp;

namespace OBS.API.Repositories
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        
    }

    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}