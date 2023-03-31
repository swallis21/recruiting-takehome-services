using System;

namespace SVTRoboticsAPI.Models
{
    public class Robot
    {
        public Robot() { }
        public Robot(string id, int batteryLevel, int x, int y)
        {
            RobotID = id;
            BatteryLevel = batteryLevel;
            X = x;
            Y = y;
        }

        public string? RobotID { get; set; }
        public int? BatteryLevel { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
    }
}