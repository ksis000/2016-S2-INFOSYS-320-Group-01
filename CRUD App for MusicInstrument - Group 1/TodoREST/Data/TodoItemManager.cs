using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoREST
{
	public class TodoItemManager
	{
		IRestService restService;

		public TodoItemManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<MusicInstrument>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

		public Task SaveTaskAsync (MusicInstrument item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync (item, isNewItem);
		}

		public Task DeleteTaskAsync (MusicInstrument item)
		{
			return restService.DeleteTodoItemAsync (item.ID);
		}
	}
}
