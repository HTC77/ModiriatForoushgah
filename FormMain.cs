using ModiriatForoushgah.forms;
using ModiriatForoushgah.forms.forms_kala;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModiriatForoushgah
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ثبتکالاهایواردشدهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void مشاهدهکاربرانToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormMoshahedeKalahayeVaredShode().ShowDialog();
        }

        private void registerUser_Click(object sender, EventArgs e)
        {
            new forms.forms_user.RegisterUser().ShowDialog();
        }

        private void Moshtari_Click(object sender, EventArgs e)
        {
            new forms.FormMoshtari().ShowDialog();
        }



        private void Foroushande_Click(object sender, EventArgs e)
        {
            new forms.FormForoushande().ShowDialog();
        }

        private void Anbardar_Click(object sender, EventArgs e)
        {
            new forms.FormAnbardar().ShowDialog();
        }

        private void TaminKonande_Click(object sender, EventArgs e)
        {
            new forms.FormTaminKonande().ShowDialog();
        }

        private void Ranande_Click(object sender, EventArgs e)
        {
            new forms.FormRanande().ShowDialog();
        }

        private void sabteKala_Click(object sender, EventArgs e)
        {
            new forms.forms_kala.FormSabteKala().ShowDialog();
        }

        private void anbardar_Click(object sender, EventArgs e)
        {
            new forms.FormAnbardar().ShowDialog();
        }

        private void taminKonande_Click(object sender, EventArgs e)
        {
            new forms.FormTaminKonande().ShowDialog();
        }

        private void ranande_Click(object sender, EventArgs e)
        {
            new forms.FormRanande().ShowDialog();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Width=900;
        }

        private void مشاهدهکاربرانToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void مشاهدهباربریهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormBarbari().ShowDialog();
        }

        private void فروشاجناسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormForoush().ShowDialog();
        }

        private void قیمتگذاریوثبتکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GheymatGozariKala().ShowDialog();
        }
    }
}
