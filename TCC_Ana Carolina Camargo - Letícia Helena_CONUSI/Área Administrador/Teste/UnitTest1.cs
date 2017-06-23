using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarId()
        {
            var id = 1;

            if (id == null || id == 0)
            {
                id = 2;
            }

            Assert.AreEqual(1,id);
        }
    }
}
