using NUnit.Framework;
using DivisionGroups;

namespace NUnitTestProject1
{
    public class Tests
    {
    

        [Test]
        public void Test1()

        {
            DivisionGroups.Program.Divition div = new Program.Divition();

            double result = div.getStudentsPersistance(4, 10);
            Assert.IsTrue(result < 0.050);
        }

    }
}