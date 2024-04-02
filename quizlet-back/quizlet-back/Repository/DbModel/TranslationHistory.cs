using quizlet_back.Repository.DbModel.Base;

namespace quizlet_back.Repository.DbModel
{
    public class TranslationHistory : BaseEntity
    {
        public int CardId { get; set; }
        public int TranslationCardId { get; set; }


        public virtual Card CurrentCard { get; set; }
        public virtual Card OtherCard { get; set; }

        public TranslationHistory() { }

        public TranslationHistory(int cardId, int translationCardId)
        {
            CardId = cardId;
            TranslationCardId = translationCardId;
        }
    }
}
