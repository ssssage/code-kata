using System.Collections.Generic;
//int[,] array2D = { { 1, 0, 0, 1, 0 }, { 1, 0, 1, 0, 0 }, { 0, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1 }, { 1, 0, 1, 1, 0 } };
//System.Console.WriteLine(Rivers.RiverSizes(array2D));

namespace AlgoExpert.Lib
{
    public class Rivers
    {
        public static List<int> RiverSizes(int[,] matrix)
        {
            List<int> sizes = new List<int>();

            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {

                        continue;

                    }

                   TraverseNode(i, j, matrix, visited, sizes);
                }
            }
                return sizes;
            }

        private static void TraverseNode(int i, int j, int[,] matrix, bool[,] visited, List<int> sizes)
        {
            int currentRiverSize = 0;
            Stack<int[]> nodesToExplore = new Stack<int[]>();
            nodesToExplore.Push(new int[] { i, j });
            while (nodesToExplore.Count != 0)
            {
                int[] currentNode = nodesToExplore.Pop();
                
                i = currentNode[0];
                j = currentNode[1];

                if(visited[i, j])
                {
                    continue;
                }

                visited[i, j] = true;

                if (matrix[i, j] == 0)
                {
                    continue;
                }

                currentRiverSize++;

                List<int[]> unvistedNeighbours = GetUnvistedNeighbours(i, j, matrix, visited);

                foreach(var neighbour in unvistedNeighbours)
                {
                    nodesToExplore.Push(neighbour);
                }

            }

            if(currentRiverSize > 0)
            {
                sizes.Add(currentRiverSize);
            }
           
        }

        private static List<int[]> GetUnvistedNeighbours(int i, int j, int[,] matrix, bool[,] visited)
        {
            List<int[]> unvistedNeighbours = new List<int[]>();

            if(i > 0 && !visited[i - 1, j])
            {
                unvistedNeighbours.Add(new int[] { i - 1, j });
            }

            if(i < matrix.GetLength(0) - 1 && !visited[i + 1, j])
            {
                unvistedNeighbours.Add(new int[] { i + 1, j });
            }

            if (j > 0 && !visited[i,j - 1])
            {
                unvistedNeighbours.Add(new int[] { i - 1, j });
            }

            if (j < matrix.GetLength(1) - 1 && !visited[i,j + 1])
            {
                unvistedNeighbours.Add(new int[] { i, j + 1});
            }

            return unvistedNeighbours;
        }
    }
  }
