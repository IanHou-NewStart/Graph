using System;
using System.Collections.Generic;
using System.Linq;


namespace DataStructsAndAlgorithm.Graph
{    

    public class NoWeightGraph<TVertex>
    {
        private const string NotVertexOfTheGraph = "Is not a vertex of the graph.";
        private readonly Dictionary<TVertex, List<TVertex>> _adjacencyList;

        public NoWeightGraph()
        {
            _adjacencyList = new Dictionary<TVertex, List<TVertex>>();
        }

        public bool IsEdge(TVertex sourceVertex, TVertex destinationVertex)
        {
            if (!IsVertext(sourceVertex)
                || !IsVertext(destinationVertex))
            {
                return false;
            }

            return _adjacencyList[sourceVertex].Contains(destinationVertex);
        }

        public bool AddVertex(TVertex vertex)
        {
            if (vertex != null)
            {
                if (!_adjacencyList.ContainsKey(vertex))
                {
                    _adjacencyList.Add(vertex, new List<TVertex>());
                    return true;
                }

                return false;
            }
            else
            {
                throw new ArgumentNullException(nameof(vertex));
            }
        }

        public IEnumerable<TVertex> GetNeighbors(TVertex vertex)
        {
            if(!_adjacencyList.ContainsKey(vertex))
            {
                throw new ArgumentException(nameof(vertex), NotVertexOfTheGraph);
            }

            return _adjacencyList[vertex];
        }

        private bool IsVertext(TVertex v)
        {
            return _adjacencyList.ContainsKey(v);
        }

        public bool AddEdge(TVertex sourceVertex, TVertex destinationVertex)
        {
            const string notVertextErrorInfo = NotVertexOfTheGraph;
            if (!IsVertext(sourceVertex))
            {
                throw new ArgumentException(nameof(sourceVertex), notVertextErrorInfo);
            }

            if(!IsVertext(destinationVertex))
            {
                throw new ArgumentNullException(nameof(destinationVertex), notVertextErrorInfo);
            }

            var list = _adjacencyList[sourceVertex];
            if(!list.Contains(destinationVertex))
            {
                list.Add(destinationVertex);
                return true;
            }

            return false;
        }

        public IEnumerable<TVertex> BFS(TVertex vertex)
        {
            if(vertex == null)
            {
                return Array.Empty<TVertex>();
            }

            if(!IsVertext(vertex))
            {
                throw new ArgumentException(nameof(vertex), NotVertexOfTheGraph);
            }

            var queue = new List<TVertex> { vertex };
            var visitedVertexs = new List<TVertex>();
            while(queue.Count > 0)
            {
                var visited = queue.Last();
                queue.Remove(visited);

                visitedVertexs.Add(visited);

                var neighbors = GetNeighbors(visited);
                foreach(var nv in neighbors)
                {
                    if(!visitedVertexs.Contains(nv))
                    {
                        queue.Add(nv);
                    }
                }
            }

            return visitedVertexs;
        }
    }
}
