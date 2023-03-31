# Running and Testing

Open the solution in Visual Studio and use the IIS Express configuration to launch the API. You may need to use the provided PowerShell script to regenerate the SSL certificate if you receive a connection reset error while running the API in HTTPS mode.

If you use Postman to test the API (as I did), you may need to disable SSL verification since IIS Express uses a self-signed certificate. As indicated below, send POST requests with the Body set to raw/JSON.

# Next Steps

The instructions are not entirely clear about some things, so I would probably seek clarification on them to refine the algorithm. For instance, it says "[if] there is more than 1 robot within 10 distance units of the load, return the one with the most battery remaining." My algorithm returns the closest robot, and breaks any ties with the battery level, so it's unclear how "within 10 distance units" may factor in. If there are no robots within 10 distance units, should it return an error? The requirements specifically state "based on which one is closest [to] the load's location" so I presumed not.

I presume that battery level would be significant for the purposes of the robots moving. So there would likely need to be some additional refining to disqualify robots which have insufficient battery to reach their goal -- for example, a robot 1 distance unit away but with 0 battery level should not be chosen over one with a further distance but sufficient battery. However, the challenge does not explicitly account for this so I did not include it, only breaking ties by battery level but otherwise deciding solely by closest distance (as above). But that's the sort of thing I'd run up the chain in a real-world scenario. If that's not the case, it shows the importance of clear acceptance criteria for a project!

On a long-term basis I imagine that this API would need to be expanded to give instructions to the robots. If a robot is moving between points, then it would need to be "reserved" for that task and not returned as the closest robot. Its battery level would also need to be updated after it's arrived.

# SVT Robotics - Take Home Recruiting Assessment

One of SVT's microservices calculates which robot should transport a pallet from point A to point B based on which robot is the closest and has the most battery left if there are multiple in the proximity of the load's location. You'll use a provided API endpoint to create a simplified robot routing API.

This is the endpoint to retrieve a list of robots in our robot fleet: https://60c8ed887dafc90017ffbd56.mockapi.io/robots. Note: if that URL doesn't work, a mirror is available here - https://svtrobotics.free.beeceptor.com/robots.

The provided API returns a list of all 100 robots in our fleet. It gives their current position on an xy-plane along with their battery life. Your job is to write an API with an endpoint which accepts a payload with a load which needs to be moved including its identifier and current x,y coordinates and your endpoint should make an HTTP request to the robots endpoint and return which robot is the best to transport the load based on which one is closest the load's location. If there is more than 1 robot within 10 distance units of the load, return the one with the most battery remaining.

The distance between two points is found with the following formula:

![distance formula](https://user-images.githubusercontent.com/7139741/122107356-f915e300-cde8-11eb-8699-f87b50046350.png)

If the API receives a payload of:

```
{
    loadId: 231, //Arbitrary ID of the load which needs to be moved.
    x: 5, //Current x coordinate of the load which needs to be moved.
    y: 3 //Current y coordinate of the load which needs to be moved.
}
```

It should respond with a payload of _(note: this is just an example, your results may be different depending on the data available from the API at the time.)_:

```
{
    robotId: 58,
    distanceToGoal: 49.9, //Indicates how far the robot is from the load which needs to be moved.
    batteryLevel: 30 //Indicates current battery level of the robot.
}
```

### Requirements

1. API with POST endpoint that accepts and returns data per the above task description
   1. POST endpoint **must** be **`https://localhost:5001/api/robots/closest/`** or **`http://localhost:5000/api/robots/closest/`**
2. API can be run locally and tested using Postman or other similar tools
3. Description of what features, functionality, etc. you would add next and how you would implement them - you shouldn't spend more than a few hours on this project, so we want to know what you'd do next (and how you'd do it) if you had more time
4. Use git and GitHub for version control
5. Have fun! We're interested in seeing how you approach the challenge and how you solve problems with code. The goal is for you to be successful, so if you have any questions or something doesn't seem clear don't hesitate to ask. Asking questions and seeking clarification isn't a negative indicator about your skills - it shows you care and that you want to do well. Asking questions is always encouraged at SVT Robotics, and our hiring process is no different.

Deliverables Checklist

1. API written in Javascript, Typescript, .NET Core, or a similar language
2. API accepts POST and returns data per above requirements
3. Repo README has instructions for running and testing the API
4. Repo README has information about what you'd do next, per above requirements
5. Create a new GitHub repo and share it with teresa@svtrobotics.com
