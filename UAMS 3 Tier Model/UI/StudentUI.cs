using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_3_Tier_Model.BL;
using UAMS_3_Tier_Model.DL;

namespace UAMS_3_Tier_Model.UI
{
    class StudentUI
    {
        public static void printStudents()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.Name + " got Addmission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.Name + "did not get Addmission");
                }
            }
        }

        public static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    if (degName == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.Name + "\t" + s.FscMarks + "\t" + s.EcatMarks + "\t" + s.Age);
                    }
                }
            }
        }
        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    
                    Console.WriteLine(s.Name + "\t" + s.FscMarks + "\t" + s.EcatMarks + "\t" + s.Age);
                    
                }
            }

        }
        public static Student takeInputForStudent()
        {
            string name, prefName;
            int age;
            float fsc, ecat;
            int pref;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write("Enter Student Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Student Age:");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSC Marks: ");
            fsc = float.Parse(Console.ReadLine());
            Console.Write("Enter Student ECAT Marks: ");
            ecat = float.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs: ");
            DegreeProgramUI.viewDegreePrograms();

            Console.Write("Enter How Many Preferencees to Enter: ");
            pref = int.Parse(Console.ReadLine());
            for (int i = 0; i < pref; i++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach(DegreeProgram dp in DegreeProgramDL.programList)
                {
                    if(degName==dp.degreeName && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    i--;
                }
            }
            Student s = new Student(name, age, fsc, ecat, preferences);
            return s;

        }

        public static void calculateFeeForAll()
        {
            foreach(Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.Name + " has " + s.calculateFee() + " fees");
                }
            }
        }
    }
}
