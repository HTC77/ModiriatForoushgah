
using System.Windows.Forms;
namespace ModiriatForoushgah.forms
{
    partial class FormTaminKonande
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_update = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_birthday = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_shomareShenasname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_tozihat = new System.Windows.Forms.TextBox();
            this.txt_bestankar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_bedehkar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_adress = new System.Windows.Forms.TextBox();
            this.txt_mobile = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_tel = new System.Windows.Forms.TextBox();
            this.txt_family = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1084, 298);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(294, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 10);
            this.panel1.TabIndex = 4;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(710, 21);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(76, 25);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "ویرایش";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.btn_update);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Location = new System.Drawing.Point(245, 479);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1122, 403);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "انصراف";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(620, 23);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(72, 26);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.SystemColors.Control;
            this.btn_add.Location = new System.Drawing.Point(794, 20);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(65, 26);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "ثبت";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(197, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(296, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "اطلاعات تأمین کنندگان";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(541, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 91);
            this.panel2.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_birthday);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_shomareShenasname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_tozihat);
            this.groupBox1.Controls.Add(this.txt_bestankar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_bedehkar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_adress);
            this.groupBox1.Controls.Add(this.txt_mobile);
            this.groupBox1.Controls.Add(this.txt_email);
            this.groupBox1.Controls.Add(this.txt_tel);
            this.groupBox1.Controls.Add(this.txt_family);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Location = new System.Drawing.Point(541, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 330);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "مرد",
            "زن",
            "سایر"});
            this.comboBox1.Location = new System.Drawing.Point(324, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(126, 24);
            this.comboBox1.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(476, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "شماره شناسنامه";
            // 
            // txt_birthday
            // 
            this.txt_birthday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_birthday.Location = new System.Drawing.Point(324, 123);
            this.txt_birthday.Name = "txt_birthday";
            this.txt_birthday.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_birthday.Size = new System.Drawing.Size(132, 22);
            this.txt_birthday.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(476, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "تاریخ تولد";
            // 
            // txt_shomareShenasname
            // 
            this.txt_shomareShenasname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_shomareShenasname.Location = new System.Drawing.Point(324, 95);
            this.txt_shomareShenasname.Name = "txt_shomareShenasname";
            this.txt_shomareShenasname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_shomareShenasname.Size = new System.Drawing.Size(132, 22);
            this.txt_shomareShenasname.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "توضیحات";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(217, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "بستانکار";
            // 
            // txt_tozihat
            // 
            this.txt_tozihat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tozihat.Location = new System.Drawing.Point(31, 200);
            this.txt_tozihat.Name = "txt_tozihat";
            this.txt_tozihat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_tozihat.Size = new System.Drawing.Size(144, 22);
            this.txt_tozihat.TabIndex = 12;
            // 
            // txt_bestankar
            // 
            this.txt_bestankar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_bestankar.Location = new System.Drawing.Point(31, 172);
            this.txt_bestankar.Name = "txt_bestankar";
            this.txt_bestankar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_bestankar.Size = new System.Drawing.Size(144, 22);
            this.txt_bestankar.TabIndex = 12;
            this.txt_bestankar.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "بدهکار";
            // 
            // txt_bedehkar
            // 
            this.txt_bedehkar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_bedehkar.Location = new System.Drawing.Point(31, 143);
            this.txt_bedehkar.Name = "txt_bedehkar";
            this.txt_bedehkar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_bedehkar.Size = new System.Drawing.Size(144, 22);
            this.txt_bedehkar.TabIndex = 12;
            this.txt_bedehkar.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "آدرس";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(484, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "جنسیت";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "تلفن همراه";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(200, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "تلفن ثابت";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "نام خانوادگی";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(492, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = ": نام";
            // 
            // txt_adress
            // 
            this.txt_adress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_adress.Location = new System.Drawing.Point(27, 245);
            this.txt_adress.Name = "txt_adress";
            this.txt_adress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_adress.Size = new System.Drawing.Size(431, 22);
            this.txt_adress.TabIndex = 5;
            // 
            // txt_mobile
            // 
            this.txt_mobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_mobile.Location = new System.Drawing.Point(31, 94);
            this.txt_mobile.Name = "txt_mobile";
            this.txt_mobile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_mobile.Size = new System.Drawing.Size(144, 22);
            this.txt_mobile.TabIndex = 3;
            this.txt_mobile.Text = "0";
            // 
            // txt_email
            // 
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_email.Location = new System.Drawing.Point(31, 37);
            this.txt_email.Name = "txt_email";
            this.txt_email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_email.Size = new System.Drawing.Size(144, 22);
            this.txt_email.TabIndex = 2;
            // 
            // txt_tel
            // 
            this.txt_tel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tel.Location = new System.Drawing.Point(31, 65);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_tel.Size = new System.Drawing.Size(144, 22);
            this.txt_tel.TabIndex = 2;
            this.txt_tel.Text = "0";
            // 
            // txt_family
            // 
            this.txt_family.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_family.Location = new System.Drawing.Point(324, 50);
            this.txt_family.Name = "txt_family";
            this.txt_family.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_family.Size = new System.Drawing.Size(132, 22);
            this.txt_family.TabIndex = 1;
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.Location = new System.Drawing.Point(324, 21);
            this.txt_name.Name = "txt_name";
            this.txt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_name.Size = new System.Drawing.Size(132, 22);
            this.txt_name.TabIndex = 0;
            // 
            // FormTaminKonande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1613, 906);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(2300, 1000);
            this.Name = "FormTaminKonande";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "FormTaminkonande";
            this.Load += new System.EventHandler(this.FormTaminkonande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void FormTaminkonande_Load(object sender, System.EventArgs e)
        {
            showData();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_birthday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_shomareShenasname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_tozihat;
        private System.Windows.Forms.TextBox txt_bestankar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_bedehkar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_adress;
        private System.Windows.Forms.TextBox txt_mobile;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_tel;
        private System.Windows.Forms.TextBox txt_family;
        private System.Windows.Forms.TextBox txt_name;

    }
}