using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah.classes
{
    class Category
    {

        internal void add(string name)
        {

            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "insert into [category] (name) VALUES(@name)";
                DataAccess.addValue("@name", name);
                try
                {
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            DataAccess.disconnect();
        }


  internal void update(int id, string name)
        {  if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "update [category] set name=@name WHERE id=@id";
                DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@name", name);
                try
                {
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            DataAccess.disconnect();
        }
        internal void delete(int id)
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = " DELETE FROM [category] WHERE id=@id";
                DataAccess.addValue("@id", id.ToString());
                try
                {
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }

            }

            DataAccess.disconnect();

        }

      
    }
}
