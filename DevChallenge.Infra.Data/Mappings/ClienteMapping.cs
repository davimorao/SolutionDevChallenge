using DevChallenge.Domain.Entities;
using DevChallenge.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevChallenge.Infra.Data.Mappings
{
    public class ClienteMapping : EntityTypeConfiguration<Cliente>
    {
        public override void Map(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(x => x.Endereco)
                .WithOne(y => y.Cliente)
                .HasForeignKey<Endereco>(z => z.IdCliente);

            entity.HasOne(x => x.Telefone)
                .WithOne(y => y.Cliente)
                .HasForeignKey<Telefone>(z => z.IdCliente);

            entity.Ignore(x => x.ValidationResult);
        }
    }
}
