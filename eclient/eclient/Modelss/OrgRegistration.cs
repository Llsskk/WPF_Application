using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.Windows;

namespace eclient.Modelss
{
    public class OrgRegistration : Model
    {
		public int Id { get; set; }
		public string NameFull { get; set; }
		public string NameShort { get; set; }

		public static List<OrgRegistration> GetList()
		{
			var list = new List<OrgRegistration>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT * FROM orgRegistration";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string namefull = reader.GetString(1);
						string nameshort = reader.GetString(2);

						var orgRegistration = new OrgRegistration
						{
							Id = id,
							NameFull = namefull,
							NameShort = nameshort,


						};
						list.Add(orgRegistration);
					}

				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(OrgRegistration orgRegistration)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO orgRegistration (nameFull, nameShort) VALUES (@nameFull, @nameShort)");
					command.Parameters.AddWithValue("nameFull", orgRegistration.NameFull);
					command.Parameters.AddWithValue("nameShort", orgRegistration.NameShort);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(OrgRegistration orgRegistration)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE orgRegistration SET nameFull=@nameFull, nameShort=@nameShort WHERE Id=@Id");
					command.Parameters.AddWithValue("nameFull", orgRegistration.NameFull);
					command.Parameters.AddWithValue("nameShort", orgRegistration.NameShort);
					command.Parameters.AddWithValue("Id", orgRegistration.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(OrgRegistration orgRegistration)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM orgRegistration WHERE Id = @Id");
					command.Parameters.AddWithValue("Id", orgRegistration.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public OrgRegistration()
		{

		}
	}
}
