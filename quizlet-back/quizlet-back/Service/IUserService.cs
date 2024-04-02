using quizlet_back.Repository.DbModel;

namespace quizlet_back.Service
{
    public interface IUserService
    {
        Task<IList<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);

        Task<bool> CreateUserAsync(User user);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> DeleteUserByIdAsync(int id);
    }
}
