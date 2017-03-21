using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SoftimizeMaster.Tests
{
    [TestClass]
    public class QuickAddCollectionTests : QuickCollectionTests
    {
        protected override QuickCollection<T> GetInstance<T>(IComparer<T> comparer)
        {
            return new QuickAddCollection<T>(comparer);
        }
    }
}
