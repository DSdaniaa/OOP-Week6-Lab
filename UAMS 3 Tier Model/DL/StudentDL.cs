using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_3_Tier_Model.BL;
using System.IO;

namespace UAMS_3_Tier_Model.DL
{
    class StudentDL
    {
        public static List<Student> studentList = new List<Student>();
        public static void addIntoStudentList(Student d)
        {
            studentList.Add(d);
        }

        public static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (name==s.Name && s.regDegree!=null)
                {
                    return s;
                }
            }
            return null;
        }

        public static List<Student> SortByMerit()
        {
            List<Student> sorted = new List<Student>();
            foreach (Student i in studentList)
            {
                i.calculateMerit();
            }
            sorted = studentList.OrderByDescending(o => o.Merit).ToList();
            return sorted;
        }
        public static void giveAdmission(List<Student> sorted)
        {
            foreach (Student s in sorted)
            {
                foreach(DegreeProgram d in s.preferences)
                {
                    if(d.seats>0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }

        public static void storeintoFile(string path,Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeNames = "";
            for(int x=0; x < s.preferences.Count-1; x++)
            {
                degreeNames = degreeNames + s.preferences[x].degreeName + ";";
            }
            degreeNames = degreeNames + s.preferences[s.preferences.Count - 1].degreeName;
            f.WriteLine(s.Name + "," + s.Age + "," + s.FscMarks + "," + s.EcatMarks + "," + degreeNames);
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {

                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    float fscMarks= float.Parse(splittedRecord[2]);
                    float ecatMarks = float.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();

                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        DegreeProgram d= DegreeProgramDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d)))
                            {
                                preferences.Add(d);
                            }
                        }
                    }
                    Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
                    studentList.Add(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
