using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OBS.API.Exception;
using OBS.API.Model;
using OBS.API.Request;
using OBS.API.Uwp;

namespace OBS.API.Services
{
    public interface IAuthorService
    {
        Task<Author> Insert(AuthorRequestViewModel addRequest);
        Task<IEnumerable<Author>> GetAll();
        Task<Author> Get(long id);

        Task<Author> Update(long id, AuthorRequestViewModel updateRequest);
        Task<Author> Delete(long id);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _unitOfWork.AuthorRepository.FindAll().ToListAsync();
        }

        public async Task<Author> Get(long id)
        {
            return await _unitOfWork.AuthorRepository.FindByCondition(x => x.AuthorId == id).FirstOrDefaultAsync();
        }

        public async Task<Author> Insert(AuthorRequestViewModel addRequest)
        {

            var author = new Author()
            {
                FirstName = addRequest.FirstName,
                LastName = addRequest.LastName
            };
            
            await _unitOfWork.AuthorRepository.Create(author);

            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return author;
            }

            //return author;
            return null;
        }

        public async Task<Author> Update(long id, AuthorRequestViewModel updateRequest)
        {
            var author = await Get(id);

            if (author == null)
            {
                throw new ApiException("No data found!");
            }

            if (updateRequest.FirstName != null)
            {
                author.FirstName = updateRequest.FirstName;
            }

            if (updateRequest.LastName != null)
            {
                author.LastName = updateRequest.LastName;
            }
            
            _unitOfWork.AuthorRepository.Update(author);

            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return author;
            }

            throw new ApiException("Something went wrong for updating the data!");
        }

        public async Task<Author> Delete(long id)
        {
            var author = await Get(id);

            if (author == null)
            {
                throw new ApiException("No data found!");
            }
            
            _unitOfWork.AuthorRepository.Delete(author);

            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return author;
            }

            throw new ApiException("Something went wrong for deleting the data!");
        }
    }
}