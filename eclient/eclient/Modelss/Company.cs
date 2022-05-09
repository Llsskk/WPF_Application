using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Data;

namespace eclient.Modelss
{
    public class Company : Model
    {
        public int Id { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string NumberReg { get; set; }
        public string DataReg { get; set; }
        public int OrgRegistrationId { get; set; }
        public int PersonsId { get; set; }
        public string OrgRegistrationShort { get; set; }

        public static List<Company> GetList()
        {
            var list = new List<Company>();
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = "SELECT Company.Id, (SELECT nameShort FROM orgRegistration" +
                        " WHERE Id = orgRegistrationId), namefull, nameshort, numberreg, datareg FROM company";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        
                        string orgRegistrationShort = reader.GetString(1);
                        string namefull = reader.GetString(2);
                        string nameshort = reader.GetString(3);
                        string numberreg = reader.GetString(4);
                        string datareg = reader.GetString(5);

                        var company = new Company
                        {
                            Id = id,
                            OrgRegistrationShort = orgRegistrationShort,
                            NameFull = namefull,
                            NameShort = nameshort,
                            NumberReg = numberreg,
                            DataReg = datareg,
                        
                        };
                        list.Add(company);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return list;
        }
        public static void Add(Company company)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"INSERT INTO Company (namefull, nameshort, numberreg, datareg, OrgRegistrationId) VALUES (@namefull, @nameshort, @numberreg, @datareg, @OrgRegistrationId)");
                    command.Parameters.AddWithValue("namefull", company.NameFull);
                    command.Parameters.AddWithValue("nameshort", company.NameShort);
                    command.Parameters.AddWithValue("numberreg", company.NumberReg);
                    command.Parameters.AddWithValue("datareg", company.DataReg.ToString());
                   
                    command.Parameters.AddWithValue("OrgRegistrationId", company.OrgRegistrationId);
                   


                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void Update(Company company)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"UPDATE company SET namefull = @namefull, nameshort = @nameshort, numberreg = @numberreg, datareg = @datareg, orgregistrationId = @orgregistrationId WHERE Id=@Id");
                    command.Parameters.AddWithValue("namefull", company.NameFull);
                    command.Parameters.AddWithValue("nameshort", company.NameShort);
                    command.Parameters.AddWithValue("numberreg", company.NumberReg);
                    command.Parameters.AddWithValue("datareg", company.DataReg.ToString());
                    command.Parameters.AddWithValue("orgregistrationId", company.OrgRegistrationId);
                    command.Parameters.AddWithValue("Id", company.Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void Delete(Company company)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"DELETE FROM company WHERE Id = @Id");
                    command.Parameters.AddWithValue("Id", company.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public Company()
        {

        }
    }
}

 

