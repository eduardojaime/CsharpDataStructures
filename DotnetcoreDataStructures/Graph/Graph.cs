using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetcoreDataStructures.Graph
{
    public class Graph<T> : IGraph<T>
    {
        private const int NUM_VERTICES = 20;
        private int numVertices;
        private Vertex<T>[] vertices;
        int[,] adjMatrix;
        int vertCount;
        //private List<T> vertices;
        //private List<List<int>> adjMatrix;
        //private int numVerts;

        Queue<Vertex<T>> topSortQueue = new Queue<Vertex<T>>();
        Stack<Vertex<T>> bottomSortStack = new Stack<Vertex<T>>();

        Stack<int> dfsStack = new Stack<int>();

        public Graph(int numVertices)
        {
            this.numVertices = numVertices;
            vertices = new Vertex<T>[numVertices];
            adjMatrix = new int[numVertices, numVertices];
            vertCount = 0;

            for (int i = 0; i < numVertices; i++)
                for (int j = 0; j < numVertices; j++)
                    adjMatrix[i, j] = 0;
        }

        public void AddEdge(int vertexIndex1, int vertexIndex2)
        {
            adjMatrix[vertexIndex1, vertexIndex2] = 1;
            // if this is a directed graph then add a two way reference
            // adjMatrix[vertexIndex2, vertexIndex1] = 1;
        }

        /// <summary>
        ///  To add a Vertex, add a new element to the array and increment the counter
        /// </summary>
        /// <param name="value"></param>
        public void AddVertex(T value)
        {
            vertices[vertCount] = new Vertex<T>(value);
            vertCount++;
        }

        /// <summary>
        /// To delete a vertex, delete a row and a column from the AdjMatrix and move values to the left to fill the void
        /// </summary>
        /// <param name="vertexIndex">Position of the Vertex to delete</param>
        public void DeleteVertex(int vertexIndex)
        {
            if (vertexIndex < numVertices)
            {
                for (int i = vertexIndex; i < vertCount; i++)
                    vertices[i] = vertices[i + 1];
                for (int row = vertexIndex; vertexIndex < vertCount; row++)
                    MoveRow(row, vertCount);
                for (int col = vertexIndex; vertexIndex < vertCount; col++)
                    MoveCol(col, vertCount);
            }
        }

        public void MoveCol(int row, int length)
        {
            throw new NotImplementedException();
        }

        public void MoveRow(int row, int length)
        {
            throw new NotImplementedException();
        }

        public void ShowVertex(int vertexIndex)
        {
            Console.WriteLine(vertices[vertexIndex].value.ToString());
        }

        /// <summary>
        /// A vertex with no successors will be found in the adjancency matrix on a row with all zeroes
        /// Search each colum row by row, move to the next row if a 1 is found
        /// if no 1 is found, return row name
        /// </summary>
        /// <returns>Position of the Vertex without successors</returns>
        public int GetNextNodeWithoutSuccessor()
        {
            for (int row = 0; row < numVertices; row++)
            {
                for (int col = 0; col < numVertices; col++)
                {
                    if (adjMatrix[row, col] > 0)
                    {
                        return row;
                    }
                }
            }
            return -1;
        }


        public int GetNextUnvisitedAdjacentNode(int vertexIndex)
        {
            for (int i = 0; i < vertCount; i++)
            {
                if (adjMatrix[vertexIndex, i] == 1 && vertices[i].isVisited == false)
                {
                    return i;
                }
            }
            return -1;
        }

        public void TopSort()
        {
            throw new NotImplementedException();
        }

        public void BottomSort()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Following a path from the beginning vertex until it reaches the last.
        /// Then backtracking and following the next path until it reaches the last vertex.
        /// Until there are no more paths left.

        /// Steps
        /// 1) Pick starting point, visit and push to stack
        /// 2) Get next unvisited, visit and push to stack
        /// 3) Continue until you find last vertex, when there are no more unvisited adjacent vertices
        /// 4) Pop from stack, and repeat from step 2
        /// 5) Finish when stack is empty
        /// </summary>
        /// <param name="startVertex"></param>
        public void DepthFirstSearch(int startVertex)
        {
            Vertex<T> currVert = vertices[startVertex];
            currVert.isVisited = true;
            // print value? maybe make a method called Visit which sets isvisited to true and prints label
            dfsStack.Push(startVertex);

            int nextIndex;
            while (dfsStack.Count > 0)
            {
                nextIndex = GetNextUnvisitedAdjacentNode(dfsStack.Peek());

                if (nextIndex == -1)
                    dfsStack.Pop();
                else
                {
                    currVert = vertices[nextIndex];
                    currVert.isVisited = true;
                    // print value

                }
            }

        }

        public void BreadthFirstSearch(int startVertex)
        {
            throw new NotImplementedException();
        }

        public void PrintMatrix()
        {
            throw new NotImplementedException();
        }

        public void PrintShortMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
