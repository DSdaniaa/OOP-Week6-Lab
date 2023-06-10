using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_3_Tier_Model.BL;

namespace UAMS_3_Tier_Model.UI
{
    class SubjectUI
    {
        public static Subject takeInputForSubject()
        {
            Console.Write("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.Write("Enter Subject Type: ");
            string type = Console.ReadLine();
            Console.Write("Enter Subject Credit Hours:");
             int hours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees: ");
            int fees = int.Parse(Console.ReadLine());
            Subject temp = new Subject(code, type, hours, fees);
            return temp;
        }

        public static void viewSubjects(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Sub Code\tSub Type");
                foreach(Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.subjectType);
                }

            }
        }

        public static void registerSubjects(Student s)
        {
            Console.WriteLine("Enter how many subjects you want to register");
            int count = int.Parse(Console.ReadLine());
            for(int x=0; x < count; x++)
            {
                Console.WriteLine("Enter the Subject Code ");
                string code = Console.ReadLine();
                bool flag = false;
                foreach(Subject sub in s.regDegree.subjects)
                {
                    if(code==sub.code && !(s.regSubject.Contains(sub)))
                    {
                        if (s.regStudentSubject(sub))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A Student can not have more than 9 CH");
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Course");
                    x--;
                }
            }
        }
    }
}
