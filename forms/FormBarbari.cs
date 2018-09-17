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
using ModiriatForoushgah;
namespace ModiriatForoushgah.forms
{
    public partial class FormBarbari : Form
    {

        SqlConnection objConnection;
        SqlDataAdapter objDataAdapter;
        DataSet objDataSet;
        int id;
        string name, address, telephoneSabet, tozihat;
        Barbari barbari;

        public FormBarbari()
        {
            InitializeComponent();
        }

        private void FormBarbari_Load(object sender, EventArgs e)
        {
            showData();
        }


        void showData()
        {
            dataGridView1.Columns.Clear();

            objConnection = new SqlConnection(DataAccess.connectionString);
            objDataAdapter = new SqlDataAdapter();
            objDataSet = new DataSet();
            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT * FROM [barbari]";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            // Open the database connection... 
            objConnection.Open();
            // Fill the DataSet object with data... 
            objDataAdapter.Fill(objDataSet, "barbari");
            // Close the database connection... 
            objConnection.Close();
            dataGridView1.AutoGenerateColumns = true;

            // Set the DataGridView properties // to bind it to our data... 
            dataGridView1.DataSource = objDataSet;


            dataGridView1.DataMember = "barbari";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "نام باربری";
            dataGridView1.Columns[2].HeaderText = "آدرس";
            dataGridView1.Columns[3].HeaderText = "تلفن";
            dataGridView1.Columns[4].HeaderText = "توضیحات";


            DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
            objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;
            // Declare and set the style for currency cells ...
            DataGridViewCellStyle objCurrencyCellStyle = new DataGridViewCellStyle();
            //   objCurrencyCellStyle.Format = "c";
            objCurrencyCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].HeaderCell.Style = objAlignRightCellStyle;
            dataGridView1.Columns[0].DefaultCellStyle = objCurrencyCellStyle;

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




        private void btn_add_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (!error && (txt_name.Text == ""))
            {
                MessageBox.Show("فیلد ها را پر کنید");
                error = true;
            }
            if (!error)
            {
                name = txt_name.Text;
                tozihat = txt_details.Text;
                telephoneSabet = txt_tel.Text;
                address = txt_adress.Text;
                
                barbari = new Barbari();
                barbari.add(name, address, telephoneSabet, tozihat);
                showData();
                txt_name.Text = "";
                txt_details.Text = "";
       
                txt_tel.Text = "";

                txt_adress.Text = "";
            }

        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            bool error = false;
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    if (!error && (txt_name.Text == ""))
                    {
                        MessageBox.Show("فیلد ها را پر کنید");
                        error = true;
                    }
                    if (!error)
                    {
                        barbari = new Barbari();
                        id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        name = txt_name.Text;
                        tozihat = txt_details.Text;
                        telephoneSabet = txt_tel.Text;
                        address = txt_adress.Text;
                        barbari.update(id, name, address, telephoneSabet, tozihat);
                        showData();
                        txt_name.Text = "";
                        txt_details.Text = "";

                        txt_tel.Text = "";

                        txt_adress.Text = "";
                    }

                }
                else MessageBox.Show("یک سطر را انتخاب کنید ");
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
                int result = Convert.ToInt32(MessageBox.Show("آیا  مطمئن هستید", "توجه", MessageBoxButtons.YesNo));
                try
                {
                    if (result == 6)
                    {
                        barbari = new Barbari();
                        while (count != 0)
                        {
                            id = Int32.Parse(dataGridView1.SelectedRows[--count].Cells[0].Value.ToString());
                            barbari.delete(id);
                        }
                        showData();
                        txt_name.Text = "";
                        txt_details.Text = "";

                        txt_tel.Text = "";

                        txt_adress.Text = "";
                    }

                }
                catch { MessageBox.Show("خطا در حذف "); }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_adress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_tel.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_details.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch { }
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
