using System;
using System.Collections.Generic;

namespace NoWeightGraphTests
{
    public static class NoWeightGraphTestData
    {
        private static readonly List<object[]> _data = new List<object[]>
            {
                 new object[]{
                     new string[]{"A", "B", "C", "D", "E", "F" },
                     new Tuple<string, string>[] {
                        new Tuple<string, string>("A", "C"),
                        new Tuple<string, string>("A","E"),
                        new Tuple<string, string>("C", "B"),
                        new Tuple<string, string>("C","D"),
                        new Tuple<string, string>("C", "F"),
                        new Tuple<string, string>("B", "F"),
                        new Tuple<string, string>("D","F"),
                        new Tuple<string, string>("F", "E")
                     },
                     new string[][] { new string[] { "A" }, new string[] { "C", "E", }, new string[] { "D", "F", "B" } }
                 },

                 new object[]{
                     new string[]{"A", "B", "C", "D", "E", "F" },
                     new Tuple<string, string>[] {
                        new Tuple<string, string>("B", "F"),
                        new Tuple<string, string>("D","F"),
                        new Tuple<string, string>("F", "E"),
                        new Tuple<string, string>("A", "C"),
                        new Tuple<string, string>("A","E"),
                        new Tuple<string, string>("C","D"),
                        new Tuple<string, string>("C", "B"),
                        new Tuple<string, string>("C", "F"),
                     },
                     new string[][] { new string[] {"A"},  new string[] { "C", "E",}, new string[] { "D", "F" ,"B"} }
                 },
                 new object[]{
                     new string[]{},
                     new Tuple<string, string>[] {
                     },
                     new string[][] { }
                 },
            };

        public static IEnumerable<object[]> TestData
        {
            get => _data;
        }
    }
}
