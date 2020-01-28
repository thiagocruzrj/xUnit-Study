﻿using Xunit;

namespace Features.Tests._03___Order
{
    public class OrderTests
    {
        public static bool Test1Call;
        public static bool Test2Call;
        public static bool Test3Call;
        public static bool Test4Call;

        [Fact(DisplayName = "Test 4")]
        [Trait("Category", "Tests Ordering")]
        public void Test4()
        {
            Test4Call = true;

            Assert.True(Test1Call);
            Assert.True(Test2Call);
            Assert.False(Test3Call);
        }

        [Fact(DisplayName = "Test 1")]
        [Trait("Category", "Tests Ordering")]
        public void Test1()
        {
            Test1Call = true;

            Assert.True(Test3Call);
            Assert.False(Test4Call);
            Assert.False(Test2Call);
        }

        [Fact(DisplayName = "Test 3")]
        [Trait("Category", "Tests Ordering")]
        public void Test3()
        {
            Test3Call = true;

            Assert.False(Test1Call);
            Assert.False(Test2Call);
            Assert.False(Test4Call);
        }

        [Fact(DisplayName = "Test 2")]
        [Trait("Category", "Tests Ordering")]
        public void Test2()
        {
            Test2Call = true;

            Assert.True(Test3Call);
            Assert.True(Test4Call);
            Assert.True(Test1Call);
        }
    }
}
