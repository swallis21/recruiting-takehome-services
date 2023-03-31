using SVTRoboticsAPI.Models;
using System.Linq;

namespace SVTRoboticsAPI.Utilities
{
    public class RobotUtilities
    {
        public float GetDistance(Robot robot, int destinationX, int destinationY)
        {
            return (float)Math.Sqrt(Math.Pow(robot.X - destinationX, 2) + Math.Pow(robot.Y - destinationY, 2));
        }

        public ChosenRobot ChooseRobot(List<Robot> robots, string loadId, int destinationX, int destinationY)
        {
            //should never be null since robots.Count > 0
            Robot closestRobot = robots.OrderBy(robot => GetDistance(robot, destinationX, destinationY)).ThenByDescending(robot => robot.BatteryLevel).First();
            return new ChosenRobot(closestRobot, GetDistance(closestRobot, destinationX, destinationY));
        }
    }
}
