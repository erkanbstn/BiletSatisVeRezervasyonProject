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

namespace BiletSatisVeRezervasyonProject.Forms.Kurlar
{
    public partial class FKur : Form
    {
        public FKur()
        {
            InitializeComponent();
        }

        private void FKur_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Sunucuya Bağlanırken Bir Sorun Oluştu. Lütfen Daha Sonra Tekrar Deneyin.", "Sistem Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
