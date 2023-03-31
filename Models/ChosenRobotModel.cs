namespace SVTRoboticsAPI.Models
{
    public class ChosenRobot
    {
        public ChosenRobot()
        {
            DistanceToGoal = -1;
            BatteryLevel = -1;
        }
        public ChosenRobot(Robot robot, float distance)
        {
            RobotId = robot.RobotId;
            DistanceToGoal = distance;
            BatteryLevel = robot.BatteryLevel;
        }

        public string? RobotId { get; set; }
        public float DistanceToGoal { get; set; }
        public int BatteryLevel { get; set; }
    }
}
