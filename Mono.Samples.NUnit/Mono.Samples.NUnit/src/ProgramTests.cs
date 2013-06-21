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

namespace Mono.Samples.NUnit
{
    /// <remarks>
    /// Basic rules for placing and naming tests
    /// 
    /// - For each class, create at least one class with the name [ClassName]Tests.
    /// - For each method, create at least one test method with the following name: 
    ///   [MethodName]_[StateUnderTest]_[ExpectedBehavior].
    ///
    /// Source: Osherove, Roy. The Art of Unit Testing. Manning, 2009. 28. Print.
    /// </remarks>

    [TestFixture]
    public class ProgramTests
    {
        public Program program { get; private set; }
        
        [SetUp]
        public void Setup()
        {
            this.program = new Program();
        }
        
        [Test]
        public void GetPangram_ExpectedValue_IsNotNullOrEmpty()
        {
            // Arrange
            string expected;
            
            // Act
            expected = program.GetPangram();
            
            // Assert
            Assert.IsNotNullOrEmpty(expected);
        }
        
        [Test]
        public void GetPangram_ExpectedAndActualValues_AreEqual()
        {
            // Arrange
            string expected = "The quick brown fox jumps over the lazy dog.";
            string actual;
            
            // Act
            actual = program.GetPangram();
            
            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TearDown]
        public void TearDown()
        {
            this.program = null;
        }
    }
}