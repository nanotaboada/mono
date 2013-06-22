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
using System.IO;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
#endregion

namespace Mono.Samples.NHibernate
{    
    public static class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var sdf = Path.Combine(dir, "res", "catalog.sqlite");

            var cfg = MonoDataSqliteConfiguration.Standard.UsingFile(sdf)
                .ShowSql()
                .FormatSql();

            return Fluently.Configure()
                .Database(cfg)
                .Mappings(map => map.FluentMappings
                    .AddFromAssemblyOf<Book>()
                    .Conventions.Add(Table.Is(pl => string.Format("{0}s", pl.EntityType.Name))))
                .BuildSessionFactory();
        }
    }
}

