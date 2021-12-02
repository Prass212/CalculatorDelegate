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
    public partial class FrmCalculator : Form
    {
        private Calculator cal;
        public FrmCalculator()
        {
            InitializeComponent();
        }
       

        public void FrmEntry_OnCount()
        {
            // tampilkan data cal yg baru ke list box

            lstHasil.Items.Add(cal.Result);
            //lstHasil.Items.Add(item);
                
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            FrmEntryCalculator frmEntry = new FrmEntryCalculator("Calculator");
            frmEntry.OnCount += FrmEntry_OnCount1;
            frmEntry.ShowDialog();

        }

        private void FrmEntry_OnCount1(Calculator cal)
        {
            lstHasil.Items.Add(cal.Result);
        }
    }
}
