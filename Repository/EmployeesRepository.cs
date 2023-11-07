using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MVC_TEST.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC_TEST.Repository
{
    public class EmployeesRepository
    {
        public string Sql = ConfigurationManager.ConnectionStrings["TESTConnectionString"].ConnectionString;


        #region 搜尋全員
        public List<Employees> GetList()
        {
            List<Employees> myListEmployees = new List<Employees>();
            Employees myEmployees;

            using (SqlConnection con = new SqlConnection(Sql))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con))
                {
                    con.Open();
                    using (SqlDataReader myRead = cmd.ExecuteReader())
                    {
                        if (myRead.HasRows)
                        {
                            while (myRead.Read())
                            {
                                myEmployees = new Employees()
                                {
                                    ID       = myRead.GetInt32(myRead.GetOrdinal("ID")),
                                    Name     = myRead.GetString(myRead.GetOrdinal("Name")),
                                    Phone    = myRead.GetString(myRead.GetOrdinal("Phone")),
                                    Adderess = myRead.GetString(myRead.GetOrdinal("Adderess")),
                                    Gender   = myRead.GetString(myRead.GetOrdinal("Gender")),
                                    Cancel   = myRead.GetBoolean(myRead.GetOrdinal("Cancel"))
                                };
                                myListEmployees.Add(myEmployees);
                            }
                        }
                    }
                }
            }
            return myListEmployees;
        }
        #endregion

        #region 搜尋ID
        public Employees QueryEmployeesToID(int ID)
        {
            Employees myEmployees = new Employees();

            using (SqlConnection con = new SqlConnection(Sql))
            {
                using (SqlCommand cmd = new SqlCommand("QueryIDForEmployees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int);

                    cmd.Parameters["@ID"].Value = ID;

                    con.Open();
                    using (SqlDataReader myRead = cmd.ExecuteReader())
                    {
                        if (myRead.HasRows)
                        {
                            while (myRead.Read())
                            {

                                myEmployees.ID       = myRead.GetInt32(myRead.GetOrdinal("ID"));
                                myEmployees.Name     = myRead.GetString(myRead.GetOrdinal("Name"));
                                myEmployees.Phone    = myRead.GetString(myRead.GetOrdinal("Phone"));
                                myEmployees.Adderess = myRead.GetString(myRead.GetOrdinal("Adderess"));
                                myEmployees.Gender   = myRead.GetString(myRead.GetOrdinal("Gender"));
                                myEmployees.Cancel   = myRead.GetBoolean(myRead.GetOrdinal("Cancel"));
                            }
                        }
                    }
                }
            }

            return myEmployees;
        }
        #endregion

        #region 新增
        public void Create(Employees Employees)
        {
            using (SqlConnection con = new SqlConnection(Sql))
            {
                using (SqlCommand cmd = new SqlCommand("InsertEmployees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Adderess", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar);

                    cmd.Parameters["@Name"].Value     = Employees.Name.Trim();
                    cmd.Parameters["@Phone"].Value    = Employees.Phone.Trim();
                    cmd.Parameters["@Adderess"].Value = Employees.Adderess.Trim();
                    cmd.Parameters["@Gender"].Value   = Employees.Gender.Trim();

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region 註銷
        public void Delete(int ID)
        {
            using (SqlConnection con = new SqlConnection(Sql))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteForEmployees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int);

                    cmd.Parameters["@ID"].Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region 修改
        public void Edit(Employees Employees)
        {
            using (SqlConnection con = new SqlConnection(Sql))
            {
                using (SqlCommand cmd = new SqlCommand("ModifyEmployees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Adderess", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Cancel", SqlDbType.Bit);

                    cmd.Parameters["@ID"].Value       = Employees.ID;
                    cmd.Parameters["@Name"].Value     = Employees.Name.Trim();
                    cmd.Parameters["@Phone"].Value    = Employees.Phone.Trim();
                    cmd.Parameters["@Adderess"].Value = Employees.Adderess.Trim();
                    cmd.Parameters["@Gender"].Value   = Employees.Gender.Trim();
                    cmd.Parameters["@Cancel"].Value  = false;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}