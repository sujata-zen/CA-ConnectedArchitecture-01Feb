using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CDADOWithParametrs01Feb
{

    class ADOWithParameter
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

                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into EmployeeADO values(@empname,@empsal,@empdept)", cn);
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@empsal", SqlDbType.Float).Value = empsal;
                cmd.Parameters.Add("@empdept", SqlDbType.VarChar, 20).Value = empdept;
               
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One rown added to table");

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
                cmd = new SqlCommand("delete from EmployeeADO where empid= " + empid + " ", cn);
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
                Console.WriteLine("Enter Existing Employee id which you want to update ");
                var empid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update EmployeeADO set empname = 'Parinita', empsal = 63295, empdept = 'Sales' where empid = " + empid + "", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row updated in table ");

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

        public void SearchOneRow()
        {
            try
            {
                Console.WriteLine("Enter id for search record:");
                var empid = Convert.ToInt32(Console.ReadLine());

                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select empname,empsal,empdept from EmployeeADO where empid=(" + empid + " )", cn);

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    Console.WriteLine($"Employee Name is: {dr["empname"]}");
                    Console.WriteLine($"Employee Salary is: {dr["empsal"]}");
                    Console.WriteLine($"Employee Department is: {dr["empdept"]}");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                Console.WriteLine("Data to be displyed");
                cn = new SqlConnection("Data Source=DESKTOP-FSH4J96;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeADO", cn);
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

            ADOWithParameter wp = new ADOWithParameter();
         
            Console.WriteLine("1 - Insert\n2 - Delete\n3 - Update\n4 - Search\n5 - Show");
            Console.WriteLine("\nEnter Your Choice");
            var ch = Convert.ToInt32(Console.ReadLine());

           

            switch (ch)
            { 
                case 1:
                    wp.InsertOneRow();
                    break;

                case 2:
                    wp.DeleteOneRow();
                    break;

                case 3:
                    wp.UpdateOneRow();
                    break;

                case 4:
                    wp.SearchOneRow();
                    break;

                case 5:
                    wp.ShowData();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }
           
        }
    }
}
