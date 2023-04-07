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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        void metot1()
        {
            var degerler = from u in db.TBLURUNs
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORI = u.TBLKATEGORI.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();

        }

        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            // var degerler = db.TBLURUNs.ToList();
            metot1();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORIs
                                                 select new
                                                 {
                                                     x.AD,
                                                     x.ID
                                                 }).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = TxtAd.Text;
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());



            t.MARKA = TxtMarka.Text;
            t.SATISFIYAT = decimal.Parse(TxtSatısFıyat.Text);
            t.STOK = short.Parse(TxtSTok.Text);
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);


            db.TBLURUNs.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxttID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();

            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtMarka.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            TxtSTok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            TxtSatısFıyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxttID.Text);

            var deger = db.TBLURUNs.Find(id);
            db.TBLURUNs.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxttID.Text);
            var deger = db.TBLURUNs.Find(id);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            deger.AD = TxtAd.Text;
            deger.STOK = short.Parse(TxtSTok.Text);
            deger.MARKA = TxtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT = decimal.Parse(TxtSatısFıyat.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAlisFiyat.Text = "";
            TxttID.Text = "";
            TxtMarka.Text = "";
            TxtSatısFıyat.Text = "";
            TxtSTok.Text = "";
            TxtAd.Text = "";



        }
    }
}
