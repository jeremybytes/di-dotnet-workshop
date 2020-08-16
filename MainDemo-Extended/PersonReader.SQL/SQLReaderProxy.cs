using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonReader.SQL
{
    public class SQLReaderProxy : IPersonReader
    {
        string sqlFileName;

        public SQLReaderProxy(string sqlFileName)
        {
            this.sqlFileName = sqlFileName;
        }

        public Task<IReadOnlyCollection<Person>> GetPeople()
        {
            using (var reader = new SQLReader(sqlFileName))
            {
                return reader.GetPeople();
            }
        }

        public Task<Person> GetPerson(int id)
        {
            using (var reader = new SQLReader(sqlFileName))
            {
                return reader.GetPerson(id);
            }
        }
    }
}
