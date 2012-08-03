namespace TreeExtensons.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TreeExtensions;
    using System.Linq;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void FilterRemovesNonMatchingItems()
        {
            // Set up a tree
            var subject = new TreeImplementation {Number = 5};
            
            var goodChild = new TreeImplementation { Number = 5 };
            subject.ChildrenList.Add(goodChild);
            
            var badChild = new TreeImplementation { Number = 1 };
            subject.ChildrenList.Add(badChild);

            var list = new List<TreeImplementation> {subject};

            var result = list.Filter(i => i.Number > 1).ToArray();

            Assert.IsTrue(result.Count() == 1);

            Assert.IsTrue(result.Single().Children.Count() == 1);

            Assert.AreEqual(result.Single().Children.Single(), goodChild);
        }

        [TestMethod]
        public void FlattenPutsAllItemsIntoSingleLevel()
        {
            var subject = TreeImplementation.GenerateTree(new Random().Next(3, 5));

            var tree = subject.Item1;
            var count = subject.Item2;

            Console.WriteLine("Total items: {0}", count);

            var result = tree.Flatten();

            Assert.AreEqual(count, result.Count());
        }

        [TestMethod]
        public void ApplyWorksOnAllLevelsOfTree()
        {
            const int number = 9;

            var subject = TreeImplementation.GenerateTree(new Random().Next(3, 5));

            var tree = subject.Item1;

            
            tree.Apply(i => i.Number = number);

            var flat = tree.Flatten();

            foreach (var treeImplementation in flat)
            {
                Assert.AreEqual(number, treeImplementation.Number);
            }
        }
    }
}
