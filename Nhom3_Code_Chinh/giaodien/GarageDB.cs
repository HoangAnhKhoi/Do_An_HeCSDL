using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace giaodien
{
    internal class GarageDB
    {
        DataBase db;
        public string CT = "CHITIET_HD";
        public string HD = "HDONG";
        public string CV = "CV";
        public string VL = "VL";
        public string NCC = "NCC";
        public string KH = "KH";
        public string HDON = "HOADON";
        public string NHANVIEN = "NV";
        public string NHAPKHO = "NHAPKHO";
        public GarageDB()
        {
            this.db = new DataBase();
        }
        public GarageDB(string user,string pass)
        {
            this.db = new DataBase(user, pass);
        }
        public int delete(string nameTable, string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE XOA_" + nameTable + " @nguoiid,@result output";
            SqlParameter maNVParam = new SqlParameter("@nguoiid", id);
            maNVParam.SqlDbType = SqlDbType.Char;
            maNVParam.Size = 6;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultParam);
            cmd.Parameters.Add(maNVParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        public int delete15(string nameTable, string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE XOA_" + nameTable + " @nguoiid,@result output";
            SqlParameter maNVParam = new SqlParameter("@nguoiid", id);
            maNVParam.SqlDbType = SqlDbType.Char;
            maNVParam.Size = 15;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultParam);
            cmd.Parameters.Add(maNVParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        public string LayMaSo(string name)
        {
            return name + DateTime.Now.ToString("HHmmssddMMyyyy");
        }
    }
}
