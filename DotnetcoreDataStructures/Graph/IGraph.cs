using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetcoreDataStructures.Graph
{
    interface IGraph<T>
    {
        // Basic functions
        void AddVertex(T value);

        void AddEdge(int vertexIndex1, int vertexIndex2);

        void ShowVertex(int vertexIndex);

        void DeleteVertex(int vertexIndex);

        void MoveRow(int row, int length);

        void MoveCol(int row, int length);

        int GetNextNodeWithoutSuccessor();

        int GetNextUnvisitedAdjacentNode(int vertexIndex);

        // Search Methods
        void DepthFirstSearch(int startVertex);

        void BreadthFirstSearch(int startVertex);

        // View AdjMatrix
        void PrintAdjMatrix();


        // Sort Methods
        void TopSort();

        void BottomSort();


    }
}
