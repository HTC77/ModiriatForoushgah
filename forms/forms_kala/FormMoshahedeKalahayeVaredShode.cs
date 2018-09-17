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
namespace ModiriatForoushgah.forms.forms_kala
{
    public partial class FormMoshahedeKalahayeVaredShode : Form
    {
        public FormMoshahedeKalahayeVaredShode()
        {
            InitializeComponent();
        }
        SqlConnection objConnection;
        SqlDataAdapter objDataAdapter;
        DataSet objDataSet;
        DataView objDataView;
        CurrencyManager objCurrencyManager;

        private void FormMoshahedeKalahayeVaredShode_Load(object sender, EventArgs e)
        {
            bindFields();
            showData();
        }


        public void bindFields()
        {
            objConnection = new SqlConnection(DataAccess.connectionString);
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [category] ", objConnection);
            objDataSet = new DataSet();
            objDataAdapter.Fill(objDataSet, "cats");
            objDataView = new DataView(objDataSet.Tables["cats"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);
            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                
                txt_price.DataBindings.Add("Text", objDataView, "id");
                txt_name.DataBindings.Add("Text", objDataView, "name");
                comboBox1.Items.Add(txt_price.Text + "-" + txt_name.Text);
                txt_price.DataBindings.Clear();
                txt_name.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }

            objConnection = new SqlConnection(DataAccess.connectionString);
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [user]  WHERE accessLevel='TaminKonande'", objConnection);
            objDataSet = new DataSet();
            objDataAdapter.Fill(objDataSet, "TaminKonande");
            objDataView = new DataView(objDataSet.Tables["TaminKonande"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                txt_price.DataBindings.Add("Text", objDataView, "id");
                txt_name.DataBindings.Add("Text", objDataView, "name");
                txt_factor.DataBindings.Add("Text", objDataView, "lastName");
                comboBox2.Items.Add(txt_price.Text + "-" + txt_name.Text + " " + txt_factor.Text);
                txt_price.DataBindings.Clear();
                txt_name.DataBindings.Clear();
                txt_factor.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }
            txt_name.Text = "";
            txt_price.Text = "";
            txt_factor.Text = "";


        }
        public void showData()
        {
            dataGridView1.Columns.Clear();

            objConnection = new SqlConnection(DataAccess.connectionString);
            objDataAdapter = new SqlDataAdapter();
            objDataSet = new DataSet();
            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT [factorKalahayeVaredShode].id,serialFactor,[factorKalahayeVaredShode].name,[category].id,[category].name,tarikhSakht,tarikhEngheza,price,tedad,[kalahayeVaredShode].bedehkar,[kalahayeVaredShode].bestankar,[kalahayeVaredShode].tozihat,[user].id,[user].name,[user].lastName,tarikh,vazeiat FROM [factorKalahayeVaredShode] JOIN [category] ON [factorKalahayeVaredShode].type = [category].id    JOIN [kalahayeVaredShode] ON [factorKalahayeVaredShode].id = [kalahayeVaredShode].codeFactor JOIN [taminKonande] ON [kalahayeVaredShode].codeTaminKonande = [taminKonande].userId   JOIN [user] ON [user].id = [taminKonande].userId";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            // Open the database connection... 
            objConnection.Open();
            // Fill the DataSet object with data... 
            objDataAdapter.Fill(objDataSet, "factor");
            // Close the database connection... 
            objConnection.Close();
            dataGridView1.AutoGenerateColumns = true;

            // Set the DataGridView properties // to bind it to our data... 
            dataGridView1.DataSource = objDataSet;


            dataGridView1.DataMember = "factor";
            dataGridView1.Columns[0].Visible = false;//id
            dataGridView1.Columns[1].HeaderText = "سریال فاکتور";
            dataGridView1.Columns[2].HeaderText = "نام کالا";
            dataGridView1.Columns[3].Visible = false;//type.id
            dataGridView1.Columns[4].HeaderText = "نوع کالا";
            dataGridView1.Columns[5].HeaderText = "تاریخ ساخت";
            dataGridView1.Columns[6].HeaderText = "تاریخ انقضاء";
            dataGridView1.Columns[7].HeaderText = "قیمت خرید";
            dataGridView1.Columns[8].HeaderText = "تعداد";
            dataGridView1.Columns[9].HeaderText = "بدهکار";
            dataGridView1.Columns[10].HeaderText = "بستانکار";
            dataGridView1.Columns[11].HeaderText = "توضیحات";
            dataGridView1.Columns[12].Visible = false;//taminKnande.id
            dataGridView1.Columns[13].HeaderText = "نام تأمین کننده";
            dataGridView1.Columns[14].Visible = false;//taminKonande.lastName
            dataGridView1.Columns[15].HeaderText = "تاریخ";
            dataGridView1.Columns[16].HeaderText = "وضعیت";

            int length = dataGridView1.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                var t = dataGridView1.Rows[i].Cells[13].Value + " ";
                t += dataGridView1.Rows[i].Cells[14].Value;
                dataGridView1.Rows[i].Cells[13].Value = t;
            }






            DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
            objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;
            DataGridViewCellStyle objCurrencyCellStyle = new DataGridViewCellStyle();
            objCurrencyCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Clean up
            objDataAdapter = null;
            objConnection = null;
            objDataSet = null;
            objCurrencyCellStyle = null;
            objAlternatingCellStyle = null;
            objAlignRightCellStyle = null;
        }


        public void showResult()
        {
            string id1="0";
            string id2 ="0";
            dataGridView1.Columns.Clear();
            if (comboBox1.SelectedIndex != -1) id1 = comboBox1.SelectedItem.ToString().Substring(0, comboBox1.SelectedItem.ToString().IndexOf('-'));
            if (comboBox2.SelectedIndex != -1) id2 = comboBox2.SelectedItem.ToString().Substring(0, comboBox2.SelectedItem.ToString().IndexOf('-'));

            objConnection = new SqlConnection(DataAccess.connectionString);
            objDataAdapter = new SqlDataAdapter();
            objDataSet = new DataSet();
            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            
            objDataAdapter.SelectCommand.CommandText = "SELECT [factorKalahayeVaredShode].id,serialFactor,[factorKalahayeVaredShode].name,[category].id,[category].name,tarikhSakht,tarikhEngheza,price,tedad,[kalahayeVaredShode].bedehkar,[kalahayeVaredShode].bestankar,[kalahayeVaredShode].tozihat,[user].id,[user].name,[user].lastName,tarikh,vazeiat FROM [factorKalahayeVaredShode] JOIN [category] ON [factorKalahayeVaredShode].type = [category].id    JOIN [kalahayeVaredShode] ON [factorKalahayeVaredShode].id = [kalahayeVaredShode].codeFactor JOIN [taminKonande] ON [kalahayeVaredShode].codeTaminKonande = [taminKonande].userId   JOIN [user] ON [user].id = [taminKonande].userId  WHERE [factorKalahayeVaredShode].name LIKE'%" + txt_name+"%' OR [factorKalahayeVaredShode].type LIKE'%"+id1+"%' OR [kalahayeVaredShode].codeTaminKonande LIKE'%"+id2+"%'";
            //if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex == -1) objDataAdapter.SelectCommand.CommandText = "SELECT [factorKalahayeVaredShode].id,serialFactor,[factorKalahayeVaredShode].name,[category].id,[category].name,tarikhSakht,tarikhEngheza,price,tedad,[kalahayeVaredShode].bedehkar,[kalahayeVaredShode].bestankar,[kalahayeVaredShode].tozihat,[user].id,[user].name,[user].lastName,tarikh,vazeiat FROM [factorKalahayeVaredShode] JOIN [category] ON [factorKalahayeVaredShode].type = [category].id    JOIN [kalahayeVaredShode] ON [factorKalahayeVaredShode].id = [kalahayeVaredShode].codeFactor JOIN [taminKonande] ON [kalahayeVaredShode].codeTaminKonande = [taminKonande].userId   JOIN [user] ON [user].id = [taminKonande].userId  WHERE [factorKalahayeVaredShode].name ='" + txt_name + "and [factorKalahayeVaredShode].type=" + comboBox1.SelectedItem.ToString().Substring(0, comboBox1.SelectedItem.ToString().IndexOf('-'));
            //if (comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex != -1) objDataAdapter.SelectCommand.CommandText = "SELECT [factorKalahayeVaredShode].id,serialFactor,[factorKalahayeVaredShode].name,[category].id,[category].name,tarikhSakht,tarikhEngheza,price,tedad,[kalahayeVaredShode].bedehkar,[kalahayeVaredShode].bestankar,[kalahayeVaredShode].tozihat,[user].id,[user].name,[user].lastName,tarikh,vazeiat FROM [factorKalahayeVaredShode] JOIN [category] ON [factorKalahayeVaredShode].type = [category].id    JOIN [kalahayeVaredShode] ON [factorKalahayeVaredShode].id = [kalahayeVaredShode].codeFactor JOIN [taminKonande] ON [kalahayeVaredShode].codeTaminKonande = [taminKonande].userId   JOIN [user] ON [user].id = [taminKonande].userId  WHERE [factorKalahayeVaredShode].name ='" + txt_name + "and [kalahayeVaredShode].codeTaminKonande=" + comboBox2.SelectedItem.ToString().Substring(0, comboBox2.SelectedItem.ToString().IndexOf('-'));

            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            // Open the database connection... 
            objConnection.Open();
            // Fill the DataSet object with data... 
            objDataAdapter.Fill(objDataSet, "factor");
            // Close the database connection... 
            objConnection.Close();
            dataGridView1.AutoGenerateColumns = true;

            // Set the DataGridView properties // to bind it to our data... 
            dataGridView1.DataSource = objDataSet;


            dataGridView1.DataMember = "factor";
            dataGridView1.Columns[0].Visible = false;//id
            dataGridView1.Columns[1].HeaderText = "سریال فاکتور";
            dataGridView1.Columns[2].HeaderText = "نام کالا";
            dataGridView1.Columns[3].Visible = false;//type.id
            dataGridView1.Columns[4].HeaderText = "نوع کالا";
            dataGridView1.Columns[5].HeaderText = "تاریخ ساخت";
            dataGridView1.Columns[6].HeaderText = "تاریخ انقضاء";
            dataGridView1.Columns[7].HeaderText = "قیمت خرید";
            dataGridView1.Columns[8].HeaderText = "تعداد";
            dataGridView1.Columns[9].HeaderText = "بدهکار";
            dataGridView1.Columns[10].HeaderText = "بستانکار";
            dataGridView1.Columns[11].HeaderText = "توضیحات";
            dataGridView1.Columns[12].Visible = false;//taminKnande.id
            dataGridView1.Columns[13].HeaderText = "نام تأمین کننده";
            dataGridView1.Columns[14].Visible = false;//taminKonande.lastName
            dataGridView1.Columns[15].HeaderText = "تاریخ";
            dataGridView1.Columns[16].HeaderText = "وضعیت";

            int length = dataGridView1.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                var t = dataGridView1.Rows[i].Cells[13].Value + " ";
                t += dataGridView1.Rows[i].Cells[14].Value;
                dataGridView1.Rows[i].Cells[13].Value = t;
            }






            DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
            objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;
            DataGridViewCellStyle objCurrencyCellStyle = new DataGridViewCellStyle();
            objCurrencyCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Clean up
            objDataAdapter = null;
            objConnection = null;
            objDataSet = null;
            objCurrencyCellStyle = null;
            objAlternatingCellStyle = null;
            objAlignRightCellStyle = null;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            showResult();
        }

    }
}
