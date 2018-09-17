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
    public partial class FormSabteKala : Form
    {

        public FormSabteKala()
        {
            InitializeComponent();
        }

        #region   sabteKala
        SqlConnection objConnection;
        SqlDataAdapter objDataAdapter;
        DataSet objDataSet;
        DataView objDataView;
        CurrencyManager objCurrencyManager; 

        int id = 1;
        string serial,name,type,tarikhSakht,tarikhEngheza,price,tozihat,tedad,bedehkar,bestankar,tarikh,codeTaminKonande,vazeiat;
        SabteKala sabteKala;

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool error = false;
            try
            {
                 type= comboBox1.SelectedItem.ToString();
                 type = type.Substring(0, type.IndexOf('-'));
            }
            catch
            {
                MessageBox.Show("نوع کالا را انتخاب کنید");
                error = true;
            }
               if (!error)
            {
                try
                {
                 codeTaminKonande=comboBox2.SelectedItem.ToString();
                 codeTaminKonande = codeTaminKonande.Substring(0, codeTaminKonande.IndexOf('-'));
                }
                catch
                {
                    MessageBox.Show("تأمین کننده را انتخاب کنید");
                    error = true;
                }
            }
            try
            {
                long test ;
                if (txt_bedehkar.Text == "" || txt_bedehkar.Text == null) txt_bedehkar.Text = "0";
                if(txt_bestankar.Text=="" || txt_bestankar.Text==null) txt_bestankar.Text="0";
                test= long.Parse(txt_bedehkar.Text);
                test = long.Parse(txt_bestankar.Text);
            }
            catch
            {
                MessageBox.Show("مبلغ بدهکار و بستانکار را درست وارد کنید");
                error = true;
            }
            if (!error && (txt_name.Text == "" || txt_price.Text == ""))
            {
                MessageBox.Show("فیلد ها را پر کنید");
                error = true;
            }
            if (!error)
            {
                try
                {
                    long test;
                    if (txt_tedad.Text == "") txt_tedad.Text = "0";
                    test = long.Parse(txt_tedad.Text);
                }
                catch
                {
                    MessageBox.Show("تعداد را درست وارد کنید");
                    error = true;
                }
            }
            if (!error)
            {
                serial = txt_factor.Text;
                name = txt_name.Text;
                tarikhSakht = txt_tarikhSakht.Text;
                tarikhEngheza = txt_tarikhEngheza.Text;
                price = txt_price.Text;
                tedad = txt_tedad.Text;
                tozihat = txt_tozihat.Text;
                bedehkar = txt_bedehkar.Text;
                bestankar = txt_bestankar.Text;
                tarikh = txt_tarikh.Text;
                vazeiat = "قیمت گذاری نشده";
                sabteKala = new SabteKala();
                sabteKala.add(serial, name, type, tarikhSakht, tarikhEngheza, price, tedad, bedehkar, bestankar, tozihat,codeTaminKonande,tarikh,vazeiat);
                showData();
                txt_name.Text = "";
                txt_tarikhSakht.Text = "";
                txt_tarikhEngheza.Text = "";
                txt_price.Text = "";
                txt_tozihat.Text = "";
                txt_tedad.Text = "";
                txt_bedehkar.Text = "";
                txt_bestankar.Text = "";
                txt_tarikh.Text = "";
                txt_factor.Text = "";
            }

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
            txt_price.DataBindings.Add("Text", objDataView,"id");
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

        int length=dataGridView1.Rows.Count;
        for (int i = 0; i < length; i++)
        {
            var t = dataGridView1.Rows[i].Cells[13].Value+" ";
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


        private void btn_update_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            if (count != 0)
            {
                sabteKala = new SabteKala();
                id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                bool error = false;
                try
                {
                    type = comboBox1.SelectedItem.ToString();
                    type = type.Substring(0, type.IndexOf('-'));
                }
                catch
                {
                    MessageBox.Show("نوع کالا را انتخاب کنید");
                    error = true;
                }
                if (!error)
                {
                    try
                    {
                        codeTaminKonande = comboBox2.SelectedItem.ToString();
                        codeTaminKonande = codeTaminKonande.Substring(0, codeTaminKonande.IndexOf('-'));
                    }
                    catch
                    {
                        MessageBox.Show("تأمین کننده را انتخاب کنید");
                        error = true;
                    }
                }
                try
                {
                    long test;
                    if (txt_bedehkar.Text == "" || txt_bedehkar.Text == null) txt_bedehkar.Text = "0";
                    if (txt_bestankar.Text == "" || txt_bestankar.Text == null) txt_bestankar.Text = "0";
                    test = long.Parse(txt_bedehkar.Text);
                    test = long.Parse(txt_bestankar.Text);
                }
                catch
                {
                    MessageBox.Show("مبلغ بدهکار و بستانکار را درست وارد کنید");
                    error = true;
                }
                if (!error)
                {
                    try
                    {
                        long test;
                        if (txt_tedad.Text == "") txt_tedad.Text = "0";
                        test = long.Parse(txt_tedad.Text);
                    }
                    catch
                    {
                        MessageBox.Show("تعداد را درست وارد کنید");
                        error = true;
                    }
                }
                if (!error && (txt_name.Text == "" || txt_price.Text == ""))
                {
                    MessageBox.Show("فیلد ها را پر کنید");
                    error = true;
                }
                if (!error)
                {
                    serial = txt_factor.Text;
                    name = txt_name.Text;
                    tarikhSakht = txt_tarikhSakht.Text;
                    tarikhEngheza = txt_tarikhEngheza.Text;
                    price = txt_price.Text;
                    tedad = txt_tedad.Text;
                    tozihat = txt_tozihat.Text;
                    bedehkar = txt_bedehkar.Text;
                    bestankar = txt_bestankar.Text;
                    tarikh = txt_tarikh.Text;
                    vazeiat = "قیمت گذاری نشده";
                    sabteKala = new SabteKala();
                    sabteKala.update(id,serial, name, type, tarikhSakht, tarikhEngheza, price, tedad, bedehkar, bestankar, tozihat, codeTaminKonande, tarikh, vazeiat);
                    showData();
                    txt_name.Text = "";
                    txt_tarikhSakht.Text = "";
                    txt_tarikhEngheza.Text = "";
                    txt_price.Text = "";
                    txt_tozihat.Text = "";
                    txt_tedad.Text = "";
                    txt_bedehkar.Text = "";
                    txt_bestankar.Text = "";
                    txt_tarikh.Text = "";
                    txt_factor.Text = "";
                }
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
                        sabteKala = new SabteKala();
                        while (count != 0)
                        {
                            id = Int32.Parse(dataGridView1.SelectedRows[--count].Cells[0].Value.ToString());
                            sabteKala.delete(id);
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


        private void FormSabteKala_Load(object sender, EventArgs e)
        {
           showData();
            bindFields();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_factor.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString() +"-"+ dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_tarikhSakht.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txt_tarikhEngheza.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString(); ;
                txt_price.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txt_tedad.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txt_bedehkar.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                txt_bestankar.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                txt_tozihat.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[12].Value.ToString() + "-" + dataGridView1.SelectedRows[0].Cells[13].Value.ToString();

                 txt_tarikh.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
            }
            catch { }
        }


        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            new FormCategory().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
