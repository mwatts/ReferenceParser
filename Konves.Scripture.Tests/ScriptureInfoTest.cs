using Konves.Scripture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Konves.Scripture.Data;
using Konves.Scripture.Version;

namespace Konves.Scripture.Tests
{
    
    
    /// <summary>
    ///This is a test class for ScriptureInfoTest and is intended
    ///to contain all ScriptureInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScriptureInfoTest
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
        ///A test for GetBookName
        ///</summary>
        [TestMethod()]
        public void GetBookNameTest()
        {
            string abbr = "gen";
            string expected = "Genesis";
            string actual;
            actual = si.GetBookName(abbr);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetBookId
        ///</summary>
        [TestMethod()]
        public void GetBookNumberTest()
        {
            string abbr = "1th";
            int expected = 52;
            int actual;
            actual = si.GetBookNumber(abbr);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBookInfo_AccessorTest1()
        {
            int bookId = 1;

            BookInfo expected = new BookInfo
            {
                Number = 1,
                Name = "Genesis"
            };
            BookInfo actual;
            actual = si.GetBookInfo(bookId);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBookInfo_AccessorTest2()
        {
            string abbr = "Gen";
            BookInfo expected = new BookInfo
            {
                Number = 1,
                Name = "Genesis"
            };
            BookInfo actual;
            actual = si.GetBookInfo(abbr);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBookInfo_AccessorTest3()
        {
            string abbr = "Genesis";
            BookInfo expected = new BookInfo
            {
                Number = 1,
                Name = "Genesis"
            };
            //BookInfo_Accessor actual;
            BookInfo actual;
            actual = si.GetBookInfo(abbr);
            Assert.AreEqual(expected, actual);
        }


        #region GetLastChapterTest
        [TestMethod()]
        public void GetLastChapterTest()
        {
            int bookId = 1;
            int expected = 50;
            int actual;
            actual = si.GetLastChapter(bookId);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLastChapterTest_OutOfRange1()
        {
            int bookId = 0;
            int actual;
            actual = si.GetLastChapter(bookId);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLastChapterTest_OutOfRange2()
        {
            int bookId = 74;
            int actual;
            actual = si.GetLastChapter(bookId);
        } 
        #endregion

        #region GetLastVerseTest
        [TestMethod()]
        public void GetLastVerseTest()
        {
            int bookId = 16; // nehemiah
            int chapter = 11;
            int expected = 36;
            int actual;
            actual = si.GetLastVerse(bookId, chapter);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLastVerseTest_Chapter_OutOfRange1()
        {
            int bookId = 16; // nehemiah
            int chapter = 14; // max is 13
            int actual;
            actual = si.GetLastVerse(bookId, chapter);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLastVerseTest_Chapter_OutOfRange2()
        {
            int bookId = 16; // nehemiah
            int chapter = 0;
            int actual;
            actual = si.GetLastVerse(bookId, chapter);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLastVerseTest_BookId_OutOfRange1()
        {
            int bookId = 0;
            int chapter = 14;
            int actual;
            actual = si.GetLastVerse(bookId, chapter);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetLastVerseTest_BookId_OutOfRange2()
        {
            int bookId = 75; // too large
            int chapter = 1;
            int actual;
            actual = si.GetLastVerse(bookId, chapter);
        } 
        #endregion

    }
}
