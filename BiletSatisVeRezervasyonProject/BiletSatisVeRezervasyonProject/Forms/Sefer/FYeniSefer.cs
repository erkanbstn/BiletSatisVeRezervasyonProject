using BiletSatisVeRezervasyonProject.Classes;
using BiletSatisVeRezervasyonProject.Entity;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiletSatisVeRezervasyonProject.Forms.Sefer
{
    public partial class FYeniSefer : Form
    {
        public FYeniSefer()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        void LookListe()
        {
            DataTable cari_tip_tablo = new DataTable();
            cari_tip_tablo.Clear();
            cari_tip_tablo.Columns.Add("ID");
            cari_tip_tablo.Columns.Add("Tip");
            cari_tip_tablo.Rows.Add("1", "İstanbul");
            cari_tip_tablo.Rows.Add("2", "Edirne");
            cari_tip_tablo.Rows.Add("3", "Tekirdağ");
            cari_tip_tablo.Rows.Add("4", "Kocaeli");
            cari_tip_tablo.Rows.Add("5", "Bursa");
            cari_tip_tablo.Rows.Add("6", "Çanakkale");
            cari_tip_tablo.Rows.Add("7", "Balıkesir");
            cari_tip_tablo.Rows.Add("8", "Düzce");
            cari_tip_tablo.Rows.Add("9", "Yalova");
            cari_tip_tablo.Rows.Add("10", "Kırklareli");

            lookUpEdit1.Properties.DataSource = cari_tip_tablo;
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Tip";
            lookUpEdit2.Properties.DataSource = cari_tip_tablo;
            lookUpEdit2.Properties.ValueMember = "ID";
            lookUpEdit2.Properties.DisplayMember = "Tip";


            lookUpEdit3.Properties.DataSource = (from v in Baglanti.db.TOtobus
                                                 select new
                                                 {
                                                     v.OtobusID,
                                                     v.No
                                                 }).ToList();
            lookUpEdit3.Properties.ValueMember = "OtobusID";
            lookUpEdit3.Properties.DisplayMember = "No";

        }
        private void FYeniSefer_Load(object sender, EventArgs e)
        {
            if (Aktarim.SeferID > 0)
            {
                var x = sefer.DepoIDBul(Aktarim.SeferID);
                lookUpEdit3.EditValue = x.Otobus.ToString();
                dateTimePicker1.Text = x.Saat;
                dateTarih.EditValue = x.Tarih.ToString();
            }
            LookListe();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Depo<TSefer> sefer = new Depo<TSefer>();
        Depo<TIslem> islem = new Depo<TIslem>();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TSefer t = new TSefer();
            TIslem i = new TIslem();
            i.Aciklama = $"{lookUpEdit1.Text}-{lookUpEdit2.Text} Güzergahlı Sefer Oluşturuldu";
            i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            islem.DepoEkle(i);
            t.Otobus = Convert.ToInt32(lookUpEdit3.EditValue);
            t.Guzergah = $"{lookUpEdit1.Text}-{lookUpEdit2.Text}";
            t.Tarih = DateTime.Parse(dateTarih.EditValue.ToString());
            t.Saat = dateTimePicker1.Text;
            sefer.DepoEkle(t);
            XtraMessageBox.Show("Sefer Başarıyla Eklendi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (Aktarim.SeferID > 0)
            {
                var t = sefer.DepoIDBul(Aktarim.SeferID);
                TIslem i = new TIslem();
                i.Aciklama = $"{t.Guzergah} Güzergahlı Sefer {lookUpEdit1.Text}-{lookUpEdit2.Text} Olarak Güncellendi";
                i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                islem.DepoEkle(i);
                t.Otobus = Convert.ToInt32(lookUpEdit3.EditValue);
                t.Guzergah = $"{lookUpEdit1.Text}-{lookUpEdit2.Text}";
                t.Tarih = DateTime.Parse(dateTarih.EditValue.ToString());
                t.Saat = dateTimePicker1.Text;
                sefer.DepoGuncelle(t);
                XtraMessageBox.Show("Sefer Başarıyla Güncellendi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Seferi Listeden Seçtiğinize Emin misiniz?", "Sistem Sorgu Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
