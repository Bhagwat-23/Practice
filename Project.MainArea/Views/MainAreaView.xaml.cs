using Microsoft.Practices.ServiceLocation;
using Project.MainArea.Interfaces;
using Project.MainArea.Models;
using Project.MainArea.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.MainArea.Views
{
	/// <summary>
	/// Interaction logic for MainAreaView.xaml
	/// </summary>
	public partial class MainAreaView : UserControl
	{
		public MainAreaView()
		{
			InitializeComponent();
			this.DataContext = ServiceLocator.Current.GetInstance<IMainAreaViewModel>();
		}

		private void SelectedItemEventHandler(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var viewModel = this.DataContext as MainAreaViewModel;
			var x = e.NewValue as TreeModel;
			viewModel.SelectedTreeItem = x;
		}
	}
}
