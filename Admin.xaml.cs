using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
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
	/// Interaction logic for Admin.xaml
	/// </summary>
	/// 

	public class Media
	{
		public string Name { get; set; }
		public double Price { get; set; }
		public int ID { get; set; }
	}

	public class Book : Media
	{
		public string Athure { get; set; }
		public string Publisher { get; set; }

		public double claculateTax()
		{
			double d = 11 * Price / 10;
			return Math.Round(d, 2);
		}
	}

	public class Video : Media
	{
		public int Minutes { get; set; }
		public int CDNumber { get; set;}

		public double caculateTax()
		{
			int p = Minutes / 60 + CDNumber * 3;
			double d = (100+p) * Price / 100;
			return Math.Round(d, 2);
		}
	}

	public class Magazine : Media
	{
		public string Publisher { get; set; }
		public int Pages { get; set; }

		public double caculateTax()
		{
			int p;
			if(Pages <= 20)
				p = 2;
			else if(Pages <= 50)
				p = 3;
			else
				p = 5;
			double d = (100+p) * Price / 100;
			return Math.Round(d, 2);
		}
	}


	public class Library
	{
		public bool AddMedia(Media media) // return true if added seccefully, false otherwise
		{
			bool repetitiuos_id = false;
			if(media is Book)
			{
				Book book = (Book)media;
				string[] lines = File.ReadAllLines("Media.txt");
				for(int i = 2; i < lines.Length; i += 5)
				{
					if(int.Parse(lines[i]) == book.ID)
					{
						repetitiuos_id = true;
						break;
					}
				}

				if(repetitiuos_id == false)
				{
					string info = $"{book.Name}\n{book.claculateTax()}\n{book.ID}\n{book.Athure}\n{book.Publisher}\n";
					File.AppendAllText("Media.txt", info);
					return true;
				}
				else
					return false;
			}

			if(media is Video)
			{
				Video video = (Video)media;
				string[] lines = File.ReadAllLines("Media.txt");
				for(int i = 2; i < lines.Length; i += 5)
				{
					if(int.Parse(lines[i]) == video.ID)
					{
						repetitiuos_id = true;
						break;
					}
				}

				if(repetitiuos_id == false)
				{
					string info = $"{video.Name}\n{video.caculateTax()}\n{video.ID}\n{video.Minutes}\n{video.CDNumber}\n";
					File.AppendAllText("Media.txt", info);
					return true;
				}
				else
					return false;
			}

			if(media is Magazine)
			{
				Magazine magazine = (Magazine)media;
				string[] lines = File.ReadAllLines("Media.txt");
				for(int i = 2; i < lines.Length; i += 5)
				{
					if(int.Parse(lines[i]) == magazine.ID)
					{
						repetitiuos_id = true;
						break;
					}
				}

				if(repetitiuos_id == false)
				{
					string info = $"{magazine.Name}\n{magazine.caculateTax()}\n{magazine.ID}\n{magazine.Publisher}\n{magazine.Pages}\n";
					File.AppendAllText("Media.txt", info);
					return true;
				}
				else
					return false;
			}
			return false;
		}

		public bool DelMedia(int Id) // return true if item deleted
		{
			bool item_found = false;

			string[] lines = File.ReadAllLines("Media.txt");
			int i = 2;
			for(; i < lines.Length; i += 5)
			{
				if(int.Parse(lines[i]) == Id)
				{
					item_found = true;
					break;
				}
			}

			if(item_found == true)
			{
				StreamWriter streamWriter = new StreamWriter("Media.txt");
				i -= 2;
				for(int j = 0; j < lines.Length; j++)
				{
					if(i == j)
					{
						j += 4;///// O_o
						continue;
					}

					streamWriter.WriteLine(lines[j]);
				}
				streamWriter.Close();
				return true;
			}
			else
				return false;
		}

		public string SearchMedia(int Id) // return "" if not found
		{
			bool item_found = false;

			string[] lines = File.ReadAllLines("Media.txt");

			int i = 2;
			for(; i < lines.Length; i += 5)
			{
				if(int.Parse(lines[i]) == Id)
				{
					item_found = true;
					break;
				}
			}

			if(item_found == true)
			{
				i -= 2;
				return $"{lines[i]}\n{lines[i + 1]}\n{lines[i + 2]}\n{lines[i + 3]}\n{lines[i + 4]}";
			}
			else
				return "";
		}
	}
	public class Costumer_info
	{
		public string Info1 { get; set; }
		public string Info2 { get; set; }
	}

	public partial class Admin : Window
	{
		Admin_pesron admin;

		Button AddSelectedButton;
		static Color Add_buttons_color = Color.FromArgb(100, 45, 142, 0);

		public ObservableCollection<Costumer_info> costumers { get; set; }
		public Admin(Admin_pesron admin_Pesron)
		{
			admin = admin_Pesron;
			InitializeComponent();
			lblWelcom.Content = $"Welcom {admin.Name}";
			costumers = new ObservableCollection<Costumer_info>();

			string[] lines = File.ReadAllLines("CostumerInfo.txt");
			for(int i = 0; i < lines.Length; i += 2)
			{
				costumers.Add(new Costumer_info { Info1 = lines[i], Info2 = lines[i + 1] });
			}
			DataContext = this;
		}

		private void btnADD_Click(object sender, RoutedEventArgs e)
		{
			TabctrlAdmin.SelectedItem = TabADD;
			AddSelectedButton = btnMagazine;
			btnMagazine.Background =new SolidColorBrush(Add_buttons_color);
			btnBook.Background = null;
			btnVideo.Background = null;
			lblADD_Info1.Content = "Publisher:";
			lblADD_Info2.Content = "Pages:";
		}

		private void btnDELETE_Click(object sender, RoutedEventArgs e)
		{
			TabctrlAdmin.SelectedItem = TabDELETE;
		}

		private void btnSEARCH_Click(object sender, RoutedEventArgs e)
		{
			TabctrlAdmin.SelectedItem = TabSEARCH;
		}

		private void btnSHOWCUSTOMERS_Click(object sender, RoutedEventArgs e)
		{
			TabctrlAdmin.SelectedItem = TabSHOWCUSTOMERS;
			
		}

		private void btnCHANGEPASS_Click(object sender, RoutedEventArgs e)
		{
			TabctrlAdmin.SelectedItem = TabCHANGEPASS;
		}

		private void btnAdminExit_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure u want to exit?", "Exit", MessageBoxButton.YesNo);
			if(messageBoxResult == MessageBoxResult.Yes)
			{
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				this.Close();
			}
		}

		private void btnMagazine_Click(object sender, RoutedEventArgs e)
		{
			AddSelectedButton = btnMagazine;
			btnMagazine.Background =new SolidColorBrush(Add_buttons_color);
			btnBook.Background = null;
			btnVideo.Background = null;
			lblADD_Info1.Content = "Publisher:";
			lblADD_Info2.Content = "Pages:";
		}

		private void btnBook_Click(object sender, RoutedEventArgs e)
		{
			AddSelectedButton = btnBook;
			btnMagazine.Background = null;
			btnBook.Background = new SolidColorBrush(Add_buttons_color);
			btnVideo.Background = null;
			lblADD_Info1.Content = "Athure:";
			lblADD_Info2.Content = "Publisher";
		}

		private void btnVideo_Click(object sender, RoutedEventArgs e)
		{
			AddSelectedButton = btnVideo;
			btnMagazine.Background = null;
			btnBook.Background = null;
			btnVideo.Background = new SolidColorBrush(Add_buttons_color);
			lblADD_Info1.Content = "Minutes:";
			lblADD_Info2.Content = "CD Numbers:";
		}
		private void btnADD_add_Click(object sender, RoutedEventArgs e)
		{
			Library library = new Library();

			if(txtboxName.Text == "" || txtboxADD_Id.Text == "" || txtboxPrice.Text == "" || txtboxInfo1.Text == "" || txtboxInfo2.Text == "") 
			{
				MessageBox.Show("You should fill all fields");
				return;
			}

			int id;
			try
			{
				id = int.Parse(txtboxADD_Id.Text);
			}
			catch
			{
				MessageBox.Show("ID must be an Integer");
				return;
			}

			double price;
			try
			{
				price = double.Parse(txtboxPrice.Text);
			}
			catch
			{
				MessageBox.Show("Price should be double");
				return;
			}

			if(AddSelectedButton == btnMagazine)
			{
				try
				{
					int page = int.Parse(txtboxInfo2.Text);
					Magazine magazine = new Magazine() { Name = txtboxName.Text, ID = id, Price = price, Publisher = txtboxInfo1.Text, Pages = page };

					bool media_added = library.AddMedia(magazine);
					if(media_added == true)
					{
						MessageBox.Show("Magazine added seccesfully");
						btnADD_clear_Click(null,null);
					}
					else
					{
						MessageBox.Show("Media ID is repetitious");
					}
				}
				catch
				{
					MessageBox.Show("Pages should be an integer");
					return;
				}
			}

			if(AddSelectedButton == btnBook)
			{
				Book book = new Book() { Name = txtboxName.Text, ID = id, Price = price, Athure = txtboxInfo1.Text, Publisher = txtboxInfo2.Text };
				bool media_added = library.AddMedia(book);
				if(media_added == true)
				{
					MessageBox.Show("Book added seccesfully");
					btnADD_clear_Click(null,null);
				}
				else
				{
					MessageBox.Show("Media ID is repetitious");
				}
			}

			if(AddSelectedButton == btnVideo)
			{
				int min;
				try
				{
					min = int.Parse(txtboxInfo1.Text);
				}
				catch
				{
					MessageBox.Show("Minutes should be integer");
					return;
				}

				int number;
				try
				{
					number = int.Parse(txtboxInfo2.Text);
				}
				catch
				{
					MessageBox.Show("Number of CDs should be integer");
					return;
				}

				Video video = new Video() { Name = txtboxName.Text, ID = id, Price = price, Minutes = min, CDNumber = number };
				bool media_added = library.AddMedia(video);
				if(media_added == true)
				{
					MessageBox.Show("Video added seccesfully");
					btnADD_clear_Click(null,null);
				}
				else
				{
					MessageBox.Show("Media ID is repetitious");
				}
			}
		}

		private void btnADD_clear_Click(object sender, RoutedEventArgs e)
		{
			txtboxName.Text = "";
			txtboxPrice.Text = "";
			txtboxADD_Id.Text = "";
			txtboxInfo1.Text = "";
			txtboxInfo2.Text = "";
		}

		private void btnDel_Delete_Click(object sender, RoutedEventArgs e)
		{
			int id;
			try
			{
				id = int.Parse(txtboxDelete.Text);
			}
			catch
			{
				lblDel_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblDel_resualt.Content = "ID should be an Integer";
				return;
			}

			Library library = new Library();
			bool isID_found = library.DelMedia(id);
			if(isID_found == false)
			{
				lblDel_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblDel_resualt.Content = "This ID wasn`t found in Media list";
			}
			else
			{
				lblDel_resualt.Foreground = new SolidColorBrush(Colors.Green);
				lblDel_resualt.Content = "Item deleted seccefully";
			}
		}

		private void btnSEARCH_Search_Click(object sender, RoutedEventArgs e)
		{
			int id;
			try
			{
				id = int.Parse(txtboxSearch.Text);
			}
			catch
			{
				lblSearch_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblSearch_resualt.Content = "ID sould be an Integer";
				return;
			}

			Library library = new Library();
			string info = library.SearchMedia(id);

			if(info == "")
			{
				lblSearch_resualt.Foreground = new SolidColorBrush(Colors.Red);
				lblSearch_resualt.Content = "ID not found";
				return;
			}
			else
			{
				lblSearch_resualt.Foreground = new SolidColorBrush(Colors.Black);
				lblSearch_resualt.Content = info;
			}
		}

		private void btnChangePass_Clear_Click(object sender, RoutedEventArgs e)
		{
			txtboxChangepass_Password.Text = "";
			txtboxChangepass_NewPass.Text = "";
			txtboxChangepass_Confirmpass.Text = "";
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			if(txtboxChangepass_Password.Text=="" || txtboxChangepass_NewPass.Text == "" || txtboxChangepass_Confirmpass.Text == "")
			{
				MessageBox.Show("All fileds should be filled");
				return;
			}

			StreamReader reader = new StreamReader("Password.txt");
			string pass = reader.ReadLine();
			reader.Close();
			if(txtboxChangepass_Password.Text != pass)
			{
				MessageBox.Show("PasswordBox is not correct");
				return;
			}

			if(txtboxChangepass_NewPass.Text != txtboxChangepass_Confirmpass.Text)
			{
				MessageBox.Show("New passwords aren`t same :|");
				return;
			}

			lblPassword_LastTime.Content =$"Password chnaged in {MainWindow.ChangePassTime.ToString("MM/dd/yyyy h:mm tt")}";
			lblPass_NowTime.Content = $"Last time password changed : {DateTime.Now.ToString("MM/dd/yyyy h:mm tt")}";
			MainWindow.ChangePassTime = DateTime.Now;

			//MainWindow.Password = txtboxChangepass_NewPass.Text;
			StreamWriter writer = new StreamWriter("Password.txt");
			writer.WriteLine(txtboxChangepass_NewPass.Text);
			writer.Close();

			MessageBox.Show("Password changed seccefully");
			btnChangePass_Clear_Click(null, null);
		}

	}
}
