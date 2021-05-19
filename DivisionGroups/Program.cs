using System;

namespace DivisionGroups
{
    class Program
    {

        class Divition
        {

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

        }
    }
}
