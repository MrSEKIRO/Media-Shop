using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
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

namespace HW6
{
	public enum Person_type { Admin,Student,Teacher,Costumer}
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public class Person
	{
		public string Name { get; set; }
		public Person_type Type { get; set; }
	}

	public class Admin_pesron : Person
	{
		public string Password { get; set; }

		//public void SaveToFile()
		//{
		//	string info = $"{Name}/n{Password}/n";
		//	File.AppendAllText("Costumer.txt", info);
		//}
	}

	public class Teacher : Person
	{
		public string Institute { get; set; }

		public void SaveToFile()
		{
			bool repetitious = false;
			string[] s = File.ReadAllLines("CostumerInfo.txt");
			for(int i = 0; i < s.Length-1; i+=2)
			{
				if(s[i]==Name && s[i + 1] == Institute)
				{
					repetitious = true;
					break;
				}
			}

			if(repetitious == false)
			{
				string info = $"{Name}\n{Institute}\n";
				File.AppendAllText("CostumerInfo.txt", info);
			}
		}
	}

	public class Student : Person
	{
		public string Student_Number { get; set; }
		public void SaveToFile()
		{
			bool repetitious = false;
			string[] s = File.ReadAllLines("CostumerInfo.txt");
			for(int i = 0; i < s.Length-1; i+=2)
			{
				if(s[i]==Name && s[i + 1] == Student_Number)
				{
					repetitious = true;
					break;
				}
			}

			if(repetitious == false)
			{
				string info = $"{Name}\n{Student_Number}\n";
				File.AppendAllText("CostumerInfo.txt", info);
			}
		}
	}

	public class Costumer : Person
	{
		public string National_Number { get; set; }

		public void SaveToFile()
		{
			bool repetitious = false;
			string[] s = File.ReadAllLines("CostumerInfo.txt");
			for(int i = 0; i < s.Length-1; i+=2)
			{
				if(s[i]==Name && s[i + 1] == National_Number)
				{
					repetitious = true;
					break;
				}
			}

			if(repetitious == false)
			{
				string info = $"{Name}\n{National_Number}\n";
				File.AppendAllText("CostumerInfo.txt", info);
			}
		}
	}

	public partial class MainWindow : Window
	{
		//string Person_Name { get; set; }
		//string Person_pass { get; set; }

		//Person_type person_Type { get; set; }

		Person person = new Person();

		public static string Password { get; set; }

		public static DateTime ChangePassTime { get; set; }
		public MainWindow()
		{
			//Password = "MyShop1234$";
			StreamReader reader = new StreamReader("Password.txt");
			Password = reader.ReadLine();
			reader.Close();
			ChangePassTime = DateTime.Now;
			InitializeComponent();
		}

		
		private void btnAdmin_Click(object sender, RoutedEventArgs e)
		{
			person.Type = Person_type.Admin;
			txtblkUserName.Text = "Username(email):";
			TabCtrlMain.SelectedItem = TabSignIn;
		}

		private void btnUser_Click(object sender, RoutedEventArgs e)
		{
			TabCtrlMain.SelectedItem = TabUser;
		}

		private void btnUserBack_Click(object sender, RoutedEventArgs e)
		{
			TabCtrlMain.SelectedItem = TabWelcom;
		}

		private void btnStudent_Click(object sender, RoutedEventArgs e)
		{
			person.Type = Person_type.Student;
			txtblkUserName.Text = "Name:";
			txtblkPassword.Text = "Student Number:";
			TabCtrlMain.SelectedItem = TabSignIn;
		}

		private void btnTeacher_Click(object sender, RoutedEventArgs e)
		{
			person.Type = Person_type.Teacher;
			txtblkUserName.Text = "Name:";
			txtblkPassword.Text = "Inistitue:";
			TabCtrlMain.SelectedItem = TabSignIn;
		}

		private void btnCoustumer_Click(object sender, RoutedEventArgs e)
		{
			person.Type = Person_type.Costumer;
			txtblkUserName.Text = "Name:";
			txtblkPassword.Text = "National Number:";
			TabCtrlMain.SelectedItem = TabSignIn;
		}

		private void btnBackSignIn_Click(object sender, RoutedEventArgs e)
		{
			if(person.Type == Person_type.Admin)
				TabCtrlMain.SelectedItem = TabWelcom;
			else
				TabCtrlMain.SelectedItem = TabUser;
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			if(person.Type == Person_type.Admin)
			{
				bool entrance = true;

				Regex r = new Regex(@"^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)$");
				if(r.IsMatch(txtbxEmail.Text) == false)
				{
					lblEmailError.Content = "Email is not in right format";
					entrance = false;
				}

				if(txtbxEmail.Text == "")
				{
					lblEmailError.Content = "This field can`t be empty";
					entrance = false;
				}

				StreamReader reader = new StreamReader("Password.txt");
				string pass = reader.ReadLine();
				reader.Close();
				if(txtbxPassword.Text != pass)
				{
					lblPasswordError.Content = "Password is wrong";
					entrance = false;
				}

				if(txtbxPassword.Text == "")
				{
					lblPasswordError.Content = "You should write your password here";
					entrance = false;
				}

				if(entrance == true)
				{
					Admin_pesron admin_Pesron = new Admin_pesron() { Name = txtbxEmail.Text, Password = txtbxPassword.Text, Type = Person_type.Admin };

					Admin admin = new Admin(admin_Pesron);
					admin.Show();
					this.Close();
				}
			}
			else
			{
				switch(person.Type)
				{
					case Person_type.Teacher:
						{
							bool entrance = true;
							if(txtbxEmail.Text == "")
							{
								lblEmailError.Content = "This field can`t be empty";
								entrance = false;
							}

							if(txtbxPassword.Text == "")
							{
								lblPasswordError.Content = "This field should be filled";
								entrance = false;
							}

							if(entrance == true)
							{
								Teacher teacher = new Teacher() { Name = txtbxEmail.Text, Institute = txtbxPassword.Text, Type = Person_type.Teacher };
								teacher.SaveToFile();

								User user = new User(teacher);
								user.Show();
								this.Close();
							}
						}
						break;
					case Person_type.Student:
						{
							bool entrance = true;
							if(txtbxEmail.Text == "")
							{
								lblEmailError.Content = "This field can`t be empty";
								entrance = false;
							}

							Regex student_form = new Regex(@"^9\d{7}$");
							if(student_form.IsMatch(txtbxPassword.Text) == false)
							{
								lblPasswordError.Content = "Student Id is not in right format";
								entrance = false;
							}

							if(entrance == true)
							{
								Student student = new Student() { Name = txtbxEmail.Text, Student_Number = txtbxPassword.Text, Type = Person_type.Student };
								student.SaveToFile();

								User user = new User(student);
								user.Show();
								this.Close();
							}
						}
						break;
					case Person_type.Costumer:
						{
							bool entrance = true;
							if(txtbxEmail.Text == "")
							{
								lblEmailError.Content = "This field can`t be empty";
								entrance = false;
							}

							if(txtbxPassword.Text.NationalNumberFormat() == false)
							{
								lblPasswordError.Content = "National number is not in right format";
								entrance = false;
							}

							if(entrance == true)
							{
								Costumer costumer=new Costumer() { Name = txtbxEmail.Text, National_Number = txtbxPassword.Text, Type = Person_type.Costumer };
								costumer.SaveToFile();

								User user = new User(costumer);
								user.Show();
								this.Close();
							}
						}
						break;
				}
			}
		}

		private void txtbxEmail_TextChanged(object sender, TextChangedEventArgs e)
		{
			lblEmailError.Content = "";
		}

		private void txtbxPassword_TextChanged(object sender, TextChangedEventArgs e)
		{
			lblPasswordError.Content = "";
		}

		private void btnAboutUs_MouseEnter(object sender, MouseEventArgs e)
		{
			btnAboutUs.Foreground = new SolidColorBrush(Colors.Blue);
		}

		private void btnAboutUs_MouseLeave(object sender, MouseEventArgs e)
		{
			btnAboutUs.Foreground = new SolidColorBrush(Colors.Black);
		}

		private void TabCtrlMain_SelectionChanged()
		{

		}
	}

	static class Util
	{
		public static bool NationalNumberFormat(this String s)
		{

			if(s.Length != 10)
				return false;

			char[] number=new char[10];
			for(int i = 0; i < 10; i++)
			{
				number[i]= s[i];
			}

			bool allDiditsSame = true;
			int k = number[0] - '0';
			foreach(char ch in number)
			{
				if(k != (int)ch - '0')
				{
					allDiditsSame = false;
					break;
				}
			}
			if(allDiditsSame == true)
				return false;

			int a = number[9] - '0';
			int b = (number[0] - '0') * 10 + (number[1] - '0') * 9 + (number[2] - '0') * 8 + (number[3] - '0') * 7
				  + (number[4] - '0') * 6 + (number[5] - '0') * 5 + (number[6] - '0') * 4 + (number[7] - '0') * 3
				  + (number[8] - '0') * 2;
			int c = (b % 11);

			if(c == 0)
			{
				if(a == c)
					return true;
				else
					return false;
			}
			else if(c == 1)
			{
				if(a == 1)
					return true;
				else
					return false;
			}
			else if(c > 1)
			{
				if(a == Math.Abs(c - 11))
					return true;
				else
					return false;
			}
			else
				return false;
		}
	}
}
