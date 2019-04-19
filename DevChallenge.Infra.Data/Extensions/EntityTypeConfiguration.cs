using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevChallenge.Infra.Data.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        #region Methods
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
        #endregion
    }
}
