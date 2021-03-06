﻿using ModiriatForoushgah.classes;
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
    public partial class FormRanande : Form
    {
         SqlConnection objConnection;
        SqlDataAdapter objDataAdapter;
        DataSet objDataSet;


        int id=1;
        string nameKamiun, tozihat;
        string name, lastName, shomareShenasname, birthday, gender, email, telephoneSabet, telephoneHamrah, address;

        Ranande ranande;
 

        public FormRanande()
        {
            InitializeComponent();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            bool error = false;

            try
            {
                gender = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("جنسیت را درست وارد کنید");
                error = true;

            }

 
            if (!error && (txt_name.Text == "" || txt_family.Text == ""))
            {
                MessageBox.Show("فیلد ها را پر کنید");
                error = true;
            }
            if (!error)
            {
                name = txt_name.Text;
                lastName = txt_family.Text;
                shomareShenasname = txt_shomareShenasname.Text;
                birthday = txt_birthday.Text;
                email = txt_email.Text;
                telephoneSabet = txt_tel.Text;
                telephoneHamrah = txt_mobile.Text;
                address = txt_adress.Text;

                nameKamiun = txt_nameKamiun.Text;
                tozihat = txt_tozihat.Text;
                ranande = new Ranande();
                ranande.add(name, lastName, shomareShenasname, birthday, gender, email, telephoneSabet, telephoneHamrah, nameKamiun, tozihat, address);
                showData();
                txt_name.Text = "";
                txt_family.Text = "";
                txt_shomareShenasname.Text = "";
                txt_birthday.Text = "";
                txt_email.Text = "";
                txt_tel.Text = "";
                txt_mobile.Text = "";
                txt_nameKamiun.Text = "";
                txt_tozihat.Text = "";
                txt_adress.Text = "";
            }

        }

        private void FormRanande_Load(object sender, EventArgs e)
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
            objDataAdapter.SelectCommand.CommandText = "SELECT [user].id,name,lastName,shomareShenasname,birthday,gender,email,telephoneSabet,telephoneHamrah,address,nameKamiun,tozihat FROM [user] JOIN [ranande] ON [user].id = [ranande].userId";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            // Open the database connection... 
            objConnection.Open();
            // Fill the DataSet object with data... 
            objDataAdapter.Fill(objDataSet, "users");
            // Close the database connection... 
            objConnection.Close();
            dataGridView1.AutoGenerateColumns = true;

            // Set the DataGridView properties // to bind it to our data... 
            dataGridView1.DataSource = objDataSet;


            dataGridView1.DataMember = "users";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "نام";
            dataGridView1.Columns[2].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[3].HeaderText = "شماره شناسنامه";
            dataGridView1.Columns[4].HeaderText = "تاریخ تولد";
            dataGridView1.Columns[5].HeaderText = "جنسیت";
            dataGridView1.Columns[7].HeaderText = "تلفن ثابت";
            dataGridView1.Columns[8].HeaderText = "تلفن همراه";
            dataGridView1.Columns[9].HeaderText = "آدرس";
            dataGridView1.Columns[10].HeaderText = "نام کامیون";
            dataGridView1.Columns[11].HeaderText = "توضیحات";





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
            bool error = false;
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    try
                    {
                        gender = comboBox1.SelectedItem.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("جنسیت را درست وارد کنید");
                        error = true;

                    }

                    if (txt_nameKamiun.Text == "") txt_nameKamiun.Text = txt_email.Text; ;
                    

                    if (!error && (txt_name.Text == "" || txt_family.Text == ""))
                    {
                        MessageBox.Show("فیلد ها را پر کنید");
                        error = true;
                    }
                    if (!error)
                    {
                        ranande = new Ranande();
                        id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        name = txt_name.Text;
                        lastName = txt_family.Text;
                        shomareShenasname = txt_shomareShenasname.Text;
                        birthday = txt_birthday.Text;
                        email = txt_email.Text;
                        telephoneSabet = txt_tel.Text;
                        telephoneHamrah = txt_mobile.Text;
                        address = txt_adress.Text;

                        nameKamiun = txt_nameKamiun.Text;
                        tozihat = txt_tozihat.Text;
                        ranande.update(id, name, lastName, shomareShenasname, birthday, gender, email, telephoneSabet, telephoneHamrah, nameKamiun, tozihat, address);
                        showData();
                        txt_name.Text = "";
                        txt_family.Text = "";
                        txt_shomareShenasname.Text = "";
                        txt_birthday.Text = "";
                        txt_email.Text = "";
                        txt_tel.Text = "";
                        txt_mobile.Text = "";
                        txt_nameKamiun.Text = "";
                        txt_tozihat.Text = "";
                        txt_adress.Text = "";
                    }

                }
                else MessageBox.Show("یک سطر را انتخاب کنید ");
            }
            catch { MessageBox.Show("اطلاعات را به طور دقیق وارد کنید "); }
        }


        private void dataGridView1_SelectionChanged(object sender, DataGridViewCellMouseEventArgs e)
        {
           
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
                        ranande = new Ranande();
                        while (count != 0)
                        {
                            id = Int32.Parse(dataGridView1.SelectedRows[--count].Cells[0].Value.ToString());
                            ranande.delete(id);
                        }
                        showData();
                        txt_name.Text = "";
                        txt_family.Text = "";
                        txt_shomareShenasname.Text = "";
                        txt_birthday.Text = "";
                        txt_email.Text = "";
                        txt_tel.Text = "";
                        txt_mobile.Text = "";
                        txt_nameKamiun.Text = "";
                        txt_tozihat.Text = "";
                        txt_adress.Text = "";
                    }

                }
                catch { MessageBox.Show("خطا در حذف "); }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_family.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_shomareShenasname.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_birthday.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txt_email.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txt_mobile.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txt_tel.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txt_adress.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                txt_nameKamiun.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                txt_tozihat.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();

            }
            catch { }
        }
    }
}
