using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class CSDL_OOP
    {
        public static CSDL_OOP a = new CSDL_OOP();
        public List<SV> Listsv { get; set; }
        public List<LSV> ListL { get; set; }

        public CSDL_OOP()
        {
            GetDataFromCSDL();
        }

        public void GetDataFromCSDL()
        {
            if (Listsv != null) Listsv.Clear();
            else Listsv = new List<SV>();
            foreach (DataRow row in CSDL.Instance.DTSV.Rows)
            {
                SV a = new SV();
                a.MSSV = row["MSSV"].ToString();
                a.NameSV = row["NameSV"].ToString();
                a.Gender = Convert.ToBoolean(row["Gender"].ToString());
                a.NS = Convert.ToDateTime(row["NS"].ToString());
                a.ID_Lop = Convert.ToInt32(row["ID_Lop"].ToString());
                Listsv.Add(a);
            }

            if (ListL != null) ListL.Clear();
            else ListL = new List<LSV>();
            foreach (DataRow r in CSDL.Instance.DTLSH.Rows)
            {
                LSV l = new LSV();
                l.ID_Lop = Convert.ToInt32(r["ID_Lop"].ToString());
                l.NameLop = r["NameLop"].ToString();
                ListL.Add(l);
            }
        }
        public SV GetSV(string Name)
        {
            SV sv = new SV();
            foreach(SV i in Listsv)
            {
                if (i.NameSV == Name) sv = i;
            }
            return sv;
        }
        public LSV GetLopSV(string Name)
        {
            LSV l = new LSV();
            foreach(LSV i in ListL)
            {
                if (i.NameLop == Name) l = i;
            }
            return l;
        }
        public List<LSV> GetAllLSH()
        {
            return ListL;
        }
        public List<SV> GetAllSV()
        {
            return Listsv;
        }
        
        public List<SV> GetListSV(int ID_Lop,string Name)
        {
            List<SV> a = new List<SV>();
            if(ID_Lop == 0)
            {
                if (Name == "") return GetAllSV();
                else if(GetSV(Name).NameSV == Name) a.Add(GetSV(Name));
                return a;
            }else
            {
                if(Name == "")
                {
                    foreach(SV sv in Listsv)
                    {
                        if (sv.ID_Lop == ID_Lop) a.Add(sv);
                    }
                    return a;
                }
                else
                {
                    foreach(SV sv in Listsv)
                    {
                        if (sv.ID_Lop == ID_Lop && sv.NameSV == Name) a.Add(sv);
                    }
                    return a;
                }
            }
        }
        public bool checkMSSV(string a)
        {
            foreach(SV i in Listsv)
            {
                if (i.MSSV == a) return false;
            }
            return true;
        }
        public bool AddNewSV(SV sv,bool isAdd)
        {
            if (isAdd)
            {
                if (checkMSSV(sv.MSSV)) 
                {
                    CSDL.Instance.AddNewRow(sv);
                    a.GetDataFromCSDL();
                    return true;
                }
                return false;
            }
            else
            {

                CSDL.Instance.EditRow(sv);
                a.GetDataFromCSDL();
                return true;
            }
        }
        public void DeleteSV(SV sv)
        {
            CSDL.Instance.DeleteRow(sv);
            a.GetDataFromCSDL();
        }
    }
}
