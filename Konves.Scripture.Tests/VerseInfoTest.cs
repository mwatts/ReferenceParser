using Konves.Scripture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Konves.Scripture.Data;
using Konves.Scripture.Version;

namespace Konves.Scripture.Tests
{
    
    
    /// <summary>
    ///This is a test class for VerseTest and is intended
    ///to contain all VerseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VerseTest
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


        #region GetVerseTest_Optimistic
        [TestMethod()]
        public void GetVerseTest_Optimistic_First_Normal()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = "b"
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_First_BadBook()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "not a book";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_First_BookOnly()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = -1;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 2747,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 1,
                VerseNumber = 1,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_First_NoVerse()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = -2;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 2832,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 1,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_First_ChapterTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5000;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 3605,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 27,
                VerseNumber = 34,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_First_VerseTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 5000;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_Last_Normal()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = "b"
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_Last_BadBook()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "not a book";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_Last_BookOnly()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = -1;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 3605,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 27,
                VerseNumber = 34,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_Last_NoVerse()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_Last_ChapterTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5000;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 3605,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 27,
                VerseNumber = 34,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Optimistic_Last_VerseTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 5000;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Optimistic;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GetVerseTest_Safe
        [TestMethod()]
        public void GetVerseTest_Safe_First_Normal()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = "b"
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_First_BadBook()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "not a book";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_First_BookOnly()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = -1;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = new Verse
            {
                Index = 2747,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 1,
                VerseNumber = 1,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_First_NoVerse()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = new Verse
            {
                Index = 2832,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 1,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_First_ChapterTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5000;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_First_VerseTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 5000;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_Last_Normal()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = "b"
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_Last_BadBook()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "not a book";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_Last_BookOnly()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = -1;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = new Verse
            {
                Index = 3605,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 27,
                VerseNumber = 34,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_Last_NoVerse()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_Last_ChapterTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5000;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Safe_Last_VerseTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 5000;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Safe;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GetVerseTest_Strict
        [TestMethod()]
        public void GetVerseTest_Strict_First_Normal()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = "b"
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_First_BadBook()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "not a book";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_First_BookOnly()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = -1;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = new Verse
            {
                Index = 2747,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 1,
                VerseNumber = 1,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_First_NoVerse()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = new Verse
            {
                Index = 2832,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 1,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_First_ChapterTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5000;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_First_VerseTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 5000;
            string suffix = null;
            VersePosition position = VersePosition.First;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_Last_Normal()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = "b"
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_Last_BadBook()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "not a book";
            int chapter = 5;
            int verse = 19;
            string suffix = "b";
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_Last_BookOnly()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = -1;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = new Verse
            {
                Index = 3605,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 27,
                VerseNumber = 34,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_Last_NoVerse()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = new Verse
            {
                Index = 2850,
                BookName = "Leviticus",
                BookNumber = 3,
                ChapterNumber = 5,
                VerseNumber = 19,
                Suffix = null
            };
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetVerseTest_Strict_Last_ChapterTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5000;
            int verse = -1;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetVerseTest_Strict_Last_VerseTooLarge()
        {
            //Repository_Accessor target = new Repository_Accessor();
            string book = "lev";
            int chapter = 5;
            int verse = 5000;
            string suffix = null;
            VersePosition position = VersePosition.Last;
            RepositoryMode mode = RepositoryMode.Strict;
            Verse expected = null;
            Verse actual;
            actual = Verse.Create(si, book, chapter, verse, suffix, position, mode);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Verse target = new Verse
            {
                Index = 0,
                BookName = "Genesis",
                BookNumber = 1,
                ChapterNumber = 1,
                VerseNumber = 1,
                Suffix = "a"
            };
            string expected = "Genesis 1:1a";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
