namespace API.GraphQL.Models
{
    public class AlimentoViewModel 
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public int TipoID {get;set;}
        public string? TipoAlimento {get;set;}
    }
}