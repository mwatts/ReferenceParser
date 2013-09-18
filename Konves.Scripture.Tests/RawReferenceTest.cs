using Konves.Scripture.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Konves.Scripture.Tests
{
    
    
    /// <summary>
    ///This is a test class for RawReferenceTest and is intended
    ///to contain all RawReferenceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RawReferenceTest
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


        /// <summary>
        ///A test for Parse
        ///</summary>
        [TestMethod()]
        public void ParseTest()
        {
            string input = "john 3:16; gen 20-21";
            RawReference expected = new RawReference();

            expected.Add(new RawRange
            {                
                FirstBook="john",
                FirstChapter=3,
                FirstVerse=16,
                FirstVerseSuffix=null,
                IsFirstBookExplicit = true,
                SecondBook = "john",
                SecondChapter = 3,
                SecondVerse = 16,
                SecondVerseSuffix = null
            });

            expected.Add(new RawRange
            {
                FirstBook = "gen",
                FirstChapter = 20,
                FirstVerseString = null,
                FirstVerseSuffix = null,
                IsFirstBookExplicit = true,
                SecondBook = "gen",
                SecondChapter = 21,
                SecondVerseString = null,
                SecondVerseSuffix = null
            });

            RawReference actual;
            actual = RawReference.Parse(input);
            CollectionAssert.AreEquivalent(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Parse
        ///</summary>
        [TestMethod()]
        public void ParseTest2()
        {
            string input = "john 3:16; gen 20-21,24";
            RawReference expected = new RawReference();

            expected.Add(new RawRange
            {
                FirstBook = "john",
                FirstChapter = 3,
                FirstVerse = 16,
                FirstVerseSuffix = null,
                IsFirstBookExplicit = true,
                SecondBook = "john",
                SecondChapter = 3,
                SecondVerse = 16,
                SecondVerseSuffix = null
            });

            expected.Add(new RawRange
            {
                FirstBook = "gen",
                FirstChapter = 20,
                FirstVerseString = null,
                FirstVerseSuffix = null,
                IsFirstBookExplicit = true,
                SecondBook = "gen",
                SecondChapter = 21,
                SecondVerseString = null,
                SecondVerseSuffix = null
            });

            expected.Add(new RawRange
            {
                FirstBook = "gen",
                FirstChapter = 24,
                FirstVerseString = null,
                FirstVerseSuffix = null,
                IsFirstBookExplicit = false,
                SecondBook = "gen",
                SecondChapter = 24,
                SecondVerseString = null,
                SecondVerseSuffix = null
            });

            RawReference actual;
            actual = RawReference.Parse(input);
            CollectionAssert.AreEquivalent(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
