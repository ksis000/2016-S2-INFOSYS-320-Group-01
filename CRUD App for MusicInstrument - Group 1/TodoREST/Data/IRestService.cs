using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoREST
{
	public interface IRestService
	{
		Task<List<MusicInstrument>> RefreshDataAsync ();

		Task SaveTodoItemAsync (MusicInstrument item, bool isNewItem);

		Task DeleteTodoItemAsync (string id);
	}
}
