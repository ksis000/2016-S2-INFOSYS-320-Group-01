﻿using System;
using Xamarin.Forms;

namespace TodoREST
{
	public partial class TodoItemPage : ContentPage
	{
		bool isNewItem;

		public TodoItemPage (bool isNew = false)
		{
			InitializeComponent ();
			isNewItem = isNew;
		}

		async void OnSaveActivated (object sender, EventArgs e)
		{
			var todoItem = (MusicInstrument)BindingContext;
			await App.TodoManager.SaveTaskAsync (todoItem, isNewItem);
			await Navigation.PopAsync ();
		}

		async void OnDeleteActivated (object sender, EventArgs e)
		{
			var todoItem = (MusicInstrument)BindingContext;
			await App.TodoManager.DeleteTaskAsync (todoItem);
			await Navigation.PopAsync ();
		}

		void OnCancelActivated (object sender, EventArgs e)
		{
			Navigation.PopAsync ();
		}

		void OnSpeakActivated (object sender, EventArgs e)
		{
			var todoItem = (MusicInstrument)BindingContext;
			App.Speech.Speak (todoItem.Title + " " + todoItem.Description);
		}
	}
}
