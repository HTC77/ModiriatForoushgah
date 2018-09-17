using ModiriatForoushgah.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ModiriatForoushgah.forms.forms_user
{
    public partial class FormLogin : Form
    {
        SqlConnection objConnection;
        SqlDataAdapter objDataAdapter;
        DataSet objDataSet;
        DataView objDataView;
        CurrencyManager objCurrencyManager;


        public FormLogin()
        {

            objConnection = new SqlConnection(DataAccess.connectionString);

            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {   
            
            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [admin] ", objConnection);
            objDataAdapter.Fill(objDataSet, "admin");
            objDataView = new DataView(objDataSet.Tables["admin"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                label3.DataBindings.Add("Text", objDataView, "userName");
               // label4.DataBindings.Add("Text", objDataView, "password");
                cmb_user.Items.Add(label3.Text);
                label3.DataBindings.Clear();
                label4.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }
            label3.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string userName=cmb_user.SelectedItem.ToString();
            string password =txt_password.Text;
            Login login =new Login();

            if (login.userPassed(userName, password))
            {
                //this.Dispose();
                new FormMain().Show();
                
            }
            else {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است");
            }

        }



    }
}
