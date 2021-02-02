using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CDADOWithStoredProcedures01Feb
{
    class ADOWithStoredProcedure
    {

        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int InsertOneRow()
        {
            try
            {
                Console.WriteLine("Enter Employee Name:");
                var empname = Console.ReadLine();

                Console.WriteLine("Enter Employee Salary:");
                var empsal = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Enter Employee Dept:");
                var empdept = Console.ReadLine();

                Console.WriteLine("Enter Employee department no.");
                var deptno = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_InsertDetails3", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@empsal", SqlDbType.Float).Value = empsal;
                cmd.Parameters.Add("@empdept", SqlDbType.VarChar, 20).Value = empdept;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row added to table");

                return i;
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }


        public int DeleteOneRow()
        {
            try
            {

                Console.WriteLine("Enter Employee Id to Delete:");
                var empid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_DeleteDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;


                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row deleted from table ");
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public int UpdateOneRow()
        {
            try
            {
                Console.WriteLine("Enter Employee ID.");
                var empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee name:");
                var empname = Console.ReadLine();
                Console.WriteLine("Enter Employee salary:");
                var empsal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee Department:");
                var empdept = Console.ReadLine();
                Console.WriteLine("Enter Employee department no.");
                var deptno = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = empid;
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = empsal;
                cmd.Parameters.Add("@empdept", SqlDbType.VarChar, 20).Value = empdept;
                cmd.Parameters.Add("@deptId", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cmd.ExecuteNonQuery();


                return i;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }

        public void SearchOneRow()
        {
            try
            {
                Console.WriteLine("Enter Employee ID.");
                var empid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_SearchForDetails1", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        Console.WriteLine($"Name is: {dr["empname"]}");
                        Console.WriteLine($"Salary is: {dr["empsal"]}");
                        Console.WriteLine($"Department name is: {dr["empdept"]}");
                    }
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public int ShowData()
        {
            try
            {
                Console.WriteLine("Data from the table ");
                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeADO1", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empname"]} \t {dr["empsal"]} \t {dr["empdept"]} ");
                }
                return 0;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            ADOWithStoredProcedure sp = new ADOWithStoredProcedure();
            int ch,co;
            do
            {
                Console.WriteLine("-------DML Commands With Stored Procedure-------");
                Console.WriteLine("1 - Insert\n2 - Delete\n3 - Update\n4 - Search\n5 - Show");
                Console.WriteLine("\nEnter Your Choice");
                ch = Convert.ToInt32(Console.ReadLine());


                switch (ch)
                {
                    case 1:
                        sp.InsertOneRow();
                        break;

                    case 2:
                        sp.DeleteOneRow();
                        break;

                    case 3:
                        sp.UpdateOneRow();
                        break;

                    case 4:
                        sp.SearchOneRow();
                        break;

                    case 5:
                        sp.ShowData();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
                Console.WriteLine("Do you want to continue(1/0):");
                co = Convert.ToInt32(Console.ReadLine());
            
            
            } while (co == 1);


        }
    }
}
