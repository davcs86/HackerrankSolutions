using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerrankSolutions.Tests
{
    [TestFixture]
    public abstract class BaseTest<T>
    {
        private Stopwatch _stopWatch;
        protected T Solution;

        [SetUp]
        public void Init()
        {
            _stopWatch = Stopwatch.StartNew();
            Solution = (T)Activator.CreateInstance(typeof(T));
        }

        [TearDown]
        public void Cleanup()
        {
            _stopWatch.Stop();
            Console.WriteLine("Execution time for {0} - {1} ms",
                TestContext.CurrentContext.Test.Name,
                _stopWatch.ElapsedMilliseconds);
            GC.Collect();
        }
    }
}
