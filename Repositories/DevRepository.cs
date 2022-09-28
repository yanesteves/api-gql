using Api.DEV;

namespace Api.Repositories
{
    public class DevRepository : IDevRepository
    {
        private Dictionary<int, Developer> _devs;
        public Developer GetDeveloper(int id)
        {
            
        }

        private static IEnumerable<Developer> CreateDevs() 
        {
            yield return new Developer (
                ""
            );
        }
    }
}