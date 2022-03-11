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

namespace BiletSatisVeRezervasyonProject.Forms.Bilet
{
    public partial class FBiletSatis : Form
    {
        public FBiletSatis()
        {
            InitializeComponent();
        }
        void RolDurumKontrol(string durum)
        {

            if (durum == "Bay")
            {
                radBay.Checked = true;
            }
            else
            {
                radBayan.Checked = true;
            }
        }
        string RolKontrol()
        {
            string rol = "";
            if (radBay.Checked)
            {
                rol = "Bay";
            }
            else
            {
                rol = "Bayan";
            }
            return rol;
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
        Depo<TBilet> bilet = new Depo<TBilet>();
        Depo<TIslem> islem = new Depo<TIslem>();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Ekleme(string durum)
        {
            int otobus = Convert.ToInt32(lookUpEdit3.EditValue);
            string koltuk = Koltuk();
            var x = Baglanti.db.TBilet.SingleOrDefault(b => b.Otobus == otobus && b.Koltuk == koltuk);
            if (x == null)
            {
                TBilet t = new TBilet();
                t.No = bilet.KodUret();
                t.Kisi = txtKisi.Text;
                t.Guzergah = $"{lookUpEdit1.Text}-{lookUpEdit2.Text}";
                t.Cinsiyet = RolKontrol();
                t.Telefon = txtTelefon.Text;
                t.Otobus = Convert.ToInt32(lookUpEdit3.EditValue);
                t.Fiyat = Convert.ToInt32(txtFiyat.Text);
                t.Tarih = DateTime.Parse(dateTarih.EditValue.ToString());
                t.Durum = durum;
                t.Koltuk = Koltuk();
                bilet.DepoEkle(t);
                XtraMessageBox.Show("Bilet Başarıyla Oluşturuldu.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Bu Koltuk Doludur.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (Control c in groupControl4.Controls)
                {
                    if ((c is CheckBox) && ((CheckBox)c).Checked)
                    {
                        if (c.Text == Koltuk())
                        {
                            CheckBox b = c as CheckBox;
                            b.Checked = false;
                        }
                    }
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Ekleme("Bilet Satıldı");
            TIslem i = new TIslem();
            i.Aciklama = $"{txtNo.Text} Nolu Bilet {txtKisi} Kişisine Satıldı";
            i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            islem.DepoEkle(i);
        }

        private void FBiletSatis_Load(object sender, EventArgs e)
        {
            if (Aktarim.BiletID > 0)
            {
                var x = bilet.DepoIDBul(Aktarim.BiletID);
                txtFiyat.Text = x.Fiyat.ToString();
                txtKisi.Text = x.Kisi;
                txtNo.Text = x.No;
                txtTelefon.Text = x.Telefon;
                RolDurumKontrol(x.Cinsiyet);
                lookUpEdit3.EditValue = x.Otobus.ToString();
                CheckKontrol(x.Koltuk);
                dateTarih.EditValue = x.Tarih.ToString();
            }
            LookListe();
        }

        void CheckKontrol(string koltuk)
        {
            foreach (Control c in groupControl4.Controls)
            {
                if ((c is CheckBox))
                {
                    if (c.Text == koltuk)
                    {
                        CheckBox b = c as CheckBox;
                        b.Checked = true;
                    }
                }
            }
        }
        string Koltuk()
        {
            string koltuk = "";
            foreach (Control c in groupControl4.Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                {
                    koltuk = c.Text;
                }
            }
            return koltuk;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Ekleme("Bilet Rezerve Edildi");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (Aktarim.BiletID > 0)
            {
                var x = bilet.DepoIDBul(Aktarim.BiletID);
                TIslem i = new TIslem();
                i.Aciklama = $"{txtNo.Text} Nolu Bilet İptal Edildi";
                i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                islem.DepoEkle(i);
                bilet.DepoSil(x);
                XtraMessageBox.Show("Bilet Başarıyla İptal Edildi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int otobus = Convert.ToInt32(lookUpEdit3.EditValue);
            string koltuk = Koltuk();
            var x = Baglanti.db.TBilet.SingleOrDefault(b => b.Otobus == otobus && b.Koltuk == koltuk);
            if (x == null)
            {
                TBilet t = new TBilet();
                t.No = bilet.KodUret();
                t.Kisi = txtKisi.Text;
                t.Guzergah = $"{lookUpEdit1.Text}-{lookUpEdit2.Text}";
                t.Cinsiyet = RolKontrol();
                t.Telefon = txtTelefon.Text;
                t.Otobus = Convert.ToInt32(lookUpEdit3.EditValue);
                t.Fiyat = Convert.ToInt32(txtFiyat.Text);
                t.Tarih = DateTime.Parse(dateTarih.EditValue.ToString());
                t.Koltuk = Koltuk();
                TIslem i = new TIslem();
                i.Aciklama = $"{txtNo.Text} Nolu Bilet Güncellendi";
                i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                islem.DepoEkle(i);
                bilet.DepoEkle(t);
                XtraMessageBox.Show("Bilet Başarıyla Güncellendi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Bu Koltuk Doludur.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (Control c in groupControl4.Controls)
                {
                    if ((c is CheckBox) && ((CheckBox)c).Checked)
                    {
                        if (c.Text == Koltuk())
                        {
                            CheckBox b = c as CheckBox;
                            b.Checked = false;
                        }
                    }
                }
            }
        }
    }
}
