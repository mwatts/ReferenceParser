using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Konves.Scripture.Version
{
    /*
    [XmlType("Resource")]
    public class ScriptureInfo
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("tname")]
        public string TranslationName { get; set; }
        [XmlAttribute("tabbr")]
        public string TranslationAbbreviation { get; set; }

        [XmlArray("Limits")]
        [XmlArrayItem("L")]
        public ChapterLimits[] ChapterLimits { get; set; }

        [XmlArray("Books")]
        [XmlArrayItem("B")]
        public ScriptureBook[] Books { get; set; }

        [XmlElement("Scheme")]
        public string[] AbbreviationSchemes { get; set; }

        [XmlElement("Omit")]
        public int[] VerseOmissions { get; set; }
    }

    [System.Diagnostics.DebuggerDisplay("{Number}: {Name}")]
    public class ScriptureBook
    {
        [XmlAttribute("n")]
        public string Name { get; set; }
        [XmlAttribute("i")]
        public int Number { get; set; }

        [XmlElement("A")]
        public string[] Abbreviations { get; set; }

        [XmlArray("Schemes")]
        [XmlArrayItem("Scheme")]
        public AbbreviationScheme[] AbbreviationSchemes { get; set; }
    }

    public class AbbreviationScheme
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("abbr")]
        public string Abbreviation { get; set; }
    }

    public class ChapterLimits
    {
        [XmlAttribute("b")]
        public int BookNumber { get; set; }
        [XmlAttribute("c")]
        public int ChapterNumber { get; set; }
        [XmlAttribute("s")]
        public int StartVerseIndex { get; set; }
        [XmlAttribute("e")]
        public int EndVerseIndex { get; set; }
        [XmlAttribute("v")]
        public int EndVerseNumber { get; set; }
    }
     */
}
