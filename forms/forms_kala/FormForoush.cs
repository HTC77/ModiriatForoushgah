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
    public partial class FormForoush : Form
    {
        int counter = 1;
        long total=0,totalPrice=0;
        string serial;
        string kala, tedad, moshtari, ranande, barbari, takhfif, bedehkar, bestankar, tozihat, tarikh,price,vazeiat;
        SqlConnection objConnection;
        SqlDataAdapter objDataAdapter;
        DataSet objDataSet;
        DataView objDataView;
        CurrencyManager objCurrencyManager;

        SabteForoush sabteForoush;
        public FormForoush()
        {
            InitializeComponent();
        }


        private void FormForoush_Load(object sender, EventArgs e)
        {

            bindFields();
        }
        public void showData()
        {
            dataGridView1.Columns.Clear();

            //objConnection = new SqlConnection(DataAccess.connectionString);
            //objDataAdapter = new SqlDataAdapter();
            //objDataSet = new DataSet();
            //objDataAdapter.SelectCommand = new SqlCommand();
            //objDataAdapter.SelectCommand.Connection = objConnection;
            //objDataAdapter.SelectCommand.CommandText = "SELECT [factorKalahayeVaredShode].id,serialFactor,[factorKalahayeVaredShode].name,[category].id,[category].name,tarikhSakht,tarikhEngheza,price,tedad,[kalahayeVaredShode].bedehkar,[kalahayeVaredShode].bestankar,[kalahayeVaredShode].tozihat,[user].id,[user].name,[user].lastName,tarikh,vazeiat FROM [factorKalahayeVaredShode] JOIN [category] ON [factorKalahayeVaredShode].type = [category].id    JOIN [kalahayeVaredShode] ON [factorKalahayeVaredShode].id = [kalahayeVaredShode].codeFactor JOIN [taminKonande] ON [kalahayeVaredShode].codeTaminKonande = [taminKonande].userId   JOIN [user] ON [user].id = [taminKonande].userId";
            //objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            //// Open the database connection... 
            //objConnection.Open();
            //// Fill the DataSet object with data... 
            //objDataAdapter.Fill(objDataSet, "factor");
            //// Close the database connection... 
            //objConnection.Close();
            dataGridView1.AutoGenerateColumns = true;

            // Set the DataGridView properties // to bind it to our data... 
            //dataGridView1.DataSource = objDataSet;

            //dataGridView1.DataMember = "factor";
           // dataGridView1.Columns[0].HeaderText = "n";
            //dataGridView1.Columns[1].HeaderText = "سریال فاکتور";
            //dataGridView1.Columns[2].HeaderText = "نام کالا";
            //dataGridView1.Columns[3].Visible = false;//type.id
            //dataGridView1.Columns[4].HeaderText = "نوع کالا";
            //dataGridView1.Columns[5].HeaderText = "تاریخ ساخت";
            //dataGridView1.Columns[6].HeaderText = "تاریخ انقضاء";
            //dataGridView1.Columns[7].HeaderText = "قیمت خرید";
            //dataGridView1.Columns[8].HeaderText = "تعداد";
            //dataGridView1.Columns[9].HeaderText = "بدهکار";
            //dataGridView1.Columns[10].HeaderText = "بستانکار";
            //dataGridView1.Columns[11].HeaderText = "توضیحات";
            //dataGridView1.Columns[12].Visible = false;//taminKnande.id
            //dataGridView1.Columns[13].HeaderText = "نام تأمین کننده";
            //dataGridView1.Columns[14].Visible = false;//taminKonande.lastName
            //dataGridView1.Columns[15].HeaderText = "تاریخ";
            //dataGridView1.Columns[16].HeaderText = "وضعیت";

            //int length = dataGridView1.Rows.Count;
            //for (int i = 0; i < length; i++)
            //{
            //    var t = dataGridView1.Rows[i].Cells[13].Value + " ";
            //    t += dataGridView1.Rows[i].Cells[14].Value;
            //    dataGridView1.Rows[i].Cells[13].Value = t;
            //}



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
     
        public void bindFields()
        {
            objConnection = new SqlConnection(DataAccess.connectionString);
            //Category
            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [category] ", objConnection);
            objDataAdapter.Fill(objDataSet, "cats");
            objDataView = new DataView(objDataSet.Tables["cats"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                txt_price.DataBindings.Add("Text", objDataView, "id");
                txt_takhfif.DataBindings.Add("Text", objDataView, "name");
                comboBox1.Items.Add(txt_price.Text + "-" + txt_takhfif.Text);
                txt_price.DataBindings.Clear();
                txt_takhfif.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }


            //Moshtari
            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [user] JOIN [moshtari] ON [moshtari].userId = [user].id", objConnection);
            objDataAdapter.Fill(objDataSet, "moshtari");
            objDataView = new DataView(objDataSet.Tables["moshtari"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                txt_price.DataBindings.Add("Text", objDataView, "id");
                txt_takhfif.DataBindings.Add("Text", objDataView, "name");
                txt_factor.DataBindings.Add("Text", objDataView, "lastName");
                comboBox4.Items.Add(txt_price.Text + "-" + txt_takhfif.Text + " " + txt_factor.Text);
                txt_price.DataBindings.Clear();
                txt_takhfif.DataBindings.Clear();
                txt_factor.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }



            //Ranande
            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [user] JOIN [ranande] ON [ranande].userId = [user].id", objConnection);
            objDataAdapter.Fill(objDataSet, "ranande");
            objDataView = new DataView(objDataSet.Tables["ranande"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                txt_price.DataBindings.Add("Text", objDataView, "id");
                txt_takhfif.DataBindings.Add("Text", objDataView, "name");
                txt_factor.DataBindings.Add("Text", objDataView, "lastName");
                comboBox2.Items.Add(txt_price.Text + "-" + txt_takhfif.Text + " " + txt_factor.Text);
                txt_price.DataBindings.Clear();
                txt_takhfif.DataBindings.Clear();
                txt_factor.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }



            //Barbari
            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [barbari] ", objConnection);
            objDataAdapter.Fill(objDataSet, "barbari");
            objDataView = new DataView(objDataSet.Tables["barbari"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                txt_price.DataBindings.Add("Text", objDataView, "id");
                txt_takhfif.DataBindings.Add("Text", objDataView, "name");
                comboBox3.Items.Add(txt_price.Text + "-" + txt_takhfif.Text);
                txt_price.DataBindings.Clear();
                txt_takhfif.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }



            txt_takhfif.Text = "0";
            txt_price.Text = "0";
            txt_factor.Text = "0";


        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_mojudi.Text = "0";
            //kala
            string id;
            id = comboBox5.SelectedItem.ToString();
            id = id.Substring(0, id.IndexOf('-'));
            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [kala] WHERE [kala].id =" + id, objConnection);
            objDataAdapter.Fill(objDataSet, "kala");
            objDataView = new DataView(objDataSet.Tables["kala"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            txt_price.DataBindings.Add("Text", objDataView, "price");

            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [anbar] WHERE codeKala =" + id, objConnection);
            objDataAdapter.Fill(objDataSet, "kala");
            objDataView = new DataView(objDataSet.Tables["kala"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);
            txt_mojudi.DataBindings.Add("Text", objDataView, "mojudiAnbar");



            txt_mojudi.DataBindings.Clear();
            txt_price.DataBindings.Clear();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            comboBox5.Text = "";
            string type;
            type= comboBox1.SelectedItem.ToString();
            type = type.Substring(0, type.IndexOf('-'));
            objDataSet = new DataSet();
            objDataAdapter = new SqlDataAdapter("SELECT * FROM [kala] WHERE [kala].type ="+type, objConnection);
            objDataAdapter.Fill(objDataSet, "kala");
            objDataView = new DataView(objDataSet.Tables["kala"]);
            objCurrencyManager = (CurrencyManager)(this.BindingContext[objDataView]);

            for (int i = 0; i < objCurrencyManager.Count; i++)
            {
                txt_price.DataBindings.Add("Text", objDataView, "id");
                txt_takhfif.DataBindings.Add("Text", objDataView, "name");
                comboBox5.Items.Add(txt_price.Text + "-" + txt_takhfif.Text);
                txt_price.DataBindings.Clear();
                txt_takhfif.DataBindings.Clear();
                objCurrencyManager.Position += 1;
            }
            txt_mojudi.Text = "0";
            txt_takhfif.Text = "0";
            txt_price.Text = "0";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool error = false;

            string kalaName;
            string typeName;
            #region Inspect
            try
            {
                kala = comboBox5.SelectedItem.ToString();
                kala = kala.Substring(0, kala.IndexOf('-'));
            }
            catch
            {
                MessageBox.Show("کالا را انتخاب کنید");
                error = true;
            }

            if (!error)
            {
                try
                {
                    long test;
                    test = long.Parse(txt_tedad.Text);

                }
                catch
                {
                    MessageBox.Show("مقادیر درست وارد کنید");
                    error = true;
                }
            }

            if (!error && (txt_tedad.Text == "" || txt_tedad.Text == "0"))
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

                long mojudi, tedad;
                mojudi = long.Parse(txt_mojudi.Text);
                tedad = long.Parse(txt_tedad.Text);
                if (tedad > mojudi)
                {
                    MessageBox.Show("تعداد درخواستی از موجودی بیشتر است");
                    error = true;
                }
                else if (tedad <= 0)
                {
                    MessageBox.Show("تعداد را درست وارد کنید");
                    error = true;
                }
            }

            int length = dataGridView1.Rows.Count;
            int kId=int.Parse(kala);
            int cell;
            if (length != 1) { 
            for (int i = 0; i < length; i++)
            {
                try
                {
                    cell = Int32.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); 
                    if (kId == cell)
                    {
                    MessageBox.Show("این کالا قبلاً انتخاب شده");
                    error = true;
                    }
                }
                catch { }
               
            }
            }
          


            #endregion
            if (!error)
            {
                kalaName = comboBox5.SelectedItem.ToString();
                kalaName = kalaName.Substring(kalaName.IndexOf('-')+1);
                typeName = comboBox1.SelectedItem.ToString();
                typeName = typeName.Substring(typeName.IndexOf('-')+1);
                price = txt_price.Text;
                tedad = txt_tedad.Text;
                dataGridView1.Rows.Add(counter,kala,kalaName,typeName,tedad,price);
                counter++;
                total += long.Parse(tedad);
                totalPrice += long.Parse(price) * long.Parse(tedad);
                txt_total.Text = total.ToString();
                txt_totalPrice.Text = totalPrice.ToString();
                comboBox5.Text = "";
                txt_tedad.Text = "";
                txt_price.Text = "";
                txt_mojudi.Text = "";
            }

           
        }//Add

        private void calcTakhfif()
        {
            this.takhfif = txt_takhfif.Text;
            long takhfif = long.Parse(this.takhfif);
            this.totalPrice = totalPrice - takhfif;
        }
        private void getBedehkar_Bestankar()
        {
            if (DataAccess.connect())
            {
                DataAccess.objCommand.CommandText = "select bedehkar FROM [moshtari] WHERE id='" + moshtari;
                try
                {
                    object objBedehkar = DataAccess.objCommand.ExecuteScalar();
                    if (objBedehkar != DBNull.Value)
                    {
                        long bedehkarl;
                        bedehkarl = long.Parse(txt_bedehkar.Text) + long.Parse(objBedehkar.ToString());
                        bedehkar = bedehkarl.ToString();
                    }
                    else
                    {
                        bedehkar = txt_bedehkar.Text;
                    }
                }
                catch { }
                DataAccess.objCommand.CommandText = "select bestankar FROM [moshtari] WHERE id='" + moshtari;
                try
                {
                    object objBestankar = DataAccess.objCommand.ExecuteScalar();
                    if (objBestankar != DBNull.Value)
                    {
                        long bestankarl;
                        bestankarl = long.Parse(txt_bestankar.Text) + long.Parse(objBestankar.ToString());
                        bedehkar = bestankarl.ToString();
                    }
                    else
                    {
                        bestankar = txt_bestankar.Text;
                    }
                }
                catch { }

            }
            DataAccess.disconnect();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool error = false;



            #region Inspection
             if (dataGridView1.Rows.Count<=1)
            {
                MessageBox.Show("کالائی انتخاب نشده است");
                error = true;
            }
            if (!error)
            {
                try
                {
                    moshtari = comboBox4.SelectedItem.ToString();
                    moshtari = moshtari.Substring(0, moshtari.IndexOf('-'));
                }
                catch
                {
                    MessageBox.Show("مشتری را انتخاب کنید");
                    error = true;
                }
            }


            if (!error)
            {
                try
                {
                    ranande = comboBox2.SelectedItem.ToString();
                    ranande = ranande.Substring(0, ranande.IndexOf('-'));
                }
                catch
                {
                    MessageBox.Show("راننده را انتخاب کنید");
                    error = true;
                }
            }
            if (!error)
            {
                try
                {
                    barbari = comboBox3.SelectedItem.ToString();
                    barbari = barbari.Substring(0, barbari.IndexOf('-'));
                }
                catch
                {
                    MessageBox.Show("باربری را انتخاب کنید");
                    error = true;
                }
            }
            if (!error)
            {
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
            }
            if (!error)
            {
                try
                {
                    long test;
                    if (txt_takhfif.Text == "") txt_takhfif.Text = "0";
                    test = long.Parse(txt_takhfif.Text);
                    test = long.Parse(txt_factor.Text);

                }
                catch
                {
                    MessageBox.Show("مقادیر درست وارد کنید");
                    error = true;
                }
            }

            if (!error && ( txt_factor.Text == "" || txt_factor.Text == "0"))
            {
                MessageBox.Show("فیلد ها را پر کنید");
                error = true;
            }
           

       
            #endregion

            if (!error)
            {
                calcTakhfif();
                getBedehkar_Bestankar();
                serial = txt_factor.Text;
                tarikh = txt_date.Text;
                tozihat = txt_tozihat.Text;
                vazeiat = "تحویل داده نشده";
                sabteForoush = new SabteForoush();

                int length = dataGridView1.Rows.Count;
                for (int i = 0; i < length; i++)
                {
                    try
                    {
                        kala = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        sabteForoush.add(tozihat, barbari, ranande, kala, tarikh, vazeiat, total.ToString(), serial, totalPrice.ToString(), moshtari, bedehkar, bestankar);
                    }
                    catch { }

                }
            
                txt_takhfif.Text = "";
                txt_price.Text = "";
                txt_tozihat.Text = "";
                txt_tedad.Text = "";
                txt_bedehkar.Text = "";
                txt_bestankar.Text = "";
                txt_date.Text = "";
                txt_factor.Text = "";
                txt_mojudi.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_tozihat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
