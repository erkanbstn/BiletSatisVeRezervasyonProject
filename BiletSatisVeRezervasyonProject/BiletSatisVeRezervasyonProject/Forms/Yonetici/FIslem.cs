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

namespace BiletSatisVeRezervasyonProject.Forms.Yonetici
{
    public partial class FIslem : Form
    {
        public FIslem()
        {
            InitializeComponent();
        }

        private void FIslem_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from c in Baglanti.db.TIslem
                                       select new
                                       {
                                           c.IslemID,
                                           c.Aciklama,
                                           c.Tarih
                                       }).ToList();
        }
    }
}
