using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace tests
{
    public class ConvertTester
    {
        public void Test()
        {
            Application app = new Application();
            var fname = @"C:\Users\mokona\Desktop\test.doc";
            var oname = @"C:\Users\mokona\Desktop\test2.html";

            var ofname = (object)fname;
            var ooname = (object)oname;
            var oformat = (object)WdSaveFormat.wdFormatHTML;
            var OFALSE = (object)false;
            var OTRUE = (object)true;
            var document = app.Documents.Open(ref ofname);
            // document.Convert();
            document.SaveAs(ref ooname, ref oformat);
            document.Close(OFALSE);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var tester = new Tester();
            tester.Test();
            //var ct = new ConvertTester();
            //ct.Test();
            //Console.ReadLine();
        }
    }
}
