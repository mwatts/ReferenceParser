using Konves.Scripture.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Konves.Scripture.Tests
{
/// <summary>
///This is a test class for RawRangeTest and is intended
///to contain all RawRangeTest Unit Tests
///</summary>
    [TestClass()]
    public class RawRangeTest
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
        ///A test for FirstVerseString
        ///</summary>
        [TestMethod()]
        public void FirstVerseStringTest()
        {
            RawRange target = new RawRange(); 
            string expected = null;
            string actual;
            target.FirstVerseString = expected;
            target.FirstVerseSuffix = null;
            actual = target.FirstVerseString;
            Assert.AreEqual(expected, actual);
        }
    }
    
    
    /// <summary>
    ///This is a test class for RangePartsTest and is intended
    ///to contain all RangePartsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RawRangeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

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
            RawRange actual;
            actual = RawRange.Parse(null, null, null, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseTest_NoBook()
        {
            RawRange actual;
            actual = RawRange.Parse("3:16-john 3:17", null, null, null);
        }


        [TestMethod()]
        public void ParseTest_VerseRange()
        {
            string block = "acts 5:4-9";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
                {
                    FirstBook = "acts",
                    FirstChapterString = "5",
                    FirstVerseString = "4",
                    FirstVerse = 4,
                    SecondBook = "acts",
                    SecondChapterString = "5",
                    SecondVerseString = "9",
                    SecondVerse = 9
                };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_Basic()
        {
            string block = "john 3:16";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = "16",
                SecondBook = "john",
                SecondChapterString = "3",
                SecondVerseString = "16"
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_Basic_CurrentBook()
        {
            string block = "3:16";
            string currentBook = "john";
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = "16",
                SecondBook = "john",
                SecondChapterString = "3",
                SecondVerseString = "16"
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_Basic_CurrentBookAndChapter()
        {
            string block = "16";
            string currentBook = "john";
            string currentChapter = "3";
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "16",
                FirstVerseString = null,
                SecondBook = "john",
                SecondChapterString = "16",
                SecondVerseString = null
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_BookOnly()
        {
            string block = "luke";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
            {
                FirstBook = "luke",
                FirstChapterString = null,
                FirstVerseString = null,
                SecondBook = "luke",
                SecondChapterString = null,
                SecondVerseString = null
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_BookRange()
        {
            string block = "luke - acts";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
            {
                FirstBook = "luke",
                FirstChapterString = null,
                FirstVerseString = null,
                SecondBook = "acts",
                SecondChapterString = null,
                SecondVerseString = null
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_BookRangeWithOneChapter()
        {
            string block = "luke - acts 9";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
            {
                FirstBook = "luke",
                FirstChapterString = null,
                FirstVerseString = null,
                SecondBook = "acts",
                SecondChapterString = "9",
                SecondVerseString = null
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_ChapterVerseRange()
        {
            string block = "john 3:16 - 5:34";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;
            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = "16",
                SecondBook = "john",
                SecondChapterString = "5",
                SecondVerseString = "34"
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_ChapterRangeWithVerse()
        {
            string block = "john 3-5:34";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;

            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = null,
                SecondBook = "john",
                SecondChapterString = "5",
                SecondVerseString = "34"
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_BookChapterVerseRange_CurrentBook()
        {
            string block = "3:5-john 4:34";
            string currentBook = "jn";
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;

            RawRange expected = new RawRange
            {
                FirstBook = "jn",
                FirstChapterString = "3",
                FirstVerseString = "5",
                SecondBook = "john",
                SecondChapterString = "4",
                SecondVerseString = "34"
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_ChapterRange()
        {
            string block = "john 12-3";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;

            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "12",
                FirstVerseString = null,
                SecondBook = "john",
                SecondChapterString = "13",
                SecondVerseString = null
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_VerseRange_ShortVerse()
        {
            string block = "john 3:16-7";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;

            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = "16",
                SecondBook = "john",
                SecondChapterString = "3",
                SecondVerseString = "17"
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ParseTest_VerseSuffixRange_ShortVerse()
        {
            string block = "john 3:16b-7a";
            string currentBook = string.Empty;
            string currentChapter = string.Empty;
            string currentVerse = string.Empty;

            RawRange expected = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = "16b",
                SecondBook = "john",
                SecondChapterString = "3",
                SecondVerseString = "17a"
            };
            RawRange actual;
            actual = RawRange.Parse(block, currentBook, currentChapter, currentVerse);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            RawRange target1 = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = "16",
                SecondBook = "john",
                SecondChapterString = "3",
                SecondVerseString = "16"
            };

            RawRange target2 = new RawRange
            {
                FirstBook = "john",
                FirstChapterString = "3",
                FirstVerseString = "16",
                SecondBook = "john",
                SecondChapterString = "16",
                SecondVerseString = "3"
            };

            int actual1 = target1.GetHashCode();
            int actual2 = target2.GetHashCode();

            Assert.AreNotEqual(actual1, actual2);
        }

        [TestMethod()]
        [DeploymentItem("Konves.Text.BibleReference.dll")]
        public void ParseVerseStringTest_null()
        {
            string input = "";
            int verse = 0;
            int verseExpected = -1; 
            string suffix = string.Empty; 
            string suffixExpected = null; 
            RawRange.ParseVerseString(input, out verse, out suffix);
            Assert.AreEqual(verseExpected, verse);
            Assert.AreEqual(suffixExpected, suffix);
        }

        [TestMethod()]
        [DeploymentItem("Konves.Text.BibleReference.dll")]
        [ExpectedException(typeof(FormatException))]
        public void ParseVerseStringTest_FormatException1()
        {
            string input = "a";
            int verse = 0;
            string suffix = string.Empty;
            RawRange.ParseVerseString(input, out verse, out suffix);
        }

        [TestMethod()]
        [DeploymentItem("Konves.Text.BibleReference.dll")]
        [ExpectedException(typeof(FormatException))]
        public void ParseVerseStringTest_FormatException2()
        {
            string input = "3d";
            int verse = 0;
            string suffix = string.Empty;
            RawRange.ParseVerseString(input, out verse, out suffix);
        }

        [TestMethod()]
        [DeploymentItem("Konves.Text.BibleReference.dll")]
        [ExpectedException(typeof(FormatException))]
        public void ParseVerseStringTest_FormatException3()
        {
            string input = "3da";
            int verse = 0;
            string suffix = string.Empty;
            RawRange.ParseVerseString(input, out verse, out suffix);
        }

        [TestMethod()]
        [DeploymentItem("Konves.Text.BibleReference.dll")]
        public void ParseVerseStringTest()
        {
            string input = "3a";
            int verse = 0;
            int verseExpected = 3;
            string suffix = string.Empty;
            string suffixExpected = "a";
            RawRange.ParseVerseString(input, out verse, out suffix);
            Assert.AreEqual(verseExpected, verse);
            Assert.AreEqual(suffixExpected, suffix);
        }

        [TestMethod()]
        public void FirstVerseStringTest2()
        {
            RawRange target = new RawRange();
            target.FirstVerseString = "3a";
            int expectedFirstVerse = 3;
            string expectedFirstVerseSuffix = "a";
            int actualFirstVerse;
            actualFirstVerse = target.FirstVerse;
            string actualFirstVerseSuffix;
            actualFirstVerseSuffix = target.FirstVerseSuffix;
            Assert.AreEqual(expectedFirstVerse, actualFirstVerse);
            Assert.AreEqual(expectedFirstVerseSuffix, actualFirstVerseSuffix);
        }
    }
}
