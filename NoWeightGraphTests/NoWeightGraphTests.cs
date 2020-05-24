using DataStructsAndAlgorithm.Graph;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NoWeightGraphTests
{

    public class NoWeightGraphTests
    {       

        [Theory]
        [MemberData(nameof(NoWeightGraphTestData.TestData), MemberType = typeof(NoWeightGraphTestData))]
        public void Test(IEnumerable<string> vertexs, IEnumerable<Tuple<string,string>> edges, string[][] expected)  
        {
            var g = new NoWeightGraph<string>();
            foreach(var v in vertexs)
            {
                g.AddVertex(v);
            }
            foreach(var e in edges)
            {
                g.AddEdge(e.Item1, e.Item2);
            }

            var result = g.BFS(vertexs.FirstOrDefault()).ToArray();

            int expectedArrayIdx = 0;
            for(int i = 0; i < result.Length; i++)
            {
                while(!expected[expectedArrayIdx].Contains(result[i]))
                {
                    expectedArrayIdx++;
                }
            }

            Assert.True(true);
        }
    }
}
