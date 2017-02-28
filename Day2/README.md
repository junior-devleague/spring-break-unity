#Day 2

###Topics and goals
By the end of the day, students should be able to...
- Understand the editor and where common elements are located
- Create a basic level environment
- Export their work to a .unitypackage file, to take it home if needed

##The editor in depth

###Project settings

Under the Edit menu, you will see an option near the bottom called "Project Settings". These allow you to control settings for your entire project that will apply to all levels in your game.

####Input

This lets you change how Unity interprets the controls to your game. By default, it has support for WASD and arrow keys for the Horizontal and Vertical movement controls, and a few buttons defined for Jump, Fire 1, Fire 2, Fire 3, as well as some presets for handling mouse movement. If you wanted to add support for a particular type of controller or joystick, you would go here.

####Tags and Layers

Tags and layers let you organize your game. Tags are a quick way of telling your scripts what GameObjects they should be paying attention to. For example, if you had a power-up that could only be picked up by a player, the fastest way to do that would be to check if whatever is touching that power-up has the Player tag.

Layers can do a bit more - they can let you hide a group of objects from the game's camera. Or they can tell the physics engine how objects will collide. If Enemies don't even need to care about what happens when they touch Items, you can put them on different layers and then use the Physics settings to tell these layers never to collide.

####Audio

The Audio settings provide advanced audio mixing configuration. The default settings are fine for this and most projects, but if you were making a game with very complex audio, you might need to change them.

####Time

The Time settings can be adjusted if you have a very large game that is making the processor chug really hard to keep up with what's happening in the game. Unless you have thousands of objects controlled by the physics engine on the screen at once, we won't need to use it for this project.

####Player

This is where the settings for the final build of your game can be changed. If you want it to run at a certain resolution, give it a program icon, or let the user change the control scheme before they start playing, you can change these things here.

####Physics and Physics2D

Here, you can change how gravity affects objects in your scene, how close they need to be for a collision to count, and which layers can collide with which. The default settings are enough for most projects and use Earth gravity. If you have a lot of layers, it's a good idea to use these settings to change which can collide with which, to take some of the unnecessary work off of the physics engine.

####Quality

This lets you change the quality of the graphics and lighting. If you build a visually complex game with a lot of image effects, some older computers might not be able to run it without the framerate slowing down. The Quality tab lets you control what graphics features can be dropped at which quality levels to keep the game looking good and running fast.

####Graphics

The graphics tab lets you control Shaders, which are scripts that get attached to a material and tell the graphics card how to render the object. Shaders can allow you to do cool effects like making objects glow, or rendering a character's x-ray vision. Unity comes with a lot of shaders built-in that can do what most projects need, but as you start developing more complex games, you will need to learn how to write your own.

####Network, Editor, Script Execution Order

These can be used for advanced settings with the editor's behavior and if you need to fine-tune the timing of a certain script to run before or after others. We won't need to use these in this project.

###The Window Menu

The Window menu lets you open up new tabs that do different things in your project and scene. This is where you'll find the Console, the Animator, the Animation window, the Asset Store, lighting and audio settings, and anything else you might need that isn't already in your window layout.

####Services

If you have your own Unity account, you can use Unity services like ads and analytics in your game.

####Scene, Game, Inspector, Hierarchy, Project

You should have these open in the Editor already, but if you accidentally close a tab, this is where you can reopen them.

####Animation

This tab lets you create AnimationClips that can change the shape, color, size or position of objects over a period of time. We'll be working with this on Day 5.

####Profiler

The Profiler gives you in-depth information about what the computer's processor is doing while running your game. When you press Play on a scene while the Profiler tab is open, it will start recording the game's performance. You can see if there's any spikes in processing time, and then look closer at what might be causing it.

If you try the Profiler now, you'll probably see most of the CPU time is being used by WaitForTargetFPS. This is normal, and means that your game is running much faster than 60 frames per second and the game is sitting around doing nothing until the next 1/60th of a second passes!

####Audio Mixer

This is where you can control audio effects and how sounds and music mix together.

####Asset Store

This tab lets you go to Unity's asset store and find content that other people have made available to others. These can be scripts, audio packs, character sprites, or 3D models, or even tools to improve the Editor itself. Most things on the Asset Store cost money, but if you search by "price:0" you can find a lot of free content to add to your game.

####Version Control

This lets you set up Unity to integrate with a version control service like Git. Depending on your version of Unity this might be greyed out. If you've used Git before, you can always do it yourself through a service like GitHub.

####Animator and Animator Parameter

This is where you can configure an Animator component that's attached to a GameObject, and control which animations play when. The list of Animator Parameters stays at the left of this tab, and lets you define the conditions that cause an animation to play or stop. For example, a parameter based on the player's speed might control whether the walking animation plays or stops. We'll be using this more on Day 5.

####Lighting

Here, you can adjust how lighting is handled by your game. The defaults are fine for this project, but if you wanted the game to have a darker or brighter feel, you could adjust these settings. This tab also allows you to _bake_, or pre-calculate, the lighting data instead of doing it in real-time, which is a way to make the graphics render a little faster.

####Navigation

This tab lets you use Unity's built-in pathfinding AI to determine how AI characters will move around in your level. We will be writing our own way to control enemies' movements in this project, so we won't be using the Navigation tools in this course.

####Console

It's a good idea to always have this tab open. The Console gives you information about any errors in your script, and also how to fix them. You can also use it to check what a variable looks like in your script by having that script call `Debug.Log`.

##Common components

Without components, GameObjects don't do anything. Let's get familiar with the most common ones.

###Collider

A Collider is what gives an object volume in space. With a Collider, other objects can't pass through this object, but will be pushed away from it. This is what makes walls and floors in your game solid. Colliders come in a few different 3D shapes: BoxCollider makes a collider with six flat sides, SphereCollider makes a round collider, CapsuleCollider makes a cylinder with two rounded caps at either end, and MeshCollider generates a collider based on the surface geometry of an object.

Most objects' physical space can be estimated by a combination of BoxColliders, CapsuleColliders and SphereColliders, and it's almost always better to do so with these than with a MeshCollider. The MeshCollider makes a separate collision plane for each face an object has--which isn't a problem for a flat wall or floor, but for a complex shape like a character's face, it's overkill which ends up slowing the physics engine down. A character that stands on two legs can usually make do with a single CapsuleCollider sized to fit its head, body and legs, while a weapon might be made of a few BoxColliders put together.

The Colliders also provide a checkbox to turn a solid Collider into a Trigger. A Trigger does not behave like a solid object, and other objects can pass through it, but any objects attached to this Trigger Collider will now run a function called OnTriggerEnter when this happens. Almost every game uses these to determine things like enemy hitboxes, crossing the finish line, opening a door, picking up an item, or having an enemy chase a player that came too close.

Lastly, there are a few extra 3D colliders that provide more complex functionality for simulating car wheels and uneven ground. We don't need them for this project, but you might use them in other kinds of games.

###MeshRenderer

The MeshRenderer is what determines if a 3D object is visible or not, and how to render it to the screen. It takes a Material and applies it over the surface of the object. You can disable or remove the MeshRenderer from an object to make it invisible. For 2D games, the SpriteRenderer does the same thing.

###Rigidbody

A Rigidbody is what gives an object mass and allows it to be affected by physics. Objects with Rigidbodies will be affected by gravity and start falling until they find a surface to rest on. We can also use the Rigidbody in our scripts to control how fast an object is moving, rotate it, push it around with engine force or with explosions, make it bounce and jump, or even make it teleport to another position. Any object that needs to move around will need a Rigidbody.

###Camera

A Camera component is what allows the Main Camera in our scene to see things and display them on the screen. We can control its position and angle to tell it where to look, and use its Depth and Field of View properties to zoom and distort what it sees. For the MainCamera, we can see what it sees using the Game View. You could add extra cameras to the scene in order to do things like split screens.

###Animator

With an Animator component attached to an object, its components and child objects can be animated using an AnimationClip.

###New Script

This is the most powerful component of all: scripts that you will create and write to control how items, characters and processes work in your game. Any script you create can be attached as a component to a GameObject. Even better, you can control any other component on the object using a function called `GetComponent<ComponentName>()` in your script.

Any public variables you set in a script will show up as editable fields in the Inspector when they are attached to a GameObject as a component, and this lets you see how different values for those variables can affect your gameplay right as you're playing it. You can drag and drop a script you've created onto a GameObject in the hierarchy, or click Add Component with the GameObject selected and search for it by title.

##Exercise
Create an empty GameObject to hold your environment. Place it in the center of your scene.

Create a Quad as a child object of the Environment. This will be your floor. Rotate it 90 degrees around the X-axis, so that its surface points upward. Scale it to 32 by 32 by 1.

Create four more quads to be your level's walls. Rotate them appropriately so their surfaces face in toward your level. Quads only render on one side, so they're good for walls since they won't block the view into the room.

Now that you have a floor and walls, select the parent GameObject and drag it to your Project tab. You'll see it save a copy in there as a cube-looking thing with a white tag. This is a _prefab_, which is a ready-made object you can reuse throughout your game. When you build another level, you can just drag that prefab object into the Hierarchy tab and it will be ready to use.

Create a Sphere object and place it so it's on top of the floor. This will be our player for now. Make sure to tag it "Player".

Begin building your maze using Cube objects. You will make a lot of cubes, but keeping them under the Environment parent object will help keep your scene organized.

Before the end of today's class, save your scene, then go to the Assets menu and select Export Package. Ignore what it says about "Nothing to Import!" and wait a few seconds. Then, you should see a list of all folders and assets in your Project tab. Make sure they are all checked and click Export. It will then save a `.unitypackage` file which you can take home on a USB drive or email to yourself, and then you can use this file with your own copy of Unity at home to explore on your own.

Tomorrow, we'll learn how to move the player around to explore the level.
