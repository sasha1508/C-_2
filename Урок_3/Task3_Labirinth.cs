

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3
{/*Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
Пример лабиринта:
1 1 1 1 1 1 1
1 0 0 0 0 0 1
1 0 1 1 1 0 1
0 0 0 0 1 0 2
1 1 0 0 1 1 1
1 1 1 1 1 1 1
1 1 1 1 1 1 1
Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран  координаты точки выхода если таковые имеются.

Пример описания лабиринта.
int[,] labirynth1 = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 }
        };
Пример заголовка функции которая должна определить наличие выхода из лабиринта:
static bool HasExit(int startI, int startJ, int[,] labirinth)
startI,startJ  это точка начала пути-откуда мы начинаем проходить лабиринт. 
l - массив описывающий лабиринт.
  * */
    internal class Task3_Labirinth
    {
        public static int HasExit(int startI, int startJ, int[,] labirinth)
        {
            Queue<(int, int)> coords = new ();   //Создаём очередь
            int count = 0;
            if (labirinth[startI, startJ] != 1)  //Проверяем не является ли начальная точка стеной
            {
                coords.Enqueue((startI, startJ));
            }

            while (coords.Count > 0) 
            {
                (int i, int j) = coords.Dequeue();   //Читаем координату из очереди

                if (labirinth[i, j] == 2)  //Если дошли до выхода, то прибавляем счётчик выходов
                    count++;
                    

                labirinth[i, j] = 1;  //Закрашиваеи отработанную клетку

                //Ищем в соседних клетках нули или двойки, если находим, то добавляем в очередь:
                if (i - 1 >= 0 && labirinth[i - 1, j] != 1) coords.Enqueue((i - 1, j));
                if (i + 1 < labirinth.GetLength(0) && labirinth[i + 1, j] != 1) coords.Enqueue((i + 1, j));
                if (j - 1 >= 0 && labirinth[i, j - 1] != 1) coords.Enqueue((i, j - 1));
                if (j + 1 < labirinth.GetLength(1) && labirinth[i, j + 1] != 1) coords.Enqueue((i, j + 1));
            }
            return count;
        }
    }
}
