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

namespace BiletSatisVeRezervasyonProject.Forms.Yonetici
{
    public partial class FYoneticiIslemler : Form
    {
        public FYoneticiIslemler()
        {
            InitializeComponent();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string RolKontrol()
        {
            string rol = "";
            if (radYonetici.Checked)
            {
                rol = "Yönetici";
            }
            else
            {
                rol = "Personel";
            }
            return rol;
        }
        Depo<TYonetici> yonetici = new Depo<TYonetici>();
        Depo<TIslem> islem = new Depo<TIslem>();

        void Listele()
        {
            try
            {
                gridControl1.DataSource = yonetici.Listele("Select * from TYonetici");
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Sunucuya Bağlanırken Bir Sorun Oluştu. Lütfen Daha Sonra Tekrar Deneyin.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                TYonetici t = new TYonetici();
                TIslem i = new TIslem();
                i.Aciklama = $" {RolKontrol()} Rolündeki Yeni Yönetici Eklendi";
                i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                islem.DepoEkle(i);
                t.Kullanici = txtYonetici.Text;
                t.Sifre = txtParola.Text;
                t.Rol = RolKontrol();
                yonetici.DepoEkle(t);
                XtraMessageBox.Show("Yönetici Başarıyla Eklendi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Eksik Veya Hatalı Veri Girişi Yaptınız, Lütfen Değerlerinizi Kontrol Ediniz.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    int id = Convert.ToInt32(txtID.Text);
                    var t = yonetici.DepoIDBul(id);
                    TIslem i = new TIslem();
                    i.Aciklama = $" {t.Kullanici} Kullanıcısı Güncellendi";
                    i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                    islem.DepoEkle(i);
                    t.Kullanici = txtYonetici.Text;
                    t.Sifre = txtParola.Text;
                    t.Rol = RolKontrol();
                    yonetici.DepoGuncelle(t);
                    XtraMessageBox.Show("Yönetici Başarıyla Güncellendi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
                else
                {
                    XtraMessageBox.Show("Yönetici ID Değerini Seçtiğinize Emin misiniz.?", "Sistem Sorgu Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Eksik Veya Hatalı Veri Girişi Yaptınız, Lütfen Değerlerinizi Kontrol Ediniz.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void RolDurumKontrol(string durum)
        {

            if (durum == "Yönetici")
            {
                radYonetici.Checked = true;
            }
            else
            {
                radPersonel.Checked = true;
            }
        }

        private void FYoneticiIslemler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = gridView1.GetDataRow(e.FocusedRowHandle);
            if (r != null)
            {
                txtYonetici.Text = r[1].ToString();
                txtID.Text = r[0].ToString();
                RolDurumKontrol(r[3].ToString());
                txtParola.Text = r[2].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "")
                {
                    int id = Convert.ToInt32(txtID.Text);
                    var t = yonetici.DepoIDBul(id);
                    TIslem i = new TIslem();
                    i.Aciklama = $" {t.Kullanici} Kullanıcısı Silindi";
                    i.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                    islem.DepoEkle(i);
                    yonetici.DepoSil(t);
                    XtraMessageBox.Show("Kullanıcı Başarıyla Silindi.", "Sistem Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
                else
                {
                    XtraMessageBox.Show("Kullanıcı ID Değerini Seçtiğinize Emin misiniz.?", "Sistem Sorgu Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Eksik Veya Hatalı Veri Girişi Yaptınız, Lütfen Değerlerinizi Kontrol Ediniz.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
