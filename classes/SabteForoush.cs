using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah.classes
{
    class SabteForoush
    {
        private int getId()
        {
            int id = 1;

            DataAccess.objCommand.CommandText = "select MAX(id) FROM [factorForoush]";
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

            DataAccess.objCommand.CommandText = "select MAX(id) FROM [sefaresh]";
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
    
        public void add(string serial,string tozihat, string barbari, string ranande, string kala, string tarikh, string vazeiat, string tedad,  string price, string moshtari, string bedehkar, string bestankar)
        {
            bool error = false;
            if (DataAccess.connect())
            {   
                int id = getId();
                serial = id + serial;
                DataAccess.objCommand.CommandText = "insert into [factorForoush] (id,serialFactor,tozihat,codeBarbari,codeRanandeh) VALUES(@id,@serialFactor,@tozihat,@codeBarbari,@codeRanandeh) insert into [sefaresh] (id,codeKala,tarikh,vazeiateSefaresh,tedad,codeFactor,price) VALUES(@id2,@codeKala,@tarikh,@vazeiateSefaresh,@tedad,@codeFactor,@price)";
                DataAccess.addValue("@id", id.ToString());
                DataAccess.addValue("@serialFactor", serial);
                DataAccess.addValue("@tozihat", tozihat);
                DataAccess.addValue("@codeBarbari", barbari);
                DataAccess.addValue("@codeRanandeh", ranande);
                int id2 = getId2();
                DataAccess.addValue("@id2", id2.ToString());
                DataAccess.addValue("@codeKala", kala);
                DataAccess.addValue("@tarikh", tarikh);
                DataAccess.addValue("@vazeiateSefaresh", vazeiat);
                DataAccess.addValue("@tedad", tedad);
                DataAccess.addValue("@codeFactor", id.ToString());
                DataAccess.addValue("@price", price);
                
              
                try
                {
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    error = true;

                    MessageBox.Show(e.Message);
                }




                DataAccess.objCommand.CommandText = "update [moshtari] set bedehkar=@bedehkar,bestankar=@bestankar WHERE userId=@moshtariId";
                DataAccess.addValue("@moshtariId", moshtari);
                DataAccess.addValue("@bedehkar", bedehkar);
                DataAccess.addValue("@bestankar", bestankar);
                try
                {
                    DataAccess.objCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    error = true;

                    MessageBox.Show(e.Message);
                }



            } DataAccess.disconnect();
            
            if (!error)
            {
                MessageBox.Show("فاکتور با موفقیت ثبت شد");
            }
            else
            {
                MessageBox.Show("خطا در ثبت فاکتور");
            }

        }
    }
}
