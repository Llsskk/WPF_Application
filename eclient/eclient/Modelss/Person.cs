using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;


namespace eclient.Modelss
{
	public class Person : Model
	{
		public int Id { get; set; }
		public string Shifer { get; set; }
		public string Inn { get; set; }
		public string Type { get; set; }
		public string Data { get; set; }
		public static List<Person> GetList()
		{
			var list = new List<Person>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT * FROM person";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string shifer = reader.GetString(1);
						string inn = reader.GetString(2);
						string type = reader.GetString(3);
						string data = reader.GetString(4);
						var person = new Person
						{
							Id = id,
							Shifer = shifer,
							Inn = inn,
							Type = type,
							Data = data,

						};
						list.Add(person);
					}

				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(Person person)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO person (Id, shifer, inn, type, data)
                    VALUES (@Id, @shifer, @inn, @type, @data)");
					command.Parameters.AddWithValue("Id", person.Id);
					command.Parameters.AddWithValue("shifer", person.Shifer);
					command.Parameters.AddWithValue("inn", person.Inn);
					command.Parameters.AddWithValue("type", person.Type);
					command.Parameters.AddWithValue("data", person.Data.ToString());
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(Person person)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE person SET Id = @Id, shifer = @shifer, inn = @inn,
                    type = @type, data = @data WHERE Id = @Id");
					command.Parameters.AddWithValue("Id", person.Id);
					command.Parameters.AddWithValue("shifer", person.Shifer);
					command.Parameters.AddWithValue("inn", person.Inn);
					command.Parameters.AddWithValue("type", person.Type);
					command.Parameters.AddWithValue("data", person.Data);
					
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(Person person)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM person WHERE Id = @Id");
					command.Parameters.AddWithValue("Id", person.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public Person() { }
	}
}
