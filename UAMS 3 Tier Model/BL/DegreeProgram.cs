using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS_3_Tier_Model.BL
{
    class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects = new List<Subject>();
        public int seats;

        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;

        }
        public int calculateCreditHours()
        {
            int hours = 0;
            for (int i = 0; i < subjects.Count(); i++)
            {
                hours = hours + subjects[i].creditHours;
            }
            return hours;
        }
        public bool isSubjectExists(Subject sub)
        {
            bool flag = false;
            for (int i = 0; i < subjects.Count(); i++)
            {
                if (subjects[i] == sub)
                {
                    flag = true;
                }
            }
            return flag;

        }
        public bool AddSubject(Subject s)
        {
            int creditHours =
            calculateCreditHours();
            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
