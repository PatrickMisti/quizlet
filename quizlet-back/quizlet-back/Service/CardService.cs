using quizlet_back.Repository;
using quizlet_back.Repository.DbModel;

namespace quizlet_back.Service
{
    public class CardService(IRepository<Card> db): ICardService
    {
        public async Task<List<Card>> GetCardsAsync()
        {
            return (List<Card>) await db.GetAll();
        }

        public async Task<bool> AddCardAsync(Card card)
        {
            return await db.Create(card);
        }

        public async Task<bool> AddCardListAsync(IList<Card> cards)
        {
            await using var repo = new DbDatabase();
            await repo.Cards.AddRangeAsync(cards);
            return await repo.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCardAsync(Card card)
        {
            return await db.Update(card) > 0;
        }

        public async Task<bool> UpdateCardListAsync(IList<Card> cards)
        {
            await using var repo = new DbDatabase();
            repo.Cards.UpdateRange(cards);
            await Task.CompletedTask;
            return await repo.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveCardByIdAsync(int id)
        {
            return await db.DeleteById(id) > 0;
        }

        public async Task<bool> RemoveCardListAsync(IList<Card> cards)
        {
            await using var repo = new DbDatabase();
            repo.Cards.RemoveRange(cards);
            await Task.CompletedTask;
            return await repo.SaveChangesAsync() > 0;
        }
    }
}
