using Konves.Scripture.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Konves.Scripture.Tests
{    
    /// <summary>
    ///This is a test class for RawVerseTest and is intended
    ///to contain all RawVerseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RawVerseTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseTest_null()
        {
            string input = null;
            RawVerse actual;
            actual = RawVerse.Parse(input);
        }

        [TestMethod()]
        public void ParseTest1()
        {
            string input = string.Empty;
            RawVerse expected = new RawVerse { HasValue = false, Book = null, N1 = null, N2 = null, NumberCount = 0 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest2()
        {
            string input = "2 jn";
            RawVerse expected = new RawVerse { HasValue = true, Book = "2 jn", N1 = null, N2 = null, NumberCount = 0 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest3a()
        {
            string input = "2 jn 3";
            RawVerse expected = new RawVerse { HasValue = true, Book = "2 jn", N1 = "3", N2 = null, NumberCount = 1 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest3b()
        {
            string input = "2 jn 3:";
            RawVerse expected = new RawVerse { HasValue = true, Book = "2 jn", N1 = "3", N2 = null, NumberCount = 1 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest4()
        {
            string input = "2 jn 3:16";
            RawVerse expected = new RawVerse { HasValue = true, Book = "2 jn", N1 = "3", N2 = "16", NumberCount = 2 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest5()
        {
            string input = " 3:16";
            RawVerse expected = new RawVerse { HasValue = true, Book = null, N1 = "3", N2 = "16", NumberCount = 2 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest6()
        {
            string input = " 16";
            RawVerse expected = new RawVerse { HasValue = true, Book = null, N1 = "16", N2 = null, NumberCount = 1 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest7()
        {
            string input = "    ";
            RawVerse expected = new RawVerse { HasValue = false, Book = null, N1 = null, N2 = null, NumberCount = 0 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest8()
        {
            string input = "jn 3 : 16";
            RawVerse expected = new RawVerse { HasValue = true, Book = "jn", N1 = "3", N2 = "16", NumberCount = 2 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest9()
        {
            string input = "jn 3 : 16a";
            RawVerse expected = new RawVerse { HasValue = true, Book = "jn", N1 = "3", N2 = "16a", NumberCount = 2 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest10()
        {
            string input = "jn 3 : 16d";
            RawVerse expected = new RawVerse { HasValue = true, Book = "jn", N1 = "3", N2 = "16", NumberCount = 2 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest11()
        {
            string input = "jn 3a : 16";
            RawVerse expected = new RawVerse { HasValue = true, Book = "jn", N1 = "3a", N2 = "16", NumberCount = 2 };
            RawVerse actual;
            actual = RawVerse.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
