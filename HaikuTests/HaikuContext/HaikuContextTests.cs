using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haiku.HaikuContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haiku.HaikuContext.Tests
{
    [TestClass()]
    public class HaikuContextTests
    {
        [TestMethod()]
        public void CheckIfHikauIsValidYESTest()
        {
            //Passed for Y
            HaikuContext l_HaikuContext = new HaikuContext();
            List<int> l_HaikuData = new List<int>();
            string l_HikauResult = string.Empty;

            l_HaikuData.Add(5);
            l_HaikuData.Add(7);
            l_HaikuData.Add(5);

            l_HikauResult = l_HaikuContext.CheckIfHikauIsValid(l_HaikuData);

            Assert.AreEqual("Y", l_HikauResult);
            
        }

        [TestMethod()]
        public void CheckIfHikauIsValidNOTest()
        {
            //Passed for Y
            HaikuContext l_HaikuContext = new HaikuContext();
            List<int> l_HaikuData = new List<int>();
            string l_HikauResult = string.Empty;

            l_HaikuData.Add(5);
            l_HaikuData.Add(8);
            l_HaikuData.Add(5);

            l_HikauResult = l_HaikuContext.CheckIfHikauIsValid(l_HaikuData);

            Assert.AreEqual("N", l_HikauResult);
        }
    }
}