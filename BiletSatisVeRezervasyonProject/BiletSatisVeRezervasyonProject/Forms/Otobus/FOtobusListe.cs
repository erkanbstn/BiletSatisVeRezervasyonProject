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

namespace BiletSatisVeRezervasyonProject.Forms.Otobus
{
    public partial class FOtobusListe : Form
    {
        public FOtobusListe()
        {
            InitializeComponent();
        }

        private void FOtobusListe_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in Baglanti.db.TOtobus
                                       select new
                                       {
                                           x.OtobusID,
                                           x.No,
                                           x.Marka,
                                           x.Model
                                       }).ToList();
        }
        FYeniOtobus f;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Aktarim.OtobusID = int.Parse(gridView1.GetFocusedRowCellValue("OtobusID").ToString());
            f = new FYeniOtobus();
            f.Show();
        }
    }
}
