using Konves.Scripture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Konves.Scripture.Version;
using System.Collections.Generic;
using System.Linq;

namespace Konves.Scripture.Tests
{
    
    
    /// <summary>
    ///This is a test class for VerseCollectionTest and is intended
    ///to contain all VerseCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerseCollectionTest
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

        static ScriptureInfo si;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            ScriptureInfo.TryRegister("esv", @"e:\Users\Stephen\Desktop\SRP\trunk\Konves.Scripture\Data\esv.xml");
            si = ScriptureInfo.GetInstance("esv");
        }
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
        ///A test for GetVerseSummaries
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Konves.Scripture.dll")]
        public void GetVerseSummariesTest()
        {
            IEnumerable<ScriptureInfo.ChapterLimitsCollection> chapterLimits = new ScriptureInfo.ChapterLimitsCollection[]
            {
                new ScriptureInfo.ChapterLimitsCollection{
                    BookNumber = 1,
                    ChapterNumber = 1,

                    StartVerseIndex = 0,
                    EndVerseIndex = 9,
                    EndVerseNumber =10
                },
                new ScriptureInfo.ChapterLimitsCollection{
                    BookNumber = 1,
                    ChapterNumber = 2,

                    StartVerseIndex = 10,
                    EndVerseIndex = 19,
                    EndVerseNumber =20
                },
                new ScriptureInfo.ChapterLimitsCollection{
                    BookNumber = 1,
                    ChapterNumber = 3,

                    StartVerseIndex = 20,
                    EndVerseIndex = 29,
                    EndVerseNumber =30
                }
            };
            IEnumerable<Reference_Accessor.VerseSummary> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Reference_Accessor.VerseSummary> actual;
            actual = Reference_Accessor.GetVerseSummaries(chapterLimits, 4);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for Length
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Konves.Scripture.dll")]
        public void LengthTest()
        {
            string referenceString = "ps 64";
            Reference target = Reference.Parse(referenceString, si);
            int expected = 10; 
            int actual;
            actual = target.Length;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Reference Constructor
        ///</summary>
        [TestMethod()]
        public void VerseCollectionConstructorTest()
        {
            string referenceString = "john 3,8";
            Reference target = Reference.Parse(referenceString, si);

            var x = target.GetSubReferences();

            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
