using ModiriatForoushgah.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah.forms.forms_kala
{
    partial class FormCategory : Form
    {
        public FormCategory()
        {
            InitializeComponent();
        }



        #region   category
        SqlConnection objConnection;
        SqlDataAdapter objDataAdapter;
        DataSet objDataSet;


        int id = 1;
        string name;

        Category category;

        private void btn_add_Click(object sender, EventArgs e)
        {
            name = txt_name.Text;
            category = new Category();
            category.add(name);
            showData();
            txt_name.Text = "";
        }






        public void showData()
        {
            dataGridView1.Columns.Clear();

            objConnection = new SqlConnection(DataAccess.connectionString);
            objDataAdapter = new SqlDataAdapter();
            objDataSet = new DataSet();
            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT * FROM [category]";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            // Open the database connection... 
            objConnection.Open();
            // Fill the DataSet object with data... 
            objDataAdapter.Fill(objDataSet, "category");
            // Close the database connection... 
            objConnection.Close();
            dataGridView1.AutoGenerateColumns = true;

            // Set the DataGridView properties // to bind it to our data... 
            dataGridView1.DataSource = objDataSet;


            dataGridView1.DataMember = "category";
            dataGridView1.Columns[0].HeaderText = "کد دسته بندی";
            dataGridView1.Columns[1].HeaderText = "نام دسته بندی";






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


        private void btn_update_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
            category = new Category();
            id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            name = txt_name.Text;
            category.update(id, name);
            txt_name.Text = "";
            showData();
             }
            else
            {
                MessageBox.Show("یک سطر انتخاب کنید ");
            }
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
                        category = new Category();
                        while (count != 0)
                        {
                            id = Int32.Parse(dataGridView1.SelectedRows[--count].Cells[0].Value.ToString());
                            category.delete(id);
                        }
                        showData();
                        txt_name.Text = "";
                    }

                }
                catch { MessageBox.Show("خطا در حذف "); }
            }
            else
            {
                MessageBox.Show("یک سطر انتخاب کنید ");
            }
        }


        private void FormCategory_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            }
            catch { }
        }

        #endregion

        private void FormCategory_Leave(object sender, EventArgs e)
        {
            
        }

     
    }
}
