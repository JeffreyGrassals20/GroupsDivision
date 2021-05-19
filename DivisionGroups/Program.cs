using System;
using System.Collections.Generic;

namespace  DivisionGroups
{
   public class Program
    {

        public class Divition
        {

            public List<string> students = new List<string>();
            public List<string> topics = new List<string>();
            public List<string> Selection = new List<string>();
            public List<string> Exeptions = new List<string>();
            public List<string> Groups = new List<string>();


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

                while ((line = fileStudents.ReadLine()) != null)
                {
                    students.Add(line);
                }

                line = null;
                System.IO.StreamReader fileTopics = new System.IO.StreamReader(pathTopics);

                while ((line = fileTopics.ReadLine()) != null)
                {
                    topics.Add(line);
                }

                if (countGroups > students.Count)
                {
                    Console.Clear();
                    throw new Exception("La cantidad de grupos no debe ser mayor que la de estudiantes");
                }

            }

            public void Divition_Students_Topics_Grups(int quantity)
            {

                var random = new Random();
                int index;
                int index2;
                int index3;
                int counter = 0;
                Groups = new List<string>();

                while (topics.Count > 0)
                {

                    for (int i = 0; i < quantity; i++)
                    {
                        Groups.Add("GRUPO#" + i + 1);
                    }

                    while (Groups.Count > 0 && topics.Count > 0)
                    {

                        index = random.Next(Groups.Count);
                        index2 = random.Next(topics.Count);
                        index3 = random.Next(students.Count);


                        //PRIMERA CORRIDA

                        if (counter == 0)
                        {
                            Selection.Add(Groups[index] + "   TEMAS: ->" + topics[index2]);
                            Groups.RemoveAt(index);
                            topics.RemoveAt(index2);
                        }
                        //DEMAS CORRIDAS
                        else
                        {
                            for (int i = 0; i < Selection.Count; i++)
                            {
                                if (Selection[i].IndexOf(Groups[index]) != -1)
                                {

                                    Selection[i] = (Selection[i] + "  ," + topics[index2]);
                                    Groups.RemoveAt(index);
                                    topics.RemoveAt(index2);
                                    break;
                                }
                            }
                        }
                    }

                    counter++;
                }


                for (int i = 0; i < Selection.Count; i++)
                {
                    Selection[i] = (Selection[i] + "Estudiantes: ");
                }


                while (students.Count > 0)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        Groups.Add("GRUPO#" + i + 1);
                    }

                    while (students.Count > 0 && Groups.Count > 0)
                    {

                        index = random.Next(Groups.Count);
                        index3 = random.Next(students.Count);

                        for (int i = 0; i < Selection.Count; i++)
                        {
                            if (Selection[i].IndexOf(Groups[index]) != -1)
                            {

                                Selection[i] = (Selection[i] + "  ," + students[index3]);
                                Groups.RemoveAt(index);
                                students.RemoveAt(index3);
                                break;
                            }
                        }
                    }
                }



            }

            public static int fact(int n)
            {

                int i, f = 1;

                for (i = 1; i <= n; i++)
                {
                    f = f * i;
                }

                return f;
            }


            public double getStudentsPersistance(int groups, int students)
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

            divition.Divition_Students_Topics_Grups(countGroups);
            divition.Selection.ForEach(x => Console.WriteLine(x.ToString()));

            Console.ReadKey();
        }
    }
}
