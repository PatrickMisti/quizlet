using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quizlet_back.Repository.DbModel.Base;

namespace quizlet_back.Configuration
{
    public class BaseConfiguration<T>: IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
        }

        public virtual void Configuration(EntityTypeBuilder<T> builder)
        {

        }
    }
}
