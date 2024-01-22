using quizlet_back.Models;
using quizlet_back.Repository;

namespace quizlet_back.Service
{
    public class UserService(IRepository<User> db): IUserService
    {
        public async Task<IList<User>> GetAllAsync()
        {
            return (await db.GetAll()).ToList();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await db.GetById(id);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            return await db.Create(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await db.Update(user) > 0;
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            return await db.DeleteById(id) > 0;
        }
    }
}
