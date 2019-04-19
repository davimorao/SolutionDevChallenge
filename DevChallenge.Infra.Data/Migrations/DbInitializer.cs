using DevChallenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Avivatec.Certa.Cadastro.Infra.Data.Migrations
{
    public class DbInitializer
    {
        public static void Initialize(CadastroContext context)
        {
            //context.Database.Migrate();
        }
    }
}
