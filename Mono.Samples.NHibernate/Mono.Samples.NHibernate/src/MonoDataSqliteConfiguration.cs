#region License
// Copyright (c) 2013 Nano Taboada, http://openid.nanotaboada.com.ar 
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
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;
#endregion

namespace Mono.Samples.NHibernate
{
    public class MonoDataSqliteConfiguration : PersistenceConfiguration<MonoDataSqliteConfiguration>
    {
        public static MonoDataSqliteConfiguration Standard
        {
            get { return new MonoDataSqliteConfiguration(); }
        }
    
        public MonoDataSqliteConfiguration()
        {
            Driver<MonoDataSqliteDriver>();
            Dialect<SQLiteDialect>();
            Raw("query.substitutions", "true=1;false=0");
        }
    
        public MonoDataSqliteConfiguration InMemory()
        {
            Raw("connection.release_mode", "on_close");
            return ConnectionString(cs => cs.Is("Data Source=:memory:;Version=3;New=True;"));
        }
    
        public MonoDataSqliteConfiguration UsingFile(string fileName)
        {
            return ConnectionString(cs => cs.Is(string.Format("Data Source={0};Version=3;New=True;", fileName)));
        }
    
        public MonoDataSqliteConfiguration UsingFileWithPassword(string fileName, string password)
        {
            return ConnectionString(cs => cs.Is(string.Format("Data Source={0};Version=3;New=True;Password={1};", fileName, password)));
        }
    }
}

