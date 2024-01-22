using quizlet_back.Models;

namespace quizlet_back.Service
{
    public interface ICardService
    {
        Task<List<Card>> GetCardsAsync();

        Task<bool> AddCardAsync(Card card);

        Task<bool> AddCardListAsync(IList<Card> cards);

        Task<bool> UpdateCardAsync(Card card);

        Task<bool> UpdateCardListAsync(IList<Card> cards);

        Task<bool> RemoveCardByIdAsync(int id);

        Task<bool> RemoveCardListAsync(IList<Card> cards);

    }
}
