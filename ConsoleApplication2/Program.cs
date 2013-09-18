using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Konves.Scripture;
using Konves.Scripture.Data;
using Konves.Scripture.Version;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            ScriptureInfo.TryRegister("esv", @"e:\Users\Stephen\Desktop\SRP\trunk\Konves.Scripture\Data\esv.xml");

            var esv = ScriptureInfo.GetInstance("esv");

            Reference r;

            Reference.TryParse("bob 1:1-5,2:1-6; jas 5", esv, out r);

            var q =
                from v in r
                where v.BookNumber != 1
                select v;

            var x = r[6];

            int i = r.Length;

            //ScriptureInfo.TryRegister("esv", @"e:\Users\Stephen\Desktop\SRP\trunk\Konves.Scripture\Data\esv.xml");

            ////var x = ScriptureInfo.GetInstance("esv");


            ////var ww = ScriptureInfo.Deserialize(new System.IO.FileStream(@"e:\Users\Stephen\Desktop\SRP\trunk\Konves.Scripture\Data\esv.xml", System.IO.FileMode.Open));

            //Reference r = Reference.Parse("ex 4:1-2, jas 1","esv");

            //var s = string.Format("{0:b c.vs}", r.First());

            //// var s = r.First().ToString("b. c:vs", null);

            ////var f = r.FirstVerse;

            //var asdf = r.GetSubReferences();

            //int len = r.Length;

            //foreach (Verse verse in r)
            //{

            //    if (verse != null)
            //        Console.WriteLine(verse.ToString());
            //    else
            //        Console.WriteLine("ASDF");
            //}

            

            ////var x = vc[31];

        }
    }
}
