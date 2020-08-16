using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonReader.CSV
{
    public class CSVReader : IPersonReader
    {
        private string filePath;

        // START Code Block #1: "Simple" Property Injection
        // Dependency is "new"ed up by the constructor every time
        // (if the property is overridden before any method calls,
        // the default is still "new"ed up even though it is never used).

        //public ICSVFileLoader FileLoader { get; set; }

        //public CSVReader(string dataFilePath)
        //{
        //    filePath = dataFilePath;
        //    FileLoader = new CSVFileLoader(filePath);
        //}

        // END Code Block #1

        // START Code Block #2: "Safe" Property Injection
        // Dependency is not "new"ed up until after it is asked for
        // (if the property is overridden before any method calls,
        // the default is never "new"ed up).
        private ICSVFileLoader fileLoader;
        public ICSVFileLoader FileLoader
        {
            get { return fileLoader ??= new CSVFileLoader(filePath); }
            set { fileLoader = value; }
        }

        public CSVReader()
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + "People.txt";
        }
        // END Code Block #2


        public IReadOnlyCollection<Person> GetPeople()
        {
            var fileData = FileLoader.LoadFile();
            var people = ParseString(fileData);
            return people;
        }

        public Person GetPerson(int id)
        {
            var people = GetPeople();
            return people?.FirstOrDefault(p => p.Id == id);
        }

        private List<Person> ParseString(string csvData)
        {
            var people = new List<Person>();

            var lines = csvData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                try
                {
                    var elems = line.Split(',');
                    var per = new Person()
                    {
                        Id = Int32.Parse(elems[0]),
                        GivenName = elems[1],
                        FamilyName = elems[2],
                        StartDate = DateTime.Parse(elems[3]),
                        Rating = Int32.Parse(elems[4]),
                        FormatString = elems[5],
                    };
                    people.Add(per);
                }
                catch (Exception)
                {
                    // Skip the bad record, log it, and move to the next record
                    // log.write("Unable to parse record", per);
                }
            }
            return people;
        }
    }
}
