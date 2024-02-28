//Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:

//int[,] labirynth1 = new int[,]
//{
//{1, 1, 1, 1, 1, 1, 1 },
//{1, 0, 0, 0, 0, 0, 1 },
//{1, 0, 1, 1, 1, 0, 1 },
//{0, 0, 0, 0, 1, 0, 0 },
//{1, 1, 0, 0, 1, 1, 1 },
//{1, 1, 1, 0, 1, 1, 1 },
//{1, 1, 1, 0, 1, 1, 1 }
//};

//Сигнатура метода:

//static int HasExit(int startI, int startJ, int[,] l)

namespace Sem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var list = new List<int> {1,2,3,4,5};
           List<int> ints = Task1.ReverseList(list);
           foreach (var x in list)
           {
               Console.WriteLine(x);
           }
             */
            int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {2, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
        };
            Console.WriteLine($"Количество выходов = {Task3_Labirinth.HasExit(1, 1, labirynth1)}");

 

        }


    }
}
