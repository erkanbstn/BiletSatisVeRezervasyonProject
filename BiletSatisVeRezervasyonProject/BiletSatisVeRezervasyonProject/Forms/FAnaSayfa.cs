using BiletSatisVeRezervasyonProject.Classes;
using BiletSatisVeRezervasyonProject.Forms.Kurlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiletSatisVeRezervasyonProject.Forms
{
    public partial class FAnaSayfa : Form
    {
        public FAnaSayfa()
        {
            InitializeComponent();
        }
        Otobus.FOtobusListe f;
        Otobus.FYeniOtobus f2;
        Yonetici.FYoneticiIslemler f3;
        Yonetici.FIslem f8;
        Sefer.FSeferListe f4;
        Sefer.FYeniSefer f5;
        Bilet.FBiletListe f6;
        Bilet.FBiletSatis f7;
        FKur f9;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f == null || f.IsDisposed)
            {
                f = new Otobus.FOtobusListe();
                f.MdiParent = this;
                f.Show();
            }
            else { f.Focus(); }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f2 == null || f2.IsDisposed)
            {
                f2 = new Otobus.FYeniOtobus();
                f2.Show();
            }
            else { f2.Focus(); }

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f3 == null || f3.IsDisposed)
            {
                f3 = new Yonetici.FYoneticiIslemler();
                f3.Show();
            }
            else { f3.Focus(); }

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f4 == null || f4.IsDisposed)
            {
                f4 = new Sefer.FSeferListe();
                f4.MdiParent = this;
                f4.Show();
            }
            else { f4.Focus(); }

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f5 == null || f5.IsDisposed)
            {
                f5 = new Sefer.FYeniSefer();
                f5.Show();
            }
            else { f5.Focus(); }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f6 == null || f6.IsDisposed)
            {
                f6 = new Bilet.FBiletListe();
                f6.MdiParent = this;
                f6.Show();
            }
            else { f6.Focus(); }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f7 == null || f7.IsDisposed)
            {
                f7 = new Bilet.FBiletSatis();
                f7.Show();
            }
            else { f7.Focus(); }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f8 == null || f8.IsDisposed)
            {
                f8 = new Yonetici.FIslem();
                f8.Show();
            }
            else { f8.Focus(); }
        }

        private void FAnaSayfa_Load(object sender, EventArgs e)
        {
            if (Aktarim.KullaniciRol == "Personel")
            {
                barButtonItem4.Enabled = false;
                barButtonItem9.Enabled = false;
            }
            else
            {
                barButtonItem4.Enabled = true;
                barButtonItem9.Enabled = true;
            }
            f9 = new FKur();
            f9.MdiParent = this;
            f9.Show();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f9 == null || f9.IsDisposed)
            {
                f9 = new FKur();
                f9.MdiParent = this;
                f9.Show();
            }
            else
            {
                f9.Focus();
            }
        }
    }
}
