using Konves.Scripture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Konves.Scripture.Data;
using Konves.Scripture.Version;

namespace Konves.Scripture.Tests
{
    
    
    /// <summary>
    ///This is a test class for RangeTest and is intended
    ///to contain all RangeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RangeTest
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
        ///A test for GetRange
        ///</summary>
        [TestMethod()]
        public void GetRangeTest_Safe_Basic()
        {
            RawRange input = new RawRange
            {
                FirstBook = "gen",
                FirstChapterString = "1",
                FirstVerseString = "1",

                SecondBook = "gen",
                SecondChapterString = "1",
                SecondVerseString = "2"
            };

            RepositoryMode mode = RepositoryMode.Safe;
            Range expected = //null;
                new Range
            {
                Start = new Verse
                {
                    Index = 1,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 1,
                    Suffix = null
                },
                End = new Verse
                {
                    Index = 2,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 2,
                    Suffix = null

                }
            };
            Range actual;
            //actual = target.GetRange(s, mode);
            actual = Range.Create(si, input, mode);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetRangeTest_Optimistic_ChapterTooLarge()
        {
            RawRange input = new RawRange
            {
                FirstBook = "gen",
                FirstChapterString = "1",
                FirstVerseString = null,

                SecondBook = "gen",
                SecondChapterString = "90",
                SecondVerseString = null
            };

            RepositoryMode mode = RepositoryMode.Optimistic;
            Range expected = new Range
            {
                Start = new Verse
                {
                    Index = 1,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 1,
                    Suffix = null
                },
                End = new Verse
                {
                    Index = 1533,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 50,
                    VerseNumber = 26,
                    Suffix = null

                }
            };
            Range actual;
            //actual = target.GetRange(s, mode);
            actual = Range.Create(si, input, mode);
            Assert.AreEqual(expected, actual);
        }

        /*[TestMethod()]
        public void GetRangeTest_Strict_ChapterTooLarge()
        {
            Repository_Accessor target = new Repository_Accessor();

            RawRange_Accessor s = new RawRange_Accessor
            {
                FirstBook = "gen",
                FirstChapterString = "1",
                FirstVerseString = null,

                SecondBook = "gen",
                SecondChapterString = "90",
                SecondVerseString = null
            };

            RepositoryMode mode = RepositoryMode.Strict;
            Range expected = null;
            //RangeInfo expected = new RangeInfo
            //{
            //    Start = new Verse
            //    {
            //        Index = 0,
            //        BookName = "Genesis",
            //        BookNumber = 1,
            //        ChapterNumber = 1,
            //        VerseNumber = 1,
            //        Suffix = null
            //    },
            //    End = new Verse
            //    {
            //        Index = 30,
            //        BookName = "Genesis",
            //        BookNumber = 1,
            //        ChapterNumber = 1,
            //        VerseNumber = 31,
            //        Suffix = null

            //    }
            //};
            Range actual;
            //actual = target.GetRange(s, mode);
            actual = Range_Accessor.Create(s, mode);
            Assert.AreEqual(expected, actual);
        }*/

        /*[TestMethod()]
        public void GetRangeTest1()
        {
            Repository_Accessor target = new Repository_Accessor();

            RawRange_Accessor s = new RawRange_Accessor
            {
                FirstBook = "gen",
                FirstChapterString = "1",
                FirstVerseString = "1",

                SecondBook = "gen",
                SecondChapterString = "1",
                SecondVerseString = "2"
            };



            RepositoryMode mode = RepositoryMode.Strict;
            Range expected = new Range
            {
                Start = new Verse
                {
                    Index = 1,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 1,
                    Suffix = null
                },
                End = new Verse
                {
                    Index = 2,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 2,
                    Suffix = null

                }
            };
            Range actual;
            //actual = target.GetRange(s, mode);
            actual = Range_Accessor.Create(s, mode);
            Assert.AreEqual(expected, actual);
        }*/

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest1()
        {
            Range target = new Range
            {
                Start = new Verse
                {
                    Index=0,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber =1,
                    Suffix=null
                },
                End = new Verse
                {
                    Index = 0,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 1,
                    Suffix = null
                }, 
            };
            string expected = "Genesis 1:1";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest2()
        {
            Range target = new Range
            {
                Start = new Verse
                {
                    Index = 0,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 1,
                    Suffix = null
                },
                End = new Verse
                {
                    Index = 2,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 6,
                    VerseNumber = 22,
                    Suffix = null
                },
            };
            string expected = "Genesis 1:1-6:22";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest3()
        {
            Range target = new Range
            {
                Start = new Verse
                {
                    Index = 0,
                    BookName = "Genesis",
                    BookNumber = 1,
                    ChapterNumber = 1,
                    VerseNumber = 1,
                    Suffix = null
                },
                End = new Verse
                {
                    Index = 2,
                    BookName = "Exodus",
                    BookNumber = 2,
                    ChapterNumber = 26,
                    VerseNumber = 37,
                    Suffix = null
                },
            };
            string expected = "Genesis 1:1 - Exodus 26:37";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
