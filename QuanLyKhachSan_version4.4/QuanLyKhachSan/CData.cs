﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class CData
    {
        private List<CNhanVien> arrNV;
        private List<CKhachHang> arrKH;
        private List<CPhong> arrPKS;
        private List<CDatPhong> arrDP;
        private List<CHistory> arrLS;

        public CData()
        {
            arrNV = new List<CNhanVien>();
            arrKH = new List<CKhachHang>();
            arrPKS = new List<CPhong>();
            arrDP = new List<CDatPhong>();
            arrLS = new List<CHistory>();
        }

        internal List<CNhanVien> ArrNV { get => arrNV; set => arrNV = value; }
        internal List<CKhachHang> ArrKH { get => arrKH; set => arrKH = value; }
        internal List<CPhong> ArrPKS { get => arrPKS; set => arrPKS = value; }
        internal List<CDatPhong> ArrDP { get => arrDP; set => arrDP = value; }
        internal List<CHistory> ArrLS { get => arrLS; set => arrLS = value; }

        public void OpenNV(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrNV = (List<CNhanVien>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveNV(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrNV);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OpenKH(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrKH = (List<CKhachHang>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }        
        public void SaveKH(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrKH);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OpenP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrPKS = (List<CPhong>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrPKS);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OpenDP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrDP = (List<CDatPhong>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveDP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrDP);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OpenLSKH(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrLS = (List<CHistory>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveLSKH(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrLS);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
