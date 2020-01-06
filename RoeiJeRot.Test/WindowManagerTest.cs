using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using RoeiJeRot.View.Wpf;

namespace RoeiJeRot.Test
{
    [TestFixture]
    class WindowManagerTest
    {
        private IHost host;

        [SetUp]
        public void Setup()
        {
            host = new HostBuilder().Build();
        }

        public void Test1()
        {
            
        }
    }
}
