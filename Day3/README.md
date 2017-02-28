#Day 3

###Topics and Goals
By the end of this lesson, students should be able to...
- Move their character around the scene using keyboard controls.
- Make their character jump using a keyboard control.
- Set up a camera that will keep the player character in view at all times.
- Create an enemy that chases after the player.

###Movement
The first script we'll create will allow the player character to move around the scene. We will walk through this script and write it together, explaining what every line of code does. This script will take our input from the arrow keys and move the player around.

Before we write this script, we need to make sure we have a component called a Rigidbody attached to the player. This lets us move the player around in a way that interacts realistically with the environment. We will access this component from our script and tell it where to move.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day3/Screenshots/rigidbody.png)

Make sure to open up the Constraints on the rigidbody and select Freeze Rotation on all three axes. This makes sure that it will only turn in ways we tell it to turn, and not on its own.

We'll also need to look at our input controls (Edit -> Project Settings -> Input Settings). Open up the Horizontal controls and look at them. You'll see there's a positive button (right arrow key), an alternate positive button (D key), a negative button (left arrow key) and an alternative left button (A key). An axis gives us the player's input as a number between -1 and +1. When the key is let go, it slowly returns to 0. Our script will take this information and allow us to move the character smoothly.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day3/Screenshots/inputmanager.png)

###Jumping
Once the player is able to move, we can allow it to jump. We'll again use the Input module and this time check for the Jump button being pressed. 

We'll also write a method to make sure the player can only jump from the ground, and not when they're already in the air. For this, we'll use a tool called a Raycast. A Raycast shoots an invisible beam in a direction we tell it to travel, and reports back if it hit anything. By using a Raycast that's fired straight down, we can see if it hits anything right beneath our player. If it doesn't, they're in the air and the player has to wait before jumping again.

###Camera Setup
Now your character can move around, but your camera is stuck in one place. To tell the camera to follow the player, we'll need another script. This script has a lot less going on - just two variables and two methods.

The camera needs two things: a target to look at, and a distance it should be away from the player (an _offset_). When the scene starts, we will tell it to calculate its own offset based on where it is relative to the player in our scene. As it updates, it needs to keep track of the player's position, and calculate its own position based on that and its offset.

###Enemy Movement
Now that we know how to make a camera follow the player, let's make an enemy to chase it too. Create another sphere with a Rigidbody attached, and create a script for EnemyMovement.

The enemy's movement works similarly to the player's, but is much simpler since we don't need to handle input. The enemy also doesn't jump. All it needs to do is keep checking where the player is, and chase after it. We'll add a way for it to attack tomorrow.

###Goal
Let's add a way that the player can win, too. When the player reaches the end of the maze, we can tell them that the level is complete. We can cause things to happen when the player enters a certain point on the map by using a trigger. A trigger is just a collider that isn't solid--other objects can pass through it. When they do, a message is sent to any scripts attached to the trigger, which causes a method called OnTriggerEnter to run. Unless we write this method's behavior in our script, it will just do nothing.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day3/Screenshots/goal.png)

We will create a script that has an OnTriggerEnter method in it. This method will take in information about the other collider that entered its trigger. We only care what happens when a player reaches the goal--the enemies don't do anything special--so we only want this method to do something if the other object is a Player. Lastly, we'll use the Debug.Log method to print a message to the console that tells us that the player has reached the goal.
