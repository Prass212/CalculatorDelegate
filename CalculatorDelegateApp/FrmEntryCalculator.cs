using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorDelegateApp
{
    public partial class FrmEntryCalculator : Form
    {
        //deklarasi tipe data event Hitung
        public delegate void CountEventHandler(Calculator cal);
        //dejlarasi event count
        public event CountEventHandler OnCount;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        //deklarasi field untuk menyimpan data calculator
        private Calculator cal;
        public FrmEntryCalculator()
        {
            InitializeComponent();
            cmbOperasi.SelectedIndex = 0;
        }

        // Constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryCalculator(string title)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
        }
        

        private void btnProses_Click(object sender, EventArgs e)
        {
            if(isNewData) cal = new Calculator();
            //setup variabel
            //cal.NilaiA = int.Parse(txtNilaiA.Text);
            cal.NilaiA = Convert.ToInt32(txtNilaiA.Text);
            cal.NilaiB = Convert.ToInt32(txtNilaiB.Text);
            cal.Operasi = cmbOperasi.SelectedItem.ToString();
            cal.Result = 0;
            

            if (isNewData) 
            {
                OnCount(cal);
                //reset form input
                txtNilaiA.Clear();
                txtNilaiB.Clear();
                // calculation
                if (cal.Operasi == "Penjumlahan")
                {
                    cal.Result = cal.NilaiA + cal.NilaiB;
                    return ;
                }
                else if (cal.Operasi == "Pengurangan")
                {
                    cal.Result = cal.NilaiA - cal.NilaiB;
                    return;
                }
                else if (cal.Operasi == "Perkalian")
                {
                    cal.Result = cal.NilaiA * cal.NilaiB;
                    return;
                }
                else if (cal.Operasi == "Pembagian")
                {
                    if (cal.NilaiB != 0)
                    {
                        cal.Result = cal.NilaiA / cal.NilaiB;
                        return;
                    }
                    else
                        MessageBox.Show("You can't divide by zero");
                }
                //.Text = result.ToString();
            }
            else
            {
                OnCount(cal);
                this.Close();
            }

        }
    }
}
