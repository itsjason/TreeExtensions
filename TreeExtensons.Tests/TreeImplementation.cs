namespace TreeExtensons.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TreeExtensions;

    internal class TreeImplementation : ITree<TreeImplementation>
    {
        public TreeImplementation()
        {
            ChildrenList = new List<TreeImplementation>();
        }

        public List<TreeImplementation> ChildrenList { get; private set; }
        public int Number { get; set; }

        public TreeImplementation[] Children
        {
            get { return ChildrenList.ToArray(); }
            set { ChildrenList = value.ToList(); }
        }

        public static Tuple<TreeImplementation[], int> GenerateTree(int depth, int existingItems = 0)
        {
            existingItems += 1;

            if(depth == 0)
                return null;

            var rand = new Random();
            var root = new TreeImplementation() {Number = rand.Next(1, 10)};
            var numberOfChildrenToAdd = rand.Next(1, 10);

            for (var i = 0; i < numberOfChildrenToAdd; i++)
            {
                var childTuple = GenerateTree(depth - 1);
                if (childTuple != null)
                {
                    root.ChildrenList.AddRange(childTuple.Item1);
                    existingItems += childTuple.Item2;
                }
            }

            return new Tuple<TreeImplementation[], int>(new[] {root}, existingItems);
        }
    }
}