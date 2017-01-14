using MessageBird.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.UnitTests.MessageBirdUnitTests.Resources
{
    [TestClass]
    public class ReflectionUtilityTests
    {

        [TestMethod]
        public void IsNullableTest()
        {
            // Validate 
            Type nullableGenericDateTime = typeof(Nullable<DateTime>);
            Assert.IsTrue(ReflectionUtils.IsNullable(nullableGenericDateTime));

            Type nullableDateTime = typeof(DateTime?);
            Assert.IsTrue(ReflectionUtils.IsNullable(nullableDateTime));

            Type notNullableDateTime = typeof(DateTime);
            Assert.IsFalse(ReflectionUtils.IsNullable(notNullableDateTime));
        }
    }
}
