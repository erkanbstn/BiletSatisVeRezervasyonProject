using BiletSatisVeRezervasyonProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiletSatisVeRezervasyonProject.Entity;
using DevExpress.XtraEditors;
namespace BiletSatisVeRezervasyonProject.Forms.Otobus
{
    public partial class FYeniOtobus : Form
    {
        public FYeniOtobus()
        {
            InitializeComponent();
        }

        private void FYeniOtobus_Load(object sender, EventArgs e)
        {
            if (Aktarim.OtobusID > 0)
            {
                var x = otobus.DepoIDBul(Aktarim.OtobusID);
                txtModel.Text = x.Model;
                txtMarka.Text = x.Marka;
                txtNo.Text = x.No;
            }
        }
        Depo<TOtobus> otobus = new Depo<TOtobus>();
        Depo<TIslem> islem = new Depo<TIslem>();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TOtobus t = new TOtobus();
            TIslem i = new TIslem();
            i.Aciklama = $"{txtNo.Text} Nolu Yeni Otobüs Eklendi";
            i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            islem.DepoEkle(i);
            t.Marka = txtMarka.Text;
            t.Model = txtModel.Text;
            t.No = otobus.KodUret();

            otobus.DepoEkle(t);
            XtraMessageBox.Show("Otobüs Başarıyla Eklendi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (Aktarim.OtobusID > 0)
            {
                var t = otobus.DepoIDBul(Aktarim.OtobusID);
                TIslem i = new TIslem();
                i.Aciklama = $" {t.No} Nolu Otobüs Güncellendi";
                i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                islem.DepoEkle(i);
                t.Marka = txtMarka.Text;
                t.Model = txtModel.Text;
                t.No = txtNo.Text;
                otobus.DepoGuncelle(t);
                XtraMessageBox.Show("Otobüs Başarıyla Güncellendi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Otobüsü Listeden Seçtiğinize Emin misiniz?", "Sistem Sorgu Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
