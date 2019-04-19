using Microsoft.EntityFrameworkCore;

namespace DevChallenge.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        #region Methods
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
        #endregion
    }
}
