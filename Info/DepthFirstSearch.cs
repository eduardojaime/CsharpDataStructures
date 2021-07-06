/*
	Following a path from the beginning vertex until it reaches the last.
	Then backtracking and following the next path until it reaches the last vertex.
	Until there are no more paths left.
	
	Steps
	1) Pick starting point, visit and push to stack
	2) Get next unvisited, visit and push to stack
	3) Continue until you find last vertex, when there are no more unvisited adjacent vertices
	4) Pop from stack, and repeat from step 2
	5) Finish when stack is empty
*/
public void DepthFirstSearch(int startVertex)	{
	gStack.Clear();
	vertices[startVertex].wasVisited = true;
	ShowVertex(startVertex);
	gStack.Push(startVertex); // pushing the position
	
	int currVert, adjVert;
	while (gStack.Count > 0)
	{
		// get next from whatever it is in the stack
		// that's our current vertex
        currVert = (int)gStack.Peek();
		adjVert = GetNextUnvisitedAdjacentNode(currVert);
		// no more adjacent unvisited
		if (adjVert == -1)
			gStack.Pop();
		else
		{
			// next run this will be the current node
			vertices[adjVert].wasVisited = true;
			ShowVertex(adjVert);
			gStack.Push(adjVert);
		}
	}
	for (int i = 0; i < numVerts; i++)
		vertices[i].wasVisited = false;
}