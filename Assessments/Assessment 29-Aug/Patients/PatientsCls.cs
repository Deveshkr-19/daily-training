using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients
{
    public class PatientsCls : CommonCls
    {
        public string vaccRec;
        protected string address;
        private int insuranceID;

        public string getAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public int getInsID
        {
            get
            {
                return insuranceID;
            }
            set
            {
                insuranceID = value;
            }
        }
    }
}
