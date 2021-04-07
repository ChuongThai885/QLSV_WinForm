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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
        }

        public void SetCBB()
        {
            comboBoxLSH.Items.Add(new ComboBoxItem { Value = 0, Text = "All" });
            foreach(LSV i in CSDL_OOP.a.GetAllLSH())
            {
                comboBoxLSH.Items.Add(new ComboBoxItem { Value = i.ID_Lop, Text = i.NameLop });
            }
            comboBoxLSH.SelectedIndex = 0;
        }
        public void RefreshDS()
        {
            DanhSachSV.DataSource = null;
            Show(getValueCBB(), "");
        }
        

        // Show List SV
        public void Show(int ID_Lop,string Name)
        {
            DanhSachSV.DataSource = CSDL_OOP.a.GetListSV(ID_Lop, Name);
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") Show(getValueCBB(), "");
            else DanhSachSV.DataSource = null;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Nhap ten sinh vien vao !");
            }else Show(getValueCBB(), textBox1.Text);
        }

        public int getValueCBB()
        {
            int a = 0;
            //ComboBoxItem i = new ComboBoxItem();
            foreach (ComboBoxItem i in comboBoxLSH.Items)
            {
                if (i.Value == ((ComboBoxItem)(comboBoxLSH.SelectedItem)).Value) a = i.Value;
            }
            return a;
        }

        //Loading...
        public void Addsv(SV a)
        {
            if (CSDL_OOP.a.AddNewSV(a, true))
            {
                MessageBox.Show("Add Successful !!");
                RefreshDS();
            }
            else MessageBox.Show("MSSV was used !!");
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.del = new Form2.MyDel(Addsv);
            f2.Show();
        }

        public SV ParseToSV(DataGridViewRow r)
        {
            SV sv = new SV();
            sv.MSSV = (r.Cells["MSSV"].Value).ToString();
            sv.NameSV = (r.Cells["NameSV"].Value).ToString();
            sv.ID_Lop = Convert.ToInt32(r.Cells["ID_Lop"].Value);
            sv.Gender = Convert.ToBoolean(r.Cells["Gender"].Value);
            sv.NS = Convert.ToDateTime(r.Cells["NS"].Value);
            return sv;
        }

        public void EditSV(SV a)
        {
            DataGridViewRow r = DanhSachSV.CurrentRow;
            SV sv = new SV();
            sv = ParseToSV(r);

            if (sv.MSSV == a.MSSV)
            {
                if ((CSDL_OOP.a.AddNewSV(a, false)))
                {
                    MessageBox.Show("Edit Successful");
                    RefreshDS();
                }               
            }
            else MessageBox.Show("MSSV cannot be changed ");

        }
        private void butEdit_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            DataGridViewRow r = DanhSachSV.CurrentRow;
            if (r != null) 
            {
                f2.receiveSV(r);
                f2.del = new Form2.MyDel(EditSV);
                f2.Show();
            } 
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = DanhSachSV.CurrentRow;
            if (r != null)
            {
                SV sv = new SV();
                sv = ParseToSV(r);
                CSDL_OOP.a.DeleteSV(sv);
                RefreshDS();
            }
        }
    }
}
