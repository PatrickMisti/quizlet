using Microsoft.AspNetCore.Mvc;
using quizlet_back.Models;
using quizlet_back.Service;

namespace quizlet_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController(ITranslationService service): ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            throw new HttpRequestException("Not Implemented!");
        }

        [HttpGet]
        [Route("getAll/{from}/{till}")]
        public List<Translations> GetAll(int from, int till)
        {
            return [];
        }

        [HttpPost]
        [Route("create")]
        public Task Create()
        {
            return Response.CompleteAsync();
        }

        [HttpPut]
        [Route("update")]
        public void Update([FromBody] Translations translations)
        {

        }

        [HttpDelete]
        [Route("delete")]
        public void Delete([FromBody] Translations translations)
        {

        }

        [HttpDelete]
        [Route("deleteById/{id}")]
        public void DeleteAll(int id)
        {

        }
    }
}
