using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using System.Data;



/// -------> Q1

class program
{
    public static void Main(string[] args)
    {
        //DATA_BASE LINKING
        string con_str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AssignmentFive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conn = new SqlConnection(con_str);

        string opt;
        Console.WriteLine("1. Insert");
        Console.WriteLine("2. Delete");
        Console.WriteLine("3. Select/print");
        Console.WriteLine("4. Update");

        opt = Console.ReadLine();

        switch (opt)
        {
            case "1":
                Console.WriteLine("Insert the new data: ");
                Console.ReadLine();
                Console.WriteLine("ID");
                string id = Console.ReadLine();
                Console.WriteLine("First name");
                string f_name = Console.ReadLine();
                Console.WriteLine("Last name");
                string l_name = Console.ReadLine();
                Console.WriteLine("Email");
                string gmail = Console.ReadLine();
                Console.WriteLine("Primary phone number");
                string p_num = Console.ReadLine();
                Console.WriteLine("Secondary phone number");
                string s_num = Console.ReadLine();
                Console.WriteLine("Created By");
                string create_by = Console.ReadLine();
                Console.WriteLine("Modified By");
                string mod_by = Console.ReadLine();


                string insert_query = "INSERT INTO table Employees (ID, FIRST_NAME, LAST_NAME, EMAIL, PRIMARY_PH_NUM, SECONDARY_PH_NUM, CREATED_BY, CREATED_ON, MODIFIED_BY, MODIFIED_ON) VALUES (@ID, @FIRST_NAME, @LAST_NAME, @EMAIL, @PRIMARY_PH_NUM, @SECONDARY_PH_NUM, @CREATED_BY, @CREATED_ON, @MODIFIED_BY, @MODIFIED_ON)";
                SqlCommand cmd = new SqlCommand(insert_query, conn);

                cmd.Parameters.AddWithValue("@ID", $"{id}");
                cmd.Parameters.AddWithValue("@FIRST_NAME", $"{f_name}");
                cmd.Parameters.AddWithValue("@LAST_NAME", $"{l_name}");
                cmd.Parameters.AddWithValue("@EMAIL", $"{gmail}");
                cmd.Parameters.AddWithValue("@PRIMARY_PH_NUM", $"{p_num}");
                cmd.Parameters.AddWithValue("@SECONDARY_PH_NUM", $"{s_num}");
                cmd.Parameters.AddWithValue("@SECONDARY_PH_NUM", $"{s_num}");
                cmd.Parameters.AddWithValue("@CREATED_BY", $"{create_by}");
                cmd.Parameters.AddWithValue("@MODIFIED_BY", $"{mod_by}");

                conn.Open();

                int insert_count = cmd.ExecuteNonQuery();
                if (insert_count >= 1)
                {
                    Console.WriteLine("1 Row has successfully inserted!");
                    conn.Close();
                }
                else
                {
                    Console.WriteLine("Row has not been inserted!");
                    conn.Close();
                }
                conn.Close();
                break;



            case "2":
                //DELETING FROM DRIVER TABLE
                Console.WriteLine("Enter record-Id you want to delete??");
                string rec_id = Console.ReadLine();

                string delete_query = "DELETE FROM table Employees WHERE Id = @Id";

                SqlCommand sql_cmd = new SqlCommand(delete_query, conn);

                sql_cmd.Parameters.AddWithValue("@Id", $"{rec_id}");

                conn.Open();
      
                int dlt_ans = sql_cmd.ExecuteNonQuery();
                if (dlt_ans > 0)
                {
                    Console.WriteLine("One Row deleted!!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("No row deleted!!");
                    Console.ReadLine();
                }
                conn.Close();
                break;


            case "3":

                string select_query = "SELECT * FROM EMPLOYEE";

                SqlCommand sql_cmd = new SqlCommand(select_query, conn);

                conn.Open();

                var reader = sql_cmd.ExecuteReader();
                conn.Open();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetString());
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                break;


            case "4":
                Console.WriteLine("Give employee Id you want to update: ");
                string Id = Console.ReadLine();
                Console.ReadLine();
                Console.WriteLine("First name");
                string F_name = Console.ReadLine();
                Console.WriteLine("Last name");
                string L_name = Console.ReadLine();
                Console.WriteLine("Email");
                string Gmail = Console.ReadLine();
                Console.WriteLine("Primary phone number");
                string P_num = Console.ReadLine();
                Console.WriteLine("Secondary phone number");
                string S_num = Console.ReadLine();
                Console.WriteLine("Created By");
                string Create_by = Console.ReadLine();
                Console.WriteLine("Modified By");
                string Mod_by = Console.ReadLine();

                string update_query = "UPDATE DriverTable SET FIRST_NAME =  @FIRST_NAME , LAST_NAME = @LAST_NAME, EMAIL = @EMAIL, PRIMARY_PH_NUM =  @PRIMARY_PH_NUM, SECONDARY_PH_NUM = @SECONDARY_PH_NUM, CREATED_BY =  @CREATED_BY, CREATED_ON = @CREATED_ON, MODIFIED_BY = @MODIFIED_BY, MODIFIED_ON =  @MODIFIED_ON WHERE ID = @ID";

                SqlCommand sqlcmd = new SqlCommand(update_query, conn);

                cmd.Parameters.AddWithValue("@FIRST_NAME", $"{F_name}");
                cmd.Parameters.AddWithValue("@LAST_NAME", $"{L_name}");
                cmd.Parameters.AddWithValue("@EMAIL", $"{Gmail}");
                cmd.Parameters.AddWithValue("@PRIMARY_PH_NUM", $"{P_num}");
                cmd.Parameters.AddWithValue("@SECONDARY_PH_NUM", $"{S_num}");
                cmd.Parameters.AddWithValue("@CREATED_BY", $"{Create_by}");
                cmd.Parameters.AddWithValue("@MODIFIED_BY", $"{Mod_by}");

                conn.Open();

                int update_count = sqlcmd.ExecuteNonQuery();
                if (update_count >= 1)
                {
                    Console.WriteLine("1 Row has successfully Updated!");
                    conn.Close();
                }
                else
                {
                    Console.WriteLine("Row has not been Updated!");
                    conn.Close();
                }
                conn.Close();
                break;

        }
    }
}