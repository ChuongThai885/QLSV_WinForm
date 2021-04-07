using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetCBB();
        }

        public delegate void MyDel(SV a);

        public MyDel del { get; set; }

        public void SetCBB()
        {
            foreach (LSV i in CSDL_OOP.a.GetAllLSH())
            {
                cbBoxLSV.Items.Add(new ComboBoxItem { Value = i.ID_Lop, Text = i.NameLop });
            }
            cbBoxLSV.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SV sv = new SV();
            sv.MSSV = textMSSV.Text;
            sv.NameSV = textName.Text;
            sv.Gender = radioButMale.Checked;
            sv.ID_Lop = getValueCBB();
            sv.NS = dateTimePicker1.Value;
            del(sv);
            Close();
        }
        public int getValueCBB()
        {
            int a = 0;
            //ComboBoxItem i = new ComboBoxItem();
            foreach(ComboBoxItem i in cbBoxLSV.Items)
            {
                if (i.Value == ((ComboBoxItem)(cbBoxLSV.SelectedItem)).Value) a = i.Value;
            }
            return a;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void receiveSV(DataGridViewRow r)
        {
            textMSSV.Text = (r.Cells["MSSV"].Value).ToString();
            textName.Text = (r.Cells["NameSV"].Value).ToString();
            foreach(ComboBoxItem i in cbBoxLSV.Items)
            {
                if (Convert.ToInt32(r.Cells["ID_Lop"].Value) == i.Value) cbBoxLSV.SelectedItem = i;
            }
            if (!Convert.ToBoolean(r.Cells["Gender"].Value)) radioButFemale.Checked = true;
            dateTimePicker1.Value = Convert.ToDateTime(r.Cells["NS"].Value);
        }
    }
}
