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

using System;
using Mono.Unix;
using Mono.Unix.Native;

namespace Mono.Samples.ServiceStack
{
	public class Program
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name='args'>
		/// The command-line arguments.
		/// The first argument is the URL where the host will be listening to (e.g. http://127.0.0.1:8080).
		/// The second argument determines whether to run the program as a daemon or a console application.
		/// </param>
		public static void Main(string[] args)
		{
			var url = "http://127.0.0.1:8080/";
			var isDaemon = false;
			
			if (args.Length == 2) // Expecting exactly two arguments to override defaults.
			{
				if (string.IsNullOrWhiteSpace(args[0])) url = args[0];
				if(args[1].ToString().ToLower() == "daemon") isDaemon  = true;
			}
			
			var host = new Host();
			host.Init();
			host.Start(url);
	
			if (isDaemon)
			{
				UnixSignal [] signals = new UnixSignal[]
				{ 
					new UnixSignal(Signum.SIGINT), 
					new UnixSignal(Signum.SIGTERM), 
				};
				
				for (bool exit = false; !exit;)
				{
					var id = UnixSignal.WaitAny(signals);
				
					if (id >= 0 && id < signals.Length)
					{
						if (signals[id].IsSet)
						{
							exit = true;
						}
					}	
				}
			}
			else
			{
				Console.WriteLine(string.Format("[RUNNING] ServiceStack Self-Hosted Service at {0}", url));
				Console.ReadKey(true);
				host.Stop();
				Console.WriteLine(string.Format("[STOPPED] ServiceStack Self-Hosted Service at {0}", url));
			}
		}
	}
}
