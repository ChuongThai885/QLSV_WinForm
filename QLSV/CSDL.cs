using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }
        public static CSDL Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set{}
        }
        private static CSDL _Instance;

        private CSDL()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("NameSV",typeof(string)),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_Lop",typeof(int)),
            });
            DateTime dt = Convert.ToDateTime("2001-11-22");
            DataRow dr = DTSV.NewRow();
            dr["MSSV"] = "101"; dr["NameSV"] = "NVA";
            dr["Gender"] = true; dr["ID_Lop"] = 2;
            dr["NS"] = dt;
            DTSV.Rows.Add(dr);

            DateTime dt1 = Convert.ToDateTime("2001-11-20");
            DataRow dr1 = DTSV.NewRow();
            dr1["MSSV"] = "102"; dr1["NameSV"] = "NTB";
            dr1["Gender"] = false; dr1["ID_Lop"] = 2;
            dr1["NS"] = dt1;
            DTSV.Rows.Add(dr1);

            DateTime dt2 = Convert.ToDateTime("2001-06-18");
            DataRow dr3 = DTSV.NewRow();
            dr3["MSSV"] = "103"; dr3["NameSV"] = "John Wick";
            dr3["Gender"] = true; dr3["ID_Lop"] = 1;
            dr3["NS"] = dt2;
            DTSV.Rows.Add(dr3);

            DateTime dt3 = Convert.ToDateTime("2001-07-09");
            DataRow d = DTSV.NewRow();
            d["MSSV"] = "104"; d["NameSV"] = "NTC";
            d["Gender"] = false; d["ID_Lop"] = 1;
            d["NS"] = dt3;
            DTSV.Rows.Add(d);

            DateTime dt4 = Convert.ToDateTime("2001-12-17");
            DataRow d1 = DTSV.NewRow();
            d1["MSSV"] = "105"; d1["NameSV"] = "NTD";
            d1["Gender"] = false; d1["ID_Lop"] = 4;
            d1["NS"] = dt4;
            DTSV.Rows.Add(d1);

            // datatable d sach lop
            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Lop",typeof(int)),
                new DataColumn("NameLop",typeof(string)),
            });
            DataRow dr2 = DTLSH.NewRow();
            dr2["ID_lop"] = 1;
            dr2["NameLop"] = "19TCLC DT3";
            DTLSH.Rows.Add(dr2);

            DataRow dr4 = DTLSH.NewRow();
            dr4["ID_lop"] = 2;
            dr4["NameLop"] = "19TCLC DT5";
            DTLSH.Rows.Add(dr4);

            DataRow dr5 = DTLSH.NewRow();
            dr5["ID_lop"] = 4;
            dr5["NameLop"] = "19TCLC DT6";
            DTLSH.Rows.Add(dr5);
        }
        public void AddNewRow(SV a)
        {
            DataRow b = DTSV.NewRow();
            b["MSSV"] = a.MSSV;
            b["NameSV"] = a.NameSV;
            b["Gender"] = a.Gender;
            b["ID_Lop"] = a.ID_Lop;
            b["NS"] = a.NS;
            DTSV.Rows.Add(b);
        }

        public void EditRow(SV a)
        {
            int dem = 0;
            while (dem < Instance.DTSV.Rows.Count)
            {
                if((Instance.DTSV.Rows[dem]["MSSV"]).ToString() == a.MSSV)
                {
                    Instance.DTSV.Rows[dem]["NameSV"] = a.NameSV;
                    Instance.DTSV.Rows[dem]["Gender"] = a.Gender;
                    Instance.DTSV.Rows[dem]["ID_Lop"] = a.ID_Lop;
                    Instance.DTSV.Rows[dem]["NS"] = a.NS;
                    break;
                }
                dem++;
            }
        }

        public void DeleteRow(SV a)
        {
            int dem = 0;
            while (dem < Instance.DTSV.Rows.Count)
            {
                if ((Instance.DTSV.Rows[dem]["MSSV"]).ToString() == a.MSSV)
                {
                    Instance.DTSV.Rows[dem].Delete();
                    break;
                }
                dem++;
            }
        }
    }
}
