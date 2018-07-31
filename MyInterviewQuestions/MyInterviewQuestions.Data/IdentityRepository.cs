using MyInterviewQuestions.Core;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Data
{
    public class IdentityRepository : EfRepository<User>, IIdentityRepository
    {
        private readonly IDbContext _context;

        public IdentityRepository(IDbContext context) : base(context)
        {
            this._context = context;
        }

        #region IUserStore
        public async Task CreateAsync(User user)
        {
            await InsertAsync(user);
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await Table.SingleOrDefaultAsync(u => u.UserName == userName);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
        #endregion IUserStore


    }
}
