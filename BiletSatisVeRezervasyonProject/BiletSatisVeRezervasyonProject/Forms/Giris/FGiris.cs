using BiletSatisVeRezervasyonProject.Classes;
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

namespace BiletSatisVeRezervasyonProject.Forms.Giris
{
    public partial class FGiris : Form
    {
        public FGiris()
        {
            InitializeComponent();
        }

        private void FGiris_Load(object sender, EventArgs e)
        {
            //KullaniciRol
        }
        FAnaSayfa f;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var x = Baglanti.db.TYonetici.FirstOrDefault(b => b.Kullanici == txtKullanici.Text && b.Sifre == txtParola.Text);
            if (x != null)
            {
                Aktarim.KullaniciRol = x.Rol;
                f = new FAnaSayfa();
                f.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
