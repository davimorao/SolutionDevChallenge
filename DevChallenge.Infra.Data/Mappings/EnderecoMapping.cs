using DevChallenge.Domain.Entities;
using DevChallenge.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevChallenge.Infra.Data.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> entity)
        {
            entity.HasKey(e => e.Id);

            //entity.HasOne(x => x.Cliente)
            //    .WithOne(x => x.Endereco)
            //    .IsRequired();

            entity.Ignore(x => x.ValidationResult);
        }
    }
}