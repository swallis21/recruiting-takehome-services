namespace SVTRoboticsAPI.Models
{
    public class ChosenRobot
    {
        public ChosenRobot() { }
        public ChosenRobot(Robot robot, int distance, int level)
        {
            RobotId = robot.RobotId;
            DistanceToGoal = distance;
            BatteryLevel = level;
        }

        public string? RobotId { get; set; }
        public float? DistanceToGoal { get; set; }
        public int? BatteryLevel { get; set; }
    }
}
