using Microsoft.EntityFrameworkCore;
using Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace PersonReader.SQL
{
    internal class SQLReader : IPersonReader, IDisposable
    {
        PersonContext context;

        public SQLReader(string sqlFileName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();
            optionsBuilder.UseSqlite($"Data Source={sqlFileName}");
            DbContextOptions<PersonContext> options = optionsBuilder.Options;
            context = new PersonContext(options);
        }

        public Task<IReadOnlyCollection<Person>> GetPeople()
        {
            
            return Task.FromResult<IReadOnlyCollection<Person>>(context.People.ToImmutableList());
        }

        public Task<Person> GetPerson(int id)
        {
            return context.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
