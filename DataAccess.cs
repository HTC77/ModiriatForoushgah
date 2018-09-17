using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah
{
   static class DataAccess
    {
        public static string  connectionString = "Data Source=localhost; Initial Catalog=modiriyatForooshgah;Integrated Security=true;User ID=sa;Password=";
      public static SqlConnection objConnection;
      public static SqlCommand objCommand;
 

      public static bool connect()
      {
          bool result = true;
          try
          {
              objConnection = new SqlConnection(connectionString);
              objConnection.Open();
                objCommand =new SqlCommand();
                         objCommand.Connection = objConnection;

          }
          catch(SqlException e)
          {
              result = false;
              MessageBox.Show(e.Message);
          }
          return result;
      }


      public static void addValue(string parametr, string value)
      {
          objCommand.Parameters.AddWithValue(parametr, value);
      }
      public static void  disconnect()
      {
          objConnection.Close();
      }
    }
}
