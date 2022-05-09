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
    public class OrgLegForms : Model
    {
		public int Id { get; set; }
		public string NameFull { get; set; }
		public string NameShort { get; set; }
	
		public static List<OrgLegForms> GetList()
		{
			var list = new List<OrgLegForms>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT * FROM orgLegForms";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string namefull = reader.GetString(1);
						string nameshort = reader.GetString(2);
						
						var orglegforms = new OrgLegForms
						{
							Id = id,
							NameFull = namefull,
							NameShort = nameshort,
							

						};
						list.Add(orglegforms);
					}

				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(OrgLegForms orglegforms)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO orgLegForms (nameFull, nameShort) VALUES (@nameFull, @nameShort)");
					command.Parameters.AddWithValue("nameFull", orglegforms.NameFull);
					command.Parameters.AddWithValue("nameShort", orglegforms.NameShort);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(OrgLegForms orglegforms)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE orgLegForms SET nameFull=@nameFull, nameShort=@nameShort WHERE Id=@Id");
					command.Parameters.AddWithValue("nameFull", orglegforms.NameFull);
					command.Parameters.AddWithValue("nameShort", orglegforms.NameShort);
					command.Parameters.AddWithValue("Id", orglegforms.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(OrgLegForms orglegforms)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM orgLegForms WHERE Id = @Id");
					command.Parameters.AddWithValue("Id", orglegforms.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public OrgLegForms()
		{

		}
	}
}
