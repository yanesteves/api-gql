using Api.Repositories;

namespace Api.DEV
{
    [ExtendObjectType(OperationTypeNames.Query)]   
    public class DevQueries 
    {
        public Developer GetDev(int id, [Service] IDevRepository repository) => repository.getDev(id);
    }
}