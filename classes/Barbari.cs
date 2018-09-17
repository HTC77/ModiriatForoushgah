using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah.classes
{
    class Barbari
    {


        public void add(string name, string address, string telephoneSabet, string tozihat)
        { if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "insert into [barbari] (name,address, telephone,tozihat) VALUES(@name,@address,@telephoneSabet,@tozihat)";
                DataAccess.addValue("@name", name);
                DataAccess.addValue("@address", address);
                DataAccess.addValue("@telephoneSabet", telephoneSabet);
                DataAccess.addValue("@tozihat", tozihat);
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

        public void update(int id, string name, string address, string telephoneSabet, string tozihat)
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "update [barbari] set name=@name,address=@address, telephone=@telephoneSabet, tozihat=@tozihat WHERE id=@id";
                DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@name", name);
                DataAccess.addValue("@address", address);
                DataAccess.addValue("@telephoneSabet", telephoneSabet);
                DataAccess.addValue("@tozihat", tozihat);
                try{
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            DataAccess.disconnect();
        }

        public void delete(int id)
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "DELETE FROM [barbari] WHERE id=@id";
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
