using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah.classes
{
    class Login
    {
        public Login()
        {
            
        }
        public bool userPassed(string userName, string password)
        {

            bool result = false;
            
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "select password FROM [admin] WHERE userName='"+userName+"' AND password='"+password+"'";
                try { 
                    object admin = DataAccess.objCommand.ExecuteScalar(); 
                    if (admin != DBNull.Value)
                    {
                        if(password.Equals(admin.ToString()))result=true;
                    }
                }
                catch{ }
               
            }
            DataAccess.disconnect();
            return result;
        }
    }

}
