﻿using NUnit.Framework;
using PipelineRunner.Jobs;
using System;

namespace PipelineRunner.Tests
{
    [TestFixture]
    public class Job_Tests
    {
        class SimpleJob : AsyncJob<Int32, String>
        {
            public override string Perform(int param)
            {
                return "My number is : " + param;
            }
        }

        [Test]
        public void SimpleJob_Assert_Output()
        {
            var job = new SimpleJob();

            for (int i = 0; i < 100; i++)
            {
                Assert.That(job.Output.Count, Is.EqualTo(i));

                job.InternalPerform(i);

                Assert.That(job.Output.Count, Is.EqualTo(i+1));
            }

        }
    }
}
