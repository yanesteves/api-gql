using API.Models;

namespace API.Seeds
{
    public static class AlimentoSeed
    {

        public static List<Alimento> AlimentoSeeder { get; set; } = new List<Alimento>()
        {
            new Alimento{ Id = 1, Nome = "Maça", TipoID = (int)ETipoAlimento.Fruta},
            new Alimento{ Id = 2, Nome = "Alface", TipoID = (int)ETipoAlimento.Verdura}
        };
        public static List<TipoAlimento> TipoAlimentoSeeder { get; set; } = new List<TipoAlimento>()
        {
            new TipoAlimento{ Id = 1, Nome = ETipoAlimento.Fruta.ToString() },
            new TipoAlimento{ Id = 2, Nome = ETipoAlimento.Verdura.ToString() },
            new TipoAlimento{ Id = 3, Nome = ETipoAlimento.Legume.ToString() }
        };
    }
}