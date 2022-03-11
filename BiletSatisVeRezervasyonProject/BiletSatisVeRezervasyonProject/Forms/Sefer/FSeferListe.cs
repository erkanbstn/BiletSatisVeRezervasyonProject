using BiletSatisVeRezervasyonProject.Classes;
using BiletSatisVeRezervasyonProject.Forms.Otobus;
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
    public partial class FSeferListe : Form
    {
        public FSeferListe()
        {
            InitializeComponent();
        }

        private void FSeferListe_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in Baglanti.db.TSefer
                                       select new
                                       {
                                           x.SeferID,
                                           x.TOtobus.No,
                                           x.Guzergah,
                                           x.Saat,
                                           x.Tarih
                                       }).ToList();
        }
        FYeniSefer f;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Aktarim.SeferID = int.Parse(gridView1.GetFocusedRowCellValue("SeferID").ToString());
            f = new FYeniSefer();
            f.Show();
        }
    }
}
