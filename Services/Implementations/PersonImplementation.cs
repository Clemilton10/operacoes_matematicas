using scaffold_linha_de_comando_v5.Models;
using System.Collections.Generic;
using System.Threading;

namespace scaffold_linha_de_comando_v5.Services.Implementations
{
	public class PersonImplementation : IPersonServices
	{
		private volatile int count;

		public Person Create(Person person)
		{
			person.Id = IncrementAndGet();
			return person;
		}

		public void Delete(long id)
		{

		}

		public List<Person> FindAll()
		{
			List<Person> persons = new List<Person>();
			for (int i = 0; i < 8; i++)
			{
				Person person = MockPerson(i);
				persons.Add(person);
			}
			return persons;
		}

		private Person MockPerson(int i)
		{
			return new Person
			{
				Id = IncrementAndGet(),
				FirstName = "First Name " + i,
				LastName = "Last Name " + i,
				Address = "Address " + i,
				Gender = "Male"
			};
		}

		private long IncrementAndGet()
		{
			return Interlocked.Increment(ref count);
		}

		public Person FindById(long id)
		{
			return new Person
			{
				Id = id,
				FirstName = "First Name " + id,
				LastName = "Last Name " + id,
				Address = "Address " + id,
				Gender = "Male"
			};
		}

		public Person Update(Person person)
		{
			return person;
		}
	}
}
