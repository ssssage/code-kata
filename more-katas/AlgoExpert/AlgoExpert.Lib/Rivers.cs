using System.Collections.Generic;
//int[,] array2D = { { 1, 0, 0, 1, 0 }, { 1, 0, 1, 0, 0 }, { 0, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1 }, { 1, 0, 1, 1, 0 } };
//System.Console.WriteLine(Rivers.RiverSizes(array2D));

namespace AlgoExpert.Lib
{
    public class Rivers
    {
        //The purpose of this function is to traverse each and every element and return the sizes of rivers
        public static List<int> RiverSizes(int[,] matrix)
        {
            List<int> sizes = new List<int>();

            //this is false at the initialization level
            bool[,] visited =  new bool[matrix.GetLength(0), matrix.GetLength(1)];

            //we are iterating every element in the matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //if at any point it is visited we will continue  
                    if (visited[i, j])
                    {
                        continue;
                    }
                    //otherwise travers it
                   TraverseNode(i, j, matrix, visited, sizes);
                }
            }
                return sizes;
        }

        private static void TraverseNode(int i, int j, int[,] matrix, bool[,] visited, List<int> sizes)
        {
            //setting current river size to 0
            int currentRiverSize = 0;
            //setting nodestoExplore stack. 
            Stack<int[]> nodesToExplore = new Stack<int[]>();

            //Because we are doing Depth First Search iteratively with current node
            nodesToExplore.Push(new int[] { i, j });

            //we are continuously explore all the nodes that we added above 
            while (nodesToExplore.Count != 0)
            {
                int[] currentNode = nodesToExplore.Pop();
                
                i = currentNode[0];
                j = currentNode[1];

                //skip the nodes if they already visited
                if(visited[i, j])
                {
                    continue;
                }

                //otherwise mark them visited
                visited[i, j] = true;

                //skip exploring nodes if they are zero, means they are at the end of river in that side
                if (matrix[i, j] == 0)
                {
                    continue;
                }

                //if they are not land then update the river side
                currentRiverSize++;

                //then get all the unvisited neighbours
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

            //if above node is not visited add into unvistedNeighbours
            if (i > 0 && !visited[i - 1, j])
            {
              unvistedNeighbours.Add(new int[] { i - 1, j });
            }

            //if below node is not visited add into unvistedNeighbours
            if (i < matrix.GetLength(0) - 1 && !visited[i + 1, j])
            {
                unvistedNeighbours.Add(new int[] { i + 1, j });
            }

            //if the left node is not visited add into unvistedNeighbours
            if (j > 0 && !visited[i,j - 1])
            {
                unvistedNeighbours.Add(new int[] { i - 1, j });
            }

            //if the right node is not visited add into unvistedNeighbours
            if (j < matrix.GetLength(1) - 1 && !visited[i,j + 1])
            {
                unvistedNeighbours.Add(new int[] { i, j + 1});
            }

            return unvistedNeighbours;
        }
    }
  }
