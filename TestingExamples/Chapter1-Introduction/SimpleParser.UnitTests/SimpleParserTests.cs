using System.Reflection;

namespace TestingExamples;

public class SimpleParserTests
{
    public static void TestReturnsZeroWhenEmptyString()
    {
        //use .NET's reflection API to get the current 
        // method's name
        // it's possible to hard code this, 
        //but it’s a useful technique to know
        string testName = MethodBase.GetCurrentMethod().Name;
        try
        {
            SimpleParser.SimpleParser p = new SimpleParser.SimpleParser();
            int result = p.ParseAndSum(string.Empty);
            if (result != 0)
            {
                //Calling the helper method
                TestUtil.ShowProblem(testName,
                    "Parse and sum should have returned 0 on an empty string");
            }
        }
        catch (Exception e)
        {
            TestUtil.ShowProblem(testName, e.ToString());
        }
    }
}