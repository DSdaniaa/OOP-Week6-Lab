using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_3_Tier_Model.BL;
using UAMS_3_Tier_Model.DL;

namespace UAMS_3_Tier_Model.UI
{
    class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            string name, type, code;
            int duration, seats, hours, count;
            float fees;
            Console.Write("Enter Degree Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            duration = int.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            seats = int.Parse(Console.ReadLine());
            Console.Write("How Many Subjects to Enter: ");
            count = int.Parse(Console.ReadLine());
            DegreeProgram degree = new DegreeProgram(name, duration, seats);

            for (int i = 0; i < count; i++)
            {
                Subject s = SubjectUI.takeInputForSubject();
                if (degree.AddSubject(s))
                {
                    if (!(SubjectDL.subjectList.Contains(s)))
                    {
                        SubjectDL.addSubjectIntoList(s);
                        SubjectDL.storeintoFile("subject.txt", s);

                    }
                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    i++;
                }
            }
            return degree;
        }

        public static void viewDegreePrograms()
        {
            foreach(DegreeProgram dp in DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
    }
}
