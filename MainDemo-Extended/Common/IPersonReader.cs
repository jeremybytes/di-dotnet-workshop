using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common
{
    public interface IPersonReader
    {
        Task<IReadOnlyCollection<Person>> GetPeople();
        Task<Person> GetPerson(int id);
    }
}
