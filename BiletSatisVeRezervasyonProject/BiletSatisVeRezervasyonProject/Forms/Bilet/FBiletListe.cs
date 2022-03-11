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

namespace BiletSatisVeRezervasyonProject.Forms.Bilet
{
    public partial class FBiletListe : Form
    {
        public FBiletListe()
        {
            InitializeComponent();
        }

        private void FBiletListe_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in Baglanti.db.TBilet
                                       select new
                                       {
                                           x.BiletID,
                                           x.No,
                                           x.Kisi,
                                           x.Cinsiyet,
                                           x.Telefon,
                                           Otobus = x.TOtobus.No,
                                           x.Koltuk,
                                           x.Guzergah,
                                           x.Fiyat,
                                           x.Tarih,
                                           x.Durum
                                       }).ToList();

        }
        FBiletSatis f;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Aktarim.BiletID = int.Parse(gridView1.GetFocusedRowCellValue("BiletID").ToString());
            f = new FBiletSatis();
            f.Show();
        }
    }
}
