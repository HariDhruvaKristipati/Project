using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bal;
using Dal;


namespace Dal
{
  public  class DALPayRoll
    {
        //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        Bal.PayRoll p=new Bal.PayRoll();
       public void Add_PayRoll(PayRoll pay)
        {
            SqlConnection con1=new SqlConnection("Data Source==WIN-K9JM7C2EKKD;Initial Catalog=HRMSEntities1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("payRoll_Add", con1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pay.ID);
            cmd.Parameters.AddWithValue("@BasicPay", pay.BasicPay);
            cmd.Parameters.AddWithValue("@Allowances", pay.Allowances);
            cmd.Parameters.AddWithValue("@Deductions", pay.Deductions);
            cmd.Parameters.AddWithValue("@GrossPay", pay.GrossPay);
            cmd.Parameters.AddWithValue("@NetPay", pay.NetPay);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
        }

        private static SqlConnection Connect()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        public void Update_PayRoll(PayRoll pay)
          {
            SqlConnection con2 = Connect();
            SqlCommand cmd = new SqlCommand("payRoll_updating", con2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pay.ID);
            cmd.Parameters.AddWithValue("@BasicPay", pay.BasicPay);
            cmd.Parameters.AddWithValue("@Allowances", pay.Allowances);
            cmd.Parameters.AddWithValue("@Deductions", pay.Deductions);
            cmd.Parameters.AddWithValue("@GrossPay", pay.GrossPay);
            cmd.Parameters.AddWithValue("@NetPay", pay.NetPay);
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();

         }


       public DataSet Show_PayRoll()
         {
            SqlConnection con1 = Connect();
            SqlCommand cmd = new SqlCommand("PayRoll_Lists", con1);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;

         }

       public void Delete_PayRoll(int id)
         {
            SqlConnection con1 = Connect();
            SqlCommand cmd = new SqlCommand("PayRoll_Deleting", con1);
            cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ID",id);
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();

         }
    }
}
