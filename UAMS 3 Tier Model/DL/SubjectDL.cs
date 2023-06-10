using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_3_Tier_Model.BL;
using System.IO;

namespace UAMS_3_Tier_Model.DL
{
    class SubjectDL
    {
        public static List<Subject> subjectList = new List<Subject>();
        public static void addSubjectIntoList(Subject s)
        {
            subjectList.Add(s);
        }

        public static bool readFromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader f = new StreamReader(path);
                string record;
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHours = int.Parse(splittedRecord[2]);
                    int subjectFees = int.Parse(splittedRecord[3]);
                    Subject s = new Subject(code, type, creditHours, subjectFees);
                    addSubjectIntoList(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void storeintoFile(string path, Subject s)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(s.code + "," + s.subjectType + "," + s.creditHours + "," + s.subjectFees);
            f.Flush();
            f.Close();
        }

        public static Subject isSubjectExists(string type)
        {
            foreach(Subject s in subjectList)
            {
                if (s.subjectType == type)
                {
                    return s;
                }
            }
            return null;
        }

    }
}
