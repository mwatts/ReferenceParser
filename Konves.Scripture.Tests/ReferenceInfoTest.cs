//using Konves.Scripture;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using Konves.Scripture.Data;
//using Konves.Scripture.Version;

//namespace Konves.Scripture.Tests
//{
//    /// <summary>
//    ///This is a test class for ReferenceInfoTest and is intended
//    ///to contain all ReferenceInfoTest Unit Tests
//    ///</summary>
//    [TestClass()]
//    public class ReferenceTest
//    {
//        private TestContext testContextInstance;

//        /// <summary>
//        ///Gets or sets the test context which provides
//        ///information about and functionality for the current test run.
//        ///</summary>
//        public TestContext TestContext
//        {
//            get
//            {
//                return testContextInstance;
//            }
//            set
//            {
//                testContextInstance = value;
//            }
//        }

//        static ScriptureInfo si;

//        #region Additional test attributes
//        // 
//        //You can use the following additional attributes as you write your tests:
//        //
//        //Use ClassInitialize to run code before running the first test in the class
//        [ClassInitialize()]
//        public static void MyClassInitialize(TestContext testContext)
//        {
//            ScriptureInfo.TryRegister("esv", @"e:\Users\Stephen\Desktop\SRP\trunk\Konves.Scripture\Data\esv.xml");
//            si = ScriptureInfo.GetInstance("esv");
//        }
//        //
//        //Use ClassCleanup to run code after all tests in a class have run
//        //[ClassCleanup()]
//        //public static void MyClassCleanup()
//        //{
//        //}
//        //
//        //Use TestInitialize to run code before running each test
//        //[TestInitialize()]
//        //public void MyTestInitialize()
//        //{
//        //}
//        //
//        //Use TestCleanup to run code after each test has run
//        //[TestCleanup()]
//        //public void MyTestCleanup()
//        //{
//        //}
//        //
//        #endregion

//        [TestMethod()]
//        public void ParseTest_Single()
//        {
//            string reference = "John 3:16";
//            RepositoryMode mode = RepositoryMode.Safe;
//            RangeCollection_OBE expected = new RangeCollection_OBE();

//            expected.Add(new Range
//            {
//                Start = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26126,
//                    Suffix = null,
//                    VerseNumber = 16
//                },
//                End = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26126,
//                    Suffix = null,
//                    VerseNumber = 16
//                }
//            });

//            RangeCollection_OBE actual;
//            actual = RangeCollection_OBE.Parse(reference, si, mode);

//            RangeCollection_OBE.EqualityComparer eq = new RangeCollection_OBE.EqualityComparer();
//            Assert.IsTrue(eq.Equals(expected, actual));

//        }

//        [TestMethod()]
//        public void ParseTest_MultipleVerses()
//        {
//            string reference = "john 3:16-18,20";
//            RangeCollection_OBE expected = new RangeCollection_OBE();
//            expected.Add(new Range
//            {
//                Start = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26126,
//                    Suffix = null,
//                    VerseNumber = 16
//                },
//                End = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26128,
//                    Suffix = null,
//                    VerseNumber = 18
//                }
//            });

//            expected.Add(new Range
//            {
//                Start = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26130,
//                    Suffix = null,
//                    VerseNumber = 20
//                },
//                End = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26130,
//                    Suffix = null,
//                    VerseNumber = 20
//                }
//            });

//            RangeCollection_OBE actual;
//            actual = RangeCollection_OBE.Parse(reference, si);

//            RangeCollection_OBE.EqualityComparer eq = new RangeCollection_OBE.EqualityComparer();
//            Assert.IsTrue(eq.Equals(expected, actual));

//        }

//        [TestMethod()]
//        public void ParseTest_MultipleChaptersAndVerses()
//        {
//            string reference = "john 3:16-18,4:15-16";
//            RangeCollection_OBE expected = new RangeCollection_OBE();
//            expected.Add(new Range
//            {
//                Start = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26126,
//                    Suffix = null,
//                    VerseNumber = 16
//                },
//                End = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 3,
//                    Index = 26128,
//                    Suffix = null,
//                    VerseNumber = 18
//                }
//            });

//            expected.Add(new Range
//            {
//                Start = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 4,
//                    Index = 26161,
//                    Suffix = null,
//                    VerseNumber = 15
//                },
//                End = new Verse
//                {
//                    BookName = "John",
//                    BookNumber = 43,
//                    ChapterNumber = 4,
//                    Index = 26162,
//                    Suffix = null,
//                    VerseNumber = 16
//                }
//            });

//            RangeCollection_OBE actual;
//            actual = RangeCollection_OBE.Parse(reference, si);

//            RangeCollection_OBE.EqualityComparer eq = new RangeCollection_OBE.EqualityComparer();
//            Assert.IsTrue(eq.Equals(expected, actual));

//        }

//        [TestMethod()]
//        public void ToStringTest_1()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1, rom 5:8", si);
//            string expected = "Genesis 1:1; Romans 5:8";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_2()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1; gen 1:3", si);
//            string expected = "Genesis 1:1,3";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_3()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1, 3-5", si);
//            string expected = "Genesis 1:1,3-5";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_4()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1, 5:3", si);
//            string expected = "Genesis 1:1,5:3";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_5()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1, 5:3-13", si);
//            string expected = "Genesis 1:1,5:3-13";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_6()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1,3-5:8", si);
//            string expected = "Genesis 1:1,3-5:8";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_7()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1,3- romans 5:8", si);
//            string expected = "Genesis 1:1,3 - Romans 5:8";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_8()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1, 5:3-6:1", si);
//            string expected = "Genesis 1:1,5:3-6:1";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod()]
//        public void ToStringTest_9()
//        {
//            RangeCollection_OBE target = RangeCollection_OBE.Parse("Gen 1:1, 5:3- romans 6:1", si);
//            string expected = "Genesis 1:1,5:3 - Romans 6:1";
//            string actual;
//            actual = target.ToString();
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
