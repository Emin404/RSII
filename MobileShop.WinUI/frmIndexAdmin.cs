﻿using MobileShop.WinUI.Artikli;
using MobileShop.WinUI.Dobavljaci;
using MobileShop.WinUI.Izvjestaji;
using MobileShop.WinUI.Klijenti;
using MobileShop.WinUI.Korisnici;
using MobileShop.WinUI.Nabavke;
using MobileShop.WinUI.Skladista;
using MobileShop.WinUI.Zahtjevi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShop.WinUI
{
    public partial class frmIndexAdmin : Form
    {
        private int childFormNumber = 0;

        public frmIndexAdmin()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ListaKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void NoviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisniciDetalji frm = new frmKorisniciDetalji();
            frm.Show();
        }


        private void listaSkladistaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSkladista frm = new frmSkladista();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void NovoSkladisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSkladistaDetalji frm = new frmSkladistaDetalji();
            frm.Show();
        }

        private void listaDobavljacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDobavljaci frm = new frmDobavljaci();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviDobavljacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDobavljaciDetalji frm = new frmDobavljaciDetalji();
            frm.Show();
        }

        private void listaKlijenataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKlijenti frm = new frmKlijenti();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKlijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKlijentiDetalji frm = new frmKlijentiDetalji();
            frm.Show();
        }

        private void noviArtikalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtikliDetalji frm = new frmArtikliDetalji();
            frm.Show();
        }

        private void listaArtikalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtikli frm = new frmArtikli();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;

            frm.Show();
        }

        private void izvještajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmIzvjestajiIndex frm = new frmIzvjestajiIndex();
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            
        }
    }
}
