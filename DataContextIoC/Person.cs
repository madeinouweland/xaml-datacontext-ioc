using System.Diagnostics;

namespace DataContextIoC
{
    [DebuggerDisplay("Id: {Id}, Name: {Name}")]
    public class Person
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
