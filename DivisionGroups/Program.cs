using System;
using System.Collections.Generic;

namespace DivisionGroups
{
    class Program
    {

        class Divition
        {

            public List<string> students = new List<string>();
            public List<string> topics = new List<string>();
            
            public void checkValues(int countGroups, string pathStudents, string pathTopics)
            {
                if (countGroups <= 0)
                {
                    throw new Exception("La cantidad grupos es menor o igual que 0.");
                }

                if (pathStudents == null || pathTopics == null)
                {
                    throw new Exception("Las direcciones ingresadas no  son validas.");
                }

                Console.WriteLine("All is correct");

            }

            public void readFiles(int countGroups, string pathStudents, string pathTopics)
            {
                string line;

                System.IO.StreamReader fileStudents = new System.IO.StreamReader(pathStudents);

                while((line = fileStudents.ReadLine()) != null){
                    students.Add(line);
                } 

                line = null;
                System.IO.StreamReader fileTopics = new System.IO.StreamReader(pathTopics);

                while((line = fileStudents.ReadLine()) != null){
                    topics.Add(line);
                }   

                if (countGroups > students.Count){
                    Console.Clear();
                    throw new Exception("La cantidad de grupos no debe ser mayor que la de estudiantes");
                }

            }


            public static int fact  (int n)
            {

                int i, f = 1; 

                for(i = 1; i <= n; i++)
                {
                    f = f * i;
                }

                return f;
            }


            public double getStudentsPersistance (int groups, int students)
            {
                int npr = fact(students) / fact(students - groups);

                return (100.0 / npr);
            }

        }

        static void Main(string[] args)
        {

            Divition divition = new Divition();

            Console.WriteLine("Cantidad de grupos: ");
            int countGroups = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("La direccion de los estudiantes: ");
            string pathStudents = Convert.ToString(Console.ReadLine());

            Console.WriteLine("La direccion de los temas: ");
            string pathTopics = Convert.ToString(Console.ReadLine());

            divition.checkValues(countGroups, pathStudents, pathTopics);
            divition.readFiles(countGroups, pathStudents, pathTopics);

        }
    }
}
