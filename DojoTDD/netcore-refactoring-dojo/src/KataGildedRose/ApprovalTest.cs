using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace KataGildedRose
{
   // [UseReporter(typeof(VisualStudioReporter))]
     [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void TrintaDias()
        {

            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            Approvals.Verify(output);

        }
    }
}