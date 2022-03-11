using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiletSatisVeRezervasyonProject.Entity;
namespace BiletSatisVeRezervasyonProject.Classes
{
    public static class Baglanti
    {
        public static BiletSatisDBEntities db = new BiletSatisDBEntities();
        public static SqlConnection bgl = new SqlConnection("Data Source=GEOPC\\SQLEXPRESS;Initial Catalog=BiletSatisDB;Integrated Security=True;MultipleActiveResultSets=True;");
    }
}
