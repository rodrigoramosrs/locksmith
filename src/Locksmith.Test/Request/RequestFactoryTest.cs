using Locksmith.Core.Factory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Locksmith.Test.Request
{
    public class RequestFactoryTest
    {
        [Fact]
        public async void Call_Request_Factory_With_Null_Parameter_Result_ArgumentException()
        {
            Exception resultExeception = null;
            try
            {
                await RequestFactory.ExecuteRequest(null);
            }
            catch (ArgumentException exception)
            {
                resultExeception = exception;
            }

            Assert.NotNull(resultExeception);
        }
    }
}
