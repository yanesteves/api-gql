using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Alimento {
        public int Id{get;set;}
        public string Nome{get;set;}
        [ForeignKey("TipoAlimento")]
        public int TipoID {get;set;}

    }  
}