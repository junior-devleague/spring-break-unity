#Day 4

###Topics and Goals
By the end of today's lesson, students should be able to...
- Create a health script for the player character that allows the player to take damage.
- Create a way for the enemy to attack the player.
- Use Unity's UI system to display information about the player's health.
- Use Unity's UI system to display score, and increase that score through in-game actions.

###Creating a healthbar
Create a UI Canvas in your scene. This is an object that will sit on top of your screen and display things in the same place consistently. A Canvas is perfect for holding things like health bars and score displays that need to be on screen at all times.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day4/Screenshots/canvas.png)

Notice that the Canvas and anything on it will have a Rect Transform instead of a Transform. A Rect Transform treats the object as a rectangle, so it understands its position based on its four corners and not on its origin. This lets us have elements stretch to fill the space they're given, and resize themselves smoothly with the screen when the window changes size.

As a child object of this canvas, create a Slider element. Normally, this is used for things like volume controls, where the player can interact with it and move it left and right, but when you disable the handle it looks just like a health bar. Delete the Handle on this Slider and make sure the "Interactable" option is turned off.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day4/Screenshots/slider.png)

Let's configure it to make a little more sense as a healthbar. Use the Rect Transform component on the Slider to set its position to the top left corner (hold Shift and Alt when clicking). Use the Pos X and Pos Y fields to give it some space.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day4/Screenshots/pivot.png)

Next, we want the player to have 10 health points at most, so set the Maximum to 10. Check the Whole Numbers box so we can work with an int instead of a float. Then, you can change the size and colors to your liking.

###Creating a health script
Now, let's make the healthbar actually work. Create a script "PlayerHealth" and attach it to your player. You will need:
- An `int` for current health
- A public method that allows the player to take an amount of damage
- A method that will handle what happens when the player dies. Make sure the player can't move or take any more damage after they have died.

###Creating the enemy's attack
Most enemies can hurt you simply by touching you. Similar to how you made the Goal, you can have the player take damage when they enter a trigger area around the enemy. 
- Add a second SphereCollider to the enemy, and mark it as a trigger. Make its radius bigger than its other collider, so that the player can enter it before colliding away.
- Then, use OnTriggerEnter to call TakeDamage on any Players that enter the trigger.

Put the center of the enemy's trigger slightly lower than its actual center--the goal is to leave a spot on top that the attack radius doesn't damage. The player will attack enemies by jumping on their heads.

![](https://github.com/junior-devleague/spring-break-unity/blob/master/Day4/Screenshots/hitbox.png)

###Creating the enemy's health
The enemy's health will work similar to the player's. The only difference is, we want the enemy to be destroyed when it dies.

###Attacking enemies
Much like when we checked if the player was grounded before jumping, we want the Attack script to check if there is an enemy below the player's feet as the player jumps around. If there is, it will call the enemy's TakeDamage() function when the player lands on it, and send the player bouncing higher upward.

###Displaying the score
We'll add another text element to the canvas we created to display a score. Set the text color to something you can easily see, and add a Shadow component. Then, create and add a script called ScoreManager.

With ScoreManager, we'll be using static variables. Static variables belong to the whole class and not just to an instance. With games, we usually want each player and enemy to have their own health values and not one shared value, so we've been using non-static variables until now. Think of it like a classroom: the room is the same for each student in the class, so it is a static variable. But each student writes their own test answers, so those are non-static variables. 

Write a public, static method that increases the score by an amount passed in. Call that method from EnemyHealth when the enemy dies.

For a nicer effect, we can have the score count up from its previous value to its new value. But how do we make it change slowly enough for us to see? We use what's called a Coroutine, which splits up a function's processes over a period of time. You can then _enumerate_ over (go through one-by-one) those parts, so we define a coroutine with the return type `IEnumerable`.

Write a coroutine that takes an amount to increase the score by and completes increasing it over the span of a second. Then change your AddToScore method to start this coroutine using StartCoroutine.
