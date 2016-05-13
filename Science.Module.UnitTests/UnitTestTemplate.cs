using Microsoft.VisualStudio.TestTools.UnitTesting;
using Science.Module.Core.BaseClasses;
using Science.Module.Core.BaseInterfaces;

namespace Science.Module.UnitTests
{
    //[TestClass]
    public class UnitTestTemplate
    {
        /// <summary>
        /// Test that: expected result
        /// </summary>
        [TestMethod]
        public void TestClass_TestMethod_Option1_Option2()
        {
            //Assert 
            //Initialize key elemenets, provide expected results
            IModuleDataWorker<int, ModuleDataModel> example = null;
            var expectedResult = 15;

            //Act 
            //call functions, require results
            var result = example.Calculate(new ModuleDataModel());
            
            //Arrange 
            //Check test results
            Assert.AreEqual(expectedResult, result); //check that result equals 15
        }
    }
}
