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

#region References
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;
#endregion

namespace Mono.Samples.log4net
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main()
        {
            try
            {
                var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var cfg = Path.Combine(dir, "cfg");
                var xml = new XmlDocument();
                    xml.Load(Path.Combine(cfg, "log4net.config"));
                var msg = "The quick brown fox jumps over the lazy dog.";
                XmlConfigurator.Configure((XmlElement)xml.DocumentElement);

                if (log.IsDebugEnabled) log.Debug(msg);
                if (log.IsInfoEnabled) log.Info(msg);
                if (log.IsWarnEnabled) log.Warn(msg);
                if (log.IsErrorEnabled) log.Error(msg);
                if (log.IsFatalEnabled) log.Fatal(msg);
            }
            catch (Exception err)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(String.Format("Exception: {0}", err.Message));
            }
            finally
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}