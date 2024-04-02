using Microsoft.AspNetCore.Mvc;
using quizlet_back.Repository.DbModel;
using quizlet_back.Service;

namespace quizlet_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController(ICardService repo) : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public Task<List<Card>> GetAllCards()
        {
            return repo.GetCardsAsync();
        }

        [HttpPost]
        [Route("create")]
        public Task<bool> AddCard([FromBody] Card card)
        {
            return repo.AddCardAsync(card);
        }

        [HttpPost]
        [Route("createRange")]
        public Task<bool> AddCardRange([FromBody] IList<Card> cards)
        {
            return repo.AddCardListAsync(cards);
        }

        [HttpPut]
        [Route("update")]
        public Task<bool> UpdateCard([FromBody] Card card) 
        {
            return repo.UpdateCardAsync(card);
        }

        [HttpPut]
        [Route("updateRange")]
        public Task<bool> UpdateRange([FromBody] IList<Card> cards)
        {
            return repo.UpdateCardListAsync(cards);
        }

        [HttpDelete]
        [Route("delete/{cardId}")]
        public Task<bool> DeleteCard(int cardId)
        {
            return repo.RemoveCardByIdAsync(cardId);
        }

        [HttpDelete]
        [Route("deleteRange")]
        public Task<bool> RemoveCardList([FromBody] IList<Card> cards)
        {
            return repo.RemoveCardListAsync(cards);
        }
    }
}
