// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)


using System;
using System.Linq;
using System.Reflection;
using FestivalManager.Core.Controllers;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void ShouldBeReturntCantPerforme()
	    {
            IStage stage = new Stage();
            ISet set1 = new Short("set1");
            set1.AddPerformer(new Performer("ivan",23));
            ISet set2 = new Short("set2");
            set2.AddPerformer(new Performer("dragan",32));
            

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddPerformer(new Performer("inva",32));
            stage.AddPerformer(new Performer("invan",42));
            
            SetController setController = new SetController(stage);

	        string expectedString = "-- Did not perform";
            

	    }

        [Test]
        public void TestConstuctor()
        {
            Stage stage = new Stage();
            SetController setController = new SetController(stage);

            FieldInfo[] fields = typeof(ISet).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }
	}
}
