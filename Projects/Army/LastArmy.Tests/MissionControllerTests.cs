using NUnit.Framework;
using System;


public class MissionControllerTests
{
    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);
        string result = "";
        for (int counter = 0; counter < 4; counter++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil "));
    }

    [Test]
    public void MissionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(0);
        string result = missionController.PerformMission(mission);


        Assert.IsTrue(result.StartsWith("Mission completed - Suppression of civil "));
    }
}