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
    public partial class Ana_menü : Form
    {
        public Ana_menü()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider = microsoft.jet.oledb.4.0 ; data source =Personel.mdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataTable tablo1 = new DataTable();
        public void listele()
        {
            tablo1.Clear();
            baglanti.Open();
            OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil",baglanti);
            adtr1.Fill(tablo1);
            dataGridView1.DataSource = tablo1;
            baglanti.Close();
        }
        private void Ana_menü_Load(object sender, EventArgs e)
        {
            listele();
            groupBox1.Enabled = false;
            gnclle.Enabled = false;
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void cikiş_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Çıkmak istediğinizden emin misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı","Dikkat !",MessageBoxButtons.OK,MessageBoxIcon.None);
            }
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            //baglanti.Open();
            //OleDbCommand kmt1 = new OleDbCommand("select*from Personel_Bil",baglanti);
            //OleDbDataReader oku = kmt1.ExecuteReader();
            //while (oku.Read)
            //{
               // if (P_N.Text == oku[0])
                //{
                 //MessageBox.Show("Aynı personel numarayla kayıtlı kişi var .", "Dikkat");
                 //  baglanti.Close();
               //}
               //else
               
            try
            {
                if (P_N.Text == "" || Adi.Text == "" || Soyadi.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || Adresi.Text == "" || İl.Text == "" || maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Herhangi boş alan bırakmayınız !", "Dikkat !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    baglanti.Open();
                    kmt.Connection = baglanti;
                    kmt.CommandText = "INSERT INTO Personel_Bil (PERSONEL_NO,ADI,SOYADI,ISE_BASLAMA_TARIHI,CINSIYET,BRANS,ADRES,IL,TELEFON) VALUES ('" + P_N.Text + "','" + Adi.Text + "','" + Soyadi.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + Adresi.Text + "','" + İl.Text + "','" + maskedTextBox1.Text + "')";
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                    P_N.Clear();
                    Adi.Clear();
                    Soyadi.Clear();
                    İl.Clear();
                    Adresi.Clear();
                    maskedTextBox1.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Girdiğiniz personel nosu daha önce kaydedilmiş .","Dikkat !",MessageBoxButtons.OK);
            }
                
           // }
            
        }

        private void gnclle_Click(object sender, EventArgs e)
        {
            try
            {
                if (P_N.Text == "" || Adi.Text == "" || Soyadi.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || Adresi.Text == "" || İl.Text == "" || maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Herhangi boş alan bırakmayınız !", "Dikkat !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    baglanti.Open();
                    kmt.Connection = baglanti;
                    kmt.CommandText = "UPDATE Personel_Bil SET ADI='" + Adi.Text + "',SOYADI='" + Soyadi.Text + "',ISE_BASLAMA_TARIHI='" + dateTimePicker1.Text + "',CINSIYET='" + comboBox1.Text + "',BRANS='" + comboBox2.Text + "',ADRES='" + Adresi.Text + "',IL='" + İl.Text + "',TELEFON='" + maskedTextBox1.Text + "' WHERE PERSONEL_NO='" + P_N.Text + "'";
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    listele();
                    P_N.Clear();
                    Adi.Clear();
                    İl.Clear();
                    Adresi.Clear();
                    Soyadi.Clear();
                    maskedTextBox1.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message,"Dikkat !");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                tablo1.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil where PERSONEL_NO = '" + textBox5.Text + "'", baglanti);
                adtr1.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                baglanti.Close();
            }
            else if (radioButton1.Checked == true)
            {
                tablo1.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil where ADI = '" + textBox5.Text + "'", baglanti);
                adtr1.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                baglanti.Close();
            }
            else if (radioButton2.Checked == true)
            {
                tablo1.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil where SOYADI = '" + textBox5.Text + "'", baglanti);
                adtr1.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                baglanti.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton4.Checked == true)
                {
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("Silmek istediğiniz kişinin numarasını giriniz .");
                    }
                    else
                    {
                        if (MessageBox.Show(textBox6.Text + " No lu personeli silmek istediğinizden emin misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                        {
                            baglanti.Open();
                            kmt.Connection = baglanti;
                            kmt.CommandText = "DELETE FROM Personel_Bil WHERE PERSONEL_NO='" + textBox6.Text + "'";
                            kmt.ExecuteNonQuery();
                            baglanti.Close();
                            listele();
                            P_N.Clear();
                            Adi.Clear();
                            İl.Clear();
                            Adresi.Clear();
                            Soyadi.Clear();
                            maskedTextBox1.Clear();
                            textBox6.Clear();
                        }
                    }
                }
                else if (radioButton6.Checked == true)
                {
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("Silmek istediğiniz kişinin adını giriniz .");
                    }
                    else
                    {
                        if (MessageBox.Show(textBox6.Text + " isimli personeli silmek istediğinizden emin misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                        {
                            baglanti.Open();
                            kmt.Connection = baglanti;
                            kmt.CommandText = "DELETE FROM Personel_Bil WHERE ADI='" + textBox6.Text + "'";
                            kmt.ExecuteNonQuery();
                            baglanti.Close();
                            listele();
                            P_N.Clear();
                            Adi.Clear();
                            İl.Clear();
                            Adresi.Clear();
                            Soyadi.Clear();
                            maskedTextBox1.Clear();
                            textBox6.Clear();
                        }
                    }
                }
                else if (radioButton5.Checked == true)
                {
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("Silmek istediğiniz kişinin soyadını giriniz .");
                    }
                    else
                    {
                        if (MessageBox.Show(textBox6.Text + " soyadlı personeli silmek istediğinizden emin misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                        {
                            baglanti.Open();
                            kmt.Connection = baglanti;
                            kmt.CommandText = "DELETE FROM Personel_Bil WHERE SOYADI='" + textBox6.Text + "'";
                            kmt.ExecuteNonQuery();
                            baglanti.Close();
                            listele();
                            P_N.Clear();
                            Adi.Clear();
                            İl.Clear();
                            Adresi.Clear();
                            Soyadi.Clear();
                            maskedTextBox1.Clear();
                            textBox6.Clear();
                        }
                    }
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message, "Dikkat!"); 
            }
            
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            P_N.Clear();
            Adi.Clear();
            İl.Clear();
            Adresi.Clear();
            Soyadi.Clear();
            maskedTextBox1.Clear();
        }

        private void yeni_k_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            P_N.Focus();            
            gnclle.Visible = false;
            ekle.Visible = true;
            gnclle.Enabled = false;
            ekle.Enabled = true;
            P_N.Clear();
            Adi.Clear();
            İl.Clear();
            Adresi.Clear();
            Soyadi.Clear();
            maskedTextBox1.Clear();
        }

        private void k_silme_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            textBox6.Focus();
        }

        private void k_gncelleme_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            P_N.Focus();
            gnclle.Visible = true;
            ekle.Visible = false;
            gnclle.Enabled = true;
        }

        private void arama_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                tablo1.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil where PERSONEL_NO = '" + textBox5.Text + "'", baglanti);
                adtr1.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                baglanti.Close();
            }
            else if (radioButton1.Checked == true)
            {
                tablo1.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil where ADI = '" + textBox5.Text + "'", baglanti);
                adtr1.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                baglanti.Close();
            }
            else if (radioButton2.Checked == true)
            {
                tablo1.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr1 = new OleDbDataAdapter("select*from Personel_bil where SOYADI = '" + textBox5.Text + "'", baglanti);
                adtr1.Fill(tablo1);
                dataGridView1.DataSource = tablo1;
                baglanti.Close();
            }
        }

        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            P_N.Focus();
            gnclle.Visible = false;
            ekle.Visible = true;
            gnclle.Enabled = false;
            ekle.Enabled = true;
            P_N.Clear();
            Adi.Clear();
            İl.Clear();
            Adresi.Clear();
            Soyadi.Clear();
            maskedTextBox1.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                P_N.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Soyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Adresi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                İl.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                if (radioButton4.Checked == true)
                {

                    textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    
                        
                     
                }
                else if (radioButton6.Checked == true)
                {
                    textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                }
                else if (radioButton5.Checked == true)
                {
                    textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message,"Dikkat !");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            P_N.Focus();
            gnclle.Visible = false;
            ekle.Visible = true;
            gnclle.Enabled = false;
            ekle.Enabled = true;
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            P_N.Focus();
            gnclle.Visible = true;
            ekle.Visible = false;
            gnclle.Enabled = true;
        }

        private void aramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Focus();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox6.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Çıkmak istediğinizden emin misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı", "Dikkat !", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkimizda hak = new hakkimizda();
            hak.Show();
        }

        private void rpr_al_Click(object sender, EventArgs e)
        {
            rapor rpr = new rapor();
            rpr.Show();
            
        }

        private void raporAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            rapor rpr = new rapor();
            rpr.Show();
        }

        
    }
}
