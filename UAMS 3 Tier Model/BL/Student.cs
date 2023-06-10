using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS_3_Tier_Model.BL
{
    class Student
    {
        public string Name;
        public int Age;
        public float FscMarks;
        public float EcatMarks;
        public float Merit;
        public List<DegreeProgram> preferences;
        public List<Subject> regSubject;
        public DegreeProgram regDegree;


        public Student(string name, int age, float fsc, float ecat, List<DegreeProgram> preferences)
        {
            this.Name = name;
            this.Age = age;
            this.FscMarks = fsc;
            this.EcatMarks = ecat;
            this.preferences = preferences;
        }
        public void calculateMerit()
        {
            float fsc, ecat, total;
            fsc = FscMarks * (60 / 100);
            ecat = EcatMarks * (40 / 100);
            total = fsc + ecat;
            this.Merit = total;
        }
        public int getCreditHours()
        {
            int total = 0;
            for (int i = 0; i < regSubject.Count(); i++)
            {
                total = total + regSubject[i].creditHours;
            }
            return total;
        }
        public float calculateFee()
        {
            float total = 0;
            for (int i = 0; i < regSubject.Count(); i++)
            {
                total = total + regSubject[i].subjectFees;
            }
            return total;
        }
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
