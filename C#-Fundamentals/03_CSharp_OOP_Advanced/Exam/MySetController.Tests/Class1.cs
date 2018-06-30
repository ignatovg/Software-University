using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MySetController.Tests
{
    public class Class1
    {
        [Test]
        public void ShoudReturnFalse()
        {
            
            IStage stage = new Stage();
            SetController setController = new SetController(stage);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"1. {stage.Sets.First().Name}:");
            sb.AppendLine("-- Did not perform");

            Assert.That(setController.PerformSets(), Is.EqualTo(sb));
        }
    }

    
}
