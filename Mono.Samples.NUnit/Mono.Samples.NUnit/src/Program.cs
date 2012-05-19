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

namespace Mono.Samples.NUnit
{
    public class Program
    {
        private string pangram = "The quick brown fox jumps over the lazy dog.";

        /// <summary>
        /// A trivial method that returns a known pangram.
        /// A pangram (Greek: pan gramma, "every letter"), or holoalphabetic 
        /// sentence, is a sentence using every letter of the alphabet at least
        /// once. Pangrams have been used to display typefaces, test equipment,
        /// and develop skills in handwriting, calligraphy, and keyboarding.
        /// </summary>
        /// <returns>A System.String containing the pangram.</returns>
        public string GetPangram()
        {
            return pangram;
        }
    }
}