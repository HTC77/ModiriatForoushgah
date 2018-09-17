using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModiriatForoushgah;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ModiriatForoushgah.classes
{
    class Ranande
    {
        private int getId()
        {
            int id = 1;

            DataAccess.objCommand.CommandText = "select MAX(id) FROM [user]";
            object maxId = DataAccess.objCommand.ExecuteScalar();
            if (maxId != DBNull.Value)
            {
                id += Int32.Parse(maxId.ToString());
            }
            return id;
        }
        public void add(string name, string lastName, string shomareShenasname, string birthday, string gender, string email, string telephoneSabet, string telephoneHamrah, string nameKamiun, string tozihat, string address)
        {


            if (DataAccess.connect())
            {
                int id = getId();
                DataAccess.objCommand.CommandText = "insert into [user] (id,name,lastName, shomareShenasname, birthday,gender,email,telephoneSabet,telephoneHamrah,address,accessLevel) VALUES(@id,@name,@lastName,@shomarehShenasname,@birthday,@gender,@email,@telephoneSabet,@telephoneHamrah,@address,@accessLevel) insert into [ranande] (userId,nameKamiun,  tozihat) VALUES(@userId,@nameKamiun,@tozihat)";
                DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@name", name);
                DataAccess.addValue("@lastName", lastName);
                DataAccess.addValue("@shomarehShenasname", shomareShenasname);
                DataAccess.addValue("@birthday", birthday);
                DataAccess.addValue("@gender", gender);
                DataAccess.addValue("@email", email);
                DataAccess.addValue("@telephoneSabet", telephoneSabet);
                DataAccess.addValue("@telephoneHamrah", telephoneHamrah);
                DataAccess.addValue("@address", address);
                DataAccess.addValue("@accessLevel", "Ranande");
                DataAccess.addValue("@userId", id.ToString());
                DataAccess.addValue("@nameKamiun", nameKamiun);
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


        public void update(int id, string name, string lastName, string shomareShenasname, string birthday, string gender, string email, string telephoneSabet, string telephoneHamrah, string nameKamiun, string tozihat, string address)
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "update [user] set name=@name,lastName=@lastName, shomareShenasname=@shomarehShenasname, birthday=@birthday,gender=@gender,email=@email,telephoneSabet=@telephoneSabet,telephoneHamrah=@telephoneHamrah,address=@address WHERE id=@id UPDATE [ranande] SET nameKamiun=@nameKamiun,  tozihat=@tozihat  WHERE userId=@userId";
                DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@name", name);
                DataAccess.addValue("@lastName", lastName);
                DataAccess.addValue("@shomarehShenasname", shomareShenasname);
                DataAccess.addValue("@birthday", birthday);
                DataAccess.addValue("@gender", gender);
                DataAccess.addValue("@email", email);
                DataAccess.addValue("@telephoneSabet", telephoneSabet);
                DataAccess.addValue("@telephoneHamrah", telephoneHamrah);
                DataAccess.addValue("@address", address);
                DataAccess.addValue("@userId", id.ToString());
                DataAccess.addValue("@nameKamiun", nameKamiun);
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

        internal void delete(int id)
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "DELETE FROM [user] WHERE id=@id";
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
