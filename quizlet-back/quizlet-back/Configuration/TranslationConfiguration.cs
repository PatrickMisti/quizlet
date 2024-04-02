using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quizlet_back.Repository.DbModel;

namespace quizlet_back.Configuration
{
    public class TranslationConfiguration : BaseConfiguration<TranslationHistory>
    {
        public override void Configuration(EntityTypeBuilder<TranslationHistory> builder)
        {
            base.Configuration(builder);
            builder.Property(p => p.CardId);
            builder.Property(p => p.TranslationCardId);
            
        }
    }
}
