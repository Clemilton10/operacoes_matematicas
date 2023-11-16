using scaffold_linha_de_comando_v5.Models;
using System.Collections.Generic;

namespace scaffold_linha_de_comando_v5.Services.Implementations
{
	public interface IPersonServices
	{
		Person Create(Person person);
		Person FindById(long id);
		List<Person> FindAll();
		Person Update(Person person);
		void Delete(long id);
	}
}
