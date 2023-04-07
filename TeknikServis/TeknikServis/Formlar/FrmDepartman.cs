using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLDEPARTMen
                           select new
                           {
                               u.ID,
                               u.AD,
                               
                               
                             
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl12.Text = db.TBLDEPARTMen.Count().ToString();
            labelControl15.Text = db.TBLPERSONELs.Count().ToString();

            
        }

        private void labelControl12_Click(object sender, EventArgs e)
        {
            
        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();

            t.AD = TxtAd.Text;
            t.ACIKLAMA = richTextBox1.Text;
            db.TBLDEPARTMen.Add(t);
            db.SaveChanges();
            MessageBox.Show("Departman Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from u in db.TBLDEPARTMen
                           select new
                           {
                               u.ID,
                               u.AD,
                             
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxttID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
           // richTextBox1.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();

            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxttID.Text);

            var deger = db.TBLDEPARTMen.Find(id);
            db.TBLDEPARTMen.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            int id = int.Parse(TxttID.Text);
            var deger = db.TBLDEPARTMen.Find(id);
            deger.AD =TxtAd.Text;
            
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
