using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HW6
{
	/// <summary>
	/// Interaction logic for User.xaml
	/// </summary>
	/// 

	public class Product
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public int ID { get; set; }
	}
	public partial class User : Window
	{
		Person person;

		int ChanceOffPrcent;
		public ObservableCollection<Product> Products { get; set; }

		public ObservableCollection<Product> Cart { get; set; }
		public User(Person person)
		{
			InitializeComponent();

			this.person = person;
			txtblkUser_welcom.Text = $"Welcom {person.Name}";

			Cart = new ObservableCollection<Product>();

			Products = new ObservableCollection<Product>();
			string[] lines = File.ReadAllLines("Media.txt");
			for(int i = 0; i < lines.Length; i += 5)
			{
				Products.Add(new Product() { Name = lines[i], Price = double.Parse(lines[i + 1]), ID = int.Parse(lines[i + 2]) });
			}
			DataContext = this;
		}


		private void btnSELECT_Click(object sender, RoutedEventArgs e)
		{
			TabctrlUser.SelectedItem = TabSelect;
		}

		private void btnEDIT_Click(object sender, RoutedEventArgs e)
		{
			TabctrlUser.SelectedItem = TabEdit;
		}

		private void BUYCalculatePrice()
		{
			double sum = 0;
			foreach(var p in Cart)
			{
				sum += p.Price;
			}

			txtblkReal_price.Text = $"SUM = {sum}";

			int OFF = ChanceOffPrcent;
			switch(person.Type)
			{
				case Person_type.Student:
					{
						OFF += 20;
					}
					break;
				case Person_type.Teacher:
					{
						if(Cart.Count > 3)
						{
							OFF += 20;
						}
					}
					break;
				case Person_type.Costumer:
					{
						if(Cart.Count > 5)
						{
							OFF += 5;
						}
					}
					break;
			}
			txtblkOFF.Text = $"{OFF}%";

			double finalPrice = Math.Round((100 - OFF) * sum / 100, 2);
			txtblkFinal_price.Text = $"{finalPrice}";
		}
		private void btnBUY_Click(object sender, RoutedEventArgs e)
		{
			TabctrlUser.SelectedItem = TabBuy;
			lblBUY_resualt.Content = "";
			BUYCalculatePrice();
		}

		private void btnCHANCE_Click(object sender, RoutedEventArgs e)
		{
			TabctrlUser.SelectedItem = TabChance;
		}

		private void btnuSERExit_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure u want to exit?", "Exit", MessageBoxButton.YesNo);
			if(messageBoxResult == MessageBoxResult.Yes)
			{
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				this.Close();
			}
		}

		private void btn_Select_submit_Click(object sender, RoutedEventArgs e)
		{
			if(txtboxSelect.Text == "")
			{
				lblSelect_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblSelect_resualt.Content = "No name entered!";
				return;
			}

			bool Name_found = false;
			Product product=null;
			foreach(var p in Products)
			{
				if(p.Name == txtboxSelect.Text)
				{
					product = p;
					Name_found = true;
					break;
				}
			}

			if(Name_found == true)
			{
				if(Cart.Count < 20)
				{
					Cart.Add(product);
					txtboxSelect.Text = "";
					lblSelect_resualt.Foreground = new SolidColorBrush(Colors.Green);
					lblSelect_resualt.Content = "Item added to your cart";
				}
				else
				{
					MessageBox.Show("Your Cart is full(you can buy max 20 items)");
				}
			}
			else
			{
				lblSelect_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblSelect_resualt.Content = "This name is not in media list";
			}
		}

		private void txtboxSelect_TextChanged(object sender, TextChangedEventArgs e)
		{
			lblSelect_resualt.Content = "";
		}

		private void btnEdit_delete_Click(object sender, RoutedEventArgs e)
		{
			if(txtboxEdit.Text == "")
			{
				lblEdit_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblEdit_resualt.Content = "No Name is entered!";
				return;
			}

			bool itemFound = false;
			Product product = null;
			foreach(var p in Cart)
			{
				if(p.Name == txtboxEdit.Text)
				{
					product = p;
					itemFound = true;
					break;
				}
			}

			if(itemFound == true)
			{
				Cart.Remove(product);
				txtboxEdit.Text = "";
				lblEdit_resualt.Foreground = new SolidColorBrush(Colors.Green);
				lblEdit_resualt.Content = "Item deleted seccesfully";
			}
			else
			{
				lblEdit_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblEdit_resualt.Content = "This name wasn`t found in your cart";
			}

		}

		private void txtboxEdit_TextChanged(object sender, TextChangedEventArgs e)
		{
			lblEdit_resualt.Content = "";
		}

		private void btnGetChance_Click(object sender, RoutedEventArgs e)
		{
			int[] numbers = new int[] { 0, 2, 3, 5, 7, 10, 15, 25, 30 };
			Random r = new Random();
			ChanceOffPrcent = numbers[r.Next(numbers.Length)];

			lblChance_resualt.Content = $"YOU GOT {ChanceOffPrcent}% OFF";
			btnGetChance.IsEnabled = false;
		}

		private void btnBUY_Buy_Click(object sender, RoutedEventArgs e)
		{
			lblBUY_resualt.Foreground = new SolidColorBrush(Colors.Green);
			lblBUY_resualt.Content = "You bought items seccesfully";

			// Cart empty, make prices 0
			BUYCalculatePrice();
			Cart.Clear();

			// Chance is used
			ChanceOffPrcent = 0;
			btnGetChance.IsEnabled = true;
			lblChance_resualt.Content = "";
		}
	}
}
