using DevChallenge.Domain.Entities;
using DevChallenge.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevChallenge.Infra.Data.Mappings
{
    public class TelefoneMapping : EntityTypeConfiguration<Telefone>
    {
        public override void Map(EntityTypeBuilder<Telefone> entity)
        {
            entity.HasKey(e => e.Id);

            //entity.HasOne(x => x.Cliente)
            //    .WithOne(x => x.Telefone)
            //    .IsRequired();

            entity.Ignore(x => x.ValidationResult);
        }
    }
}
