using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace PhoneBookApp.Pages
{
	public partial class AddressBookPage : ContentPage
	{
		public AddressBookPage()
		{
			InitializeComponent();

            //ContactsCollectionView.SelectionChanged += OnSelectionChanged;
		}

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ContactsCollectionView.SelectedItem = null;
        }
    }
}
