using System.Collections.Generic;
using System.Linq;
using Api.DEV;

namespace Api.Repositories
{
    public interface IDevRepository
    {
        Developer GetDeveloper(int id);

    }
}
