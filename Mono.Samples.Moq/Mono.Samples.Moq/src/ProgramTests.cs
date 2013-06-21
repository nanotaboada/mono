#region License
// Copyright (c) 2012 Nano Taboada, http://openid.nanotaboada.com.ar 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE. 
#endregion

using NUnit.Framework;
using Moq;

namespace Mono.Samples.Moq
{
    /// <remarks>
    /// Let's assume that "IProgram" is an external (and sometimes unavailable)
    /// API that we want to mock in order to properly test the remaining logic.
    /// 
    /// Notice we're not interested in testing its eventual implementation, but
    /// just the contract. We're even actually going to modify the return value
    /// of its "GetPangram" method to better illustrate the concept of mocking. 
    /// </remarks>
    
    [TestFixture]
    public class ProgramTests
    {
        public Mock<IProgram> mock;

        [SetUp]
        public void Setup()
        {
            this.mock = new Mock<IProgram>();
        }

        [Test]
        [TestCase("Lorem ipsum dolor sit amet.")]
        public void GetPangram_ExpectedAndActualValues_AreEqual(string expected)
        {
            // Arrange
            this.mock.Setup(x => x.GetPangram()).Returns("Lorem ipsum dolor sit amet.");
            
            // Act
            string actual = this.mock.Object.GetPangram();
            
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TearDown]
        public void TearDown()
        {
            this.mock = null;
        }
    }
}

