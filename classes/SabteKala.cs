using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah.classes
{
    class SabteKala
    {
        private int getId()
        {
            int id = 1;

            DataAccess.objCommand.CommandText = "select MAX(id) FROM [factorKalahayeVaredShode]";
            object maxId = DataAccess.objCommand.ExecuteScalar();
            if (maxId != DBNull.Value)
            {
                id += Int32.Parse(maxId.ToString());
            }
            else
            {
                id = 10000;
            }
            return id;
        }

        private int getId2()
        {
            int id = 1;

            DataAccess.objCommand.CommandText = "select MAX(id) FROM [kala]";
            object maxId = DataAccess.objCommand.ExecuteScalar();
            if (maxId != DBNull.Value)
            {
                id += Int32.Parse(maxId.ToString());
            }
            else
            {
                id = 10000;
            }
            return id;
        }

        public void add(string serial, string name, string type, string tarikhSakht, string tarikhEngheza, string price, string tedad, string bedehkar, string bestankar, string tozihat, string codeTaminKonande, string tarikh, string vazeiat)
        {
            if (DataAccess.connect())
            {
                int id = getId();
                serial = id + serial;
                DataAccess.objCommand.CommandText = "insert into [factorKalahayeVaredShode] (id,serialFactor,name,type,tarikhSakht,tarikhEngheza,price,tedad) VALUES(@id,@name,@type,@tarikhSakht,@tarikhEngheza,@price,@tedad)  insert into [kalahayeVaredShode] (codeFactor,bedehkar,bestankar,tozihat,codeTaminKonande,tarikh,vazeiat) VALUES(@codeFactor,@bedehkar,@bestankar,@tozihat,@codeTaminKonande,@tarikh,@vazeiat)";
                 DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@serialFactor", serial);
                DataAccess.addValue("@name", name);
                DataAccess.addValue("@type", type);
                DataAccess.addValue("@tarikhSakht", tarikhSakht);
                DataAccess.addValue("@tarikhEngheza", tarikhEngheza);
                DataAccess.addValue("@price", price);
                DataAccess.addValue("@tedad", tedad);
               
                DataAccess.addValue("@codeFactor", id.ToString());
                DataAccess.addValue("@bedehkar", bedehkar);
                DataAccess.addValue("@bestankar", bestankar);
                DataAccess.addValue("@tozihat", tozihat);
                DataAccess.addValue("@codeTaminKonande", codeTaminKonande);
                DataAccess.addValue("@tarikh", tarikh);
                DataAccess.addValue("@vazeiat", vazeiat);
                try
                {
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
               
            } DataAccess.disconnect();
        }

        public void add(int factorId,string name, string type, string tarikhSakht, string tarikhEngheza, string price,string tozihat, string tedad, string tarikh)
        {
            bool error = false;
              if (DataAccess.connect())
            {

                int id = getId2();
                DataAccess.objCommand.CommandText = "insert into [kala] (id,name,type,tarikhSakht,tarikhEngheza,price,tozihat) VALUES(@id,@name,@type,@tarikhSakht,@tarikhEngheza,@price,@tozihat)  insert into [anbar] (codeKala,mojudiAnbar,mojudiForooshgah,kasriForooshgah,tarikh) VALUES(@codeKala,@mojudiAnbar,@mojudiForooshgah,@kasriForooshgah,@tarikh)";
                DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@name", name);
                DataAccess.addValue("@type", type);
                DataAccess.addValue("@tarikhSakht", tarikhSakht);
                DataAccess.addValue("@tarikhEngheza", tarikhEngheza);
                DataAccess.addValue("@price", price);
                DataAccess.addValue("@tozihat", tozihat);

                DataAccess.addValue("@codeKala", id.ToString());
                DataAccess.addValue("@mojudiAnbar", tedad);
                DataAccess.addValue("@mojudiForooshgah", "0");
                DataAccess.addValue("@kasriForooshgah", "0");
                DataAccess.addValue("@tarikh", tarikh);
                try
                {
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    error = true;
                    MessageBox.Show(e.Message);
                }

                if (error==false)
                {
                    delete(factorId);
                }
               
            } DataAccess.disconnect();
        }

        
    
        public void update(int id,string serial, string name, string type, string tarikhSakht, string tarikhEngheza, string price, string tedad, string bedehkar, string bestankar, string tozihat, string codeTaminKonande, string tarikh, string vazeiat)
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "update [factorKalahayeVaredShode] set serialFactor=@serialFactor,name=@name, type=@type, tarikhSakht=@tarikhSakht, tarikhEngheza=@tarikhEngheza, price=@price,tedad=@tedad WHERE id=@id  UPDATE [kalahayeVaredShode] SET codeFactor=@codeFactor,bedehkar=@bedehkar,bestankar=@bestankar,tozihat=@tozihat,codeTaminKonande=@codeTaminKonande,tarikh=@tarikh,vazeiat=@vazeiat  WHERE codeFactor=@codeFactor";
                DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@serialFactor", serial);
                DataAccess.addValue("@name", name);
                DataAccess.addValue("@type", type);
                DataAccess.addValue("@tarikhSakht", tarikhSakht);
                DataAccess.addValue("@tarikhEngheza", tarikhEngheza);
                DataAccess.addValue("@price", price);
                DataAccess.addValue("@tedad", tedad);
               
                DataAccess.addValue("@codeFactor", id.ToString());
                DataAccess.addValue("@bedehkar", bedehkar);
                DataAccess.addValue("@bestankar", bestankar);
                DataAccess.addValue("@tozihat", tozihat);
                DataAccess.addValue("@codeTaminKonande", codeTaminKonande);
                DataAccess.addValue("@tarikh", tarikh);
                DataAccess.addValue("@vazeiat", vazeiat);
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

        public void delete(int id)
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "DELETE FROM [factorKalahayeVaredShode] WHERE id=@id";
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
