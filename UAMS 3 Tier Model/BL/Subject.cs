using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS_3_Tier_Model.BL
{
    class Subject
    {
        public string code;
        public string subjectType;
        public int creditHours;
        public float subjectFees;

        public Subject(string Code, string subjectType, int hours, float fees)
        {
            this.code = Code;
            this.subjectType = subjectType;
            this.creditHours = hours;
            this.subjectFees = fees;
        }
    }
}
