using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBussinessLayer
{
    public class clsCountry
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public string PhoneCode { get; set; }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";
            this.CountryCode = "";
            this.PhoneCode = "";
            Mode = enMode.AddNew;
        }
        public clsCountry(int ID, string CountryName, string CountryCode, string PhoneCode)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.CountryCode = CountryCode;
            this.PhoneCode = PhoneCode;
            Mode = enMode.Update;
        }

        public static clsCountry Find(string CountryName)
        {
            string CountryCode = "";
            string PhoneCode = "";
            int ID = -1;

            if (clsCountryDataAcess.GetCountryInfoByName(CountryName, ref ID, ref CountryCode, ref PhoneCode))
            {
                return new clsCountry(ID, CountryName, CountryCode, PhoneCode);
            }
            else
            {
                return null;
            }
        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";
            string CountryCode = "";
            string PhoneCode = "";
            if (clsCountryDataAcess.GetCountryInfoByID(ID, ref CountryName, ref CountryCode, ref PhoneCode))
            {
                return new clsCountry(ID, CountryName, CountryCode, PhoneCode);
            }
            else
            {
                return null;
            }
        }

        public static bool IsCountryExisit(string CountryName)
        {

            return clsCountryDataAcess.IsCountryExisit(CountryName);
        }

        public static bool IsCountryExisit(int ID)
        {
            return clsCountryDataAcess.IsCountryExisit(ID);

        }

        private bool _AddNewCountry()
        {
            this.ID = clsCountryDataAcess.AddNewCountry(this.CountryName, this.CountryCode, this.PhoneCode);
            return this.ID != -1;
        }

        private bool _UpdateCountry()
        {
            return clsCountryDataAcess.UpdateCountry(this.ID, this.CountryName, this.CountryCode, this.PhoneCode);
        }

        public static bool DeleteCountry(int ID)
        {
            return clsCountryDataAcess.DeleteCountry(ID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAcess.GetAllCountries();
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update: 
                    return _UpdateCountry();
                default:
                    return false;
            }
        }
    }
}