using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int x, y;
            GetMatrixDimensions(out x, out y);

            int[,] matrix = new int[x, y];

            ReadMatrix(x, y, matrix);

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int xI, yI;
                GetIvoStartPosition(command, out xI, out yI);

                int xE, yE;
                GetEvelStartPosition(out xE, out yE);

                MoveEvel(matrix, ref xE, ref yE);
                MoveIvo(matrix, ref sum, ref xI, ref yI);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static void MoveIvo(int[,] matrix, ref long sum, ref int xI, ref int yI)
        {
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (InMatrix(matrix, xI, yI))
                {
                    sum += matrix[xI, yI];
                }
                yI++;
                xI--;
            }
        }

        private static void MoveEvel(int[,] matrix, ref int xE, ref int yE)
        {
            while (xE >= 0 && yE >= 0)
            {
                if (InMatrix(matrix, xE, yE))
                {
                    matrix[xE, yE] = 0;
                }
                xE--;
                yE--;
            }
        }

        private static bool InMatrix(int[,] matrix, int xE, int yE)
        {
            if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void GetEvelStartPosition(out int xE, out int yE)
        {
            int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            xE = evil[0];
            yE = evil[1];
        }

        private static void GetIvoStartPosition(string command, out int xI, out int yI)
        {
            int[] ivoStart = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            xI = ivoStart[0];
            yI = ivoStart[1];
        }

        private static void ReadMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        private static void GetMatrixDimensions(out int x, out int y)
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            x = dimestions[0];
            y = dimestions[1];
        }
    }
}
