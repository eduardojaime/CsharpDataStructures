/*
	Starts at a first vertex and trie to visit vertices as close to the first as possible.
	
	Steps
	1) Pick starting point, visit and push to queue
	2) Find an unvisited vertex adjacent to current one, visit and add to queue
	3) If there are no unvisited adjacent vertices, remove one from the queue, make it current and start over
	4) Finish when queue is empty
*/



public void BreadthFirstSearch(int startVertex)
{
	gQueue.Clear();
	vertices[startVertex].wasVisited = true;
	ShowVertex(startVertex);
	gQueue.Enqueue(startVertex);
	
	int currVert, adjVert;
	while (gQueue.Count > 0)
	{
		currVert = (int)gQueue.Dequeue();
		adjVert = GetNextUnvisitedAdjacentNode(currVert);
        
		while (adjVert != -1)
		{
			vertices[adjVert].wasVisited = true;
			ShowVertex(adjVert);
			gQueue.Enqueue(adjVert);
			// Next run will be with next adjacent vertex
			adjVert = GetNextUnvisitedAdjacentNode(currVert);				
		}
	}
	for (int i = 0; i < numVerts; i++)
		vertices[i].wasVisited = false;
}