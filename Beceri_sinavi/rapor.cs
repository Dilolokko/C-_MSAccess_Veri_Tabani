using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Beceri_sinavi
{
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider = microsoft.jet.oledb.4.0 ; data source =Personel.mdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataTable tablo1 = new DataTable();
        private void rapor_Load(object sender, EventArgs e)
        {
            tablo1.Clear();
            baglanti.Open();
            OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil", baglanti);
            adtr1.Fill(tablo1);
            CrystalReport1 report = new CrystalReport1();
            report.SetDataSource(tablo1);
            rapor rpr = new rapor();
            crystalReport11.SetDataSource(tablo1);
            baglanti.Close();
            
            
        }
    }
}
