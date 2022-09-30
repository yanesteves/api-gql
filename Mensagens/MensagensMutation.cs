using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace API.Mensagens
{
    public class Friend : IFriend
    {
        public Friend(int id, string nome, string foto) 
        {
            Id = id;
            Nome = nome;
            Foto = foto;
        }

        public int Id {get;}
        public string Nome{get;}
        public string Foto{get;}
    }

    public interface IFriend {
        int Id {get;}
        string Nome{get;}
        string Foto{get;}
    }


    public class Mensagem : IMensagem
    {
        public Mensagem(int id, string texto) {
            Id = id;
            Texto = texto;
        }
        public int Id {get;}
        public string Texto {get;}
    }

     public interface IMensagem {
        int Id {get;}
        string Texto{get;}
    }


    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class MensagensMutation 
    {
        /*
        {
            friend {
                id
                nome
                foto
            }
            mensagem {
                textos
                hora
            }
        }

        
        */

        public Friend CriarChat(Mensagem input) 
        {
            var friend = new Friend(input.Id, "Ricardo", "");
            // await repository.enviaMensagem(input.Id, input.Texto);

            return friend;
        }
    }
}