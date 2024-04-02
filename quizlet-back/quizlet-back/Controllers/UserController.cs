using Microsoft.AspNetCore.Mvc;
using quizlet_back.Repository.DbModel;
using quizlet_back.Service;

namespace quizlet_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService repo): ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public Task<IList<User>> GetAll()
        {
            return repo.GetAllAsync();
        }

        [HttpGet]
        [Route("getById/{userId}")]
        public Task<User?> GetById(int userId)
        {
            return repo.GetByIdAsync(userId);
        }

        [HttpPost]
        [Route("create")]
        public Task<bool> AddUser([FromBody] User user)
        {
            return repo.CreateUserAsync(user);
        }

        [HttpPut]
        [Route("update")]
        public Task<bool> UpdateUser([FromBody] User user)
        {
            return repo.UpdateUserAsync(user);
        }

        [HttpDelete]
        [Route("deleteById/{userId}")]
        public Task<bool> DeleteByIdUser(int userId)
        {
            return repo.DeleteUserByIdAsync(userId);
        }
    }
}
