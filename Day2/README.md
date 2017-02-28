#Day 2

###Topics and goals
By the end of the day, students should be able to...
- Understand the editor and where common elements are located
- Create a basic level environment
- Export their work to a .unitypackage file, to take it home if needed

###The editor in depth

###Exercise
Create an empty GameObject to hold your environment. Place it in the center of your scene.

Create a Quad as a child object of the Environment. This will be your floor. Rotate it 90 degrees around the X-axis, so that its surface points upward. Scale it to 32 by 32 by 1.

Create four more quads to be your level's walls. Rotate them appropriately so their surfaces face in toward your level. Quads only render on one side, so they're good for walls since they won't block the view into the room.

Now that you have a floor and walls, select the parent GameObject and drag it to your Project tab. You'll see it save a copy in there as a cube-looking thing with a white tag. This is a _prefab_, which is a ready-made object you can reuse throughout your game. When you build another level, you can just drag that prefab object into the Hierarchy tab and it will be ready to use.

Create a Sphere object and place it so it's on top of the floor. This will be our player for now. Make sure to tag it "Player".

Begin building your maze using Cube objects. You will make a lot of cubes, but keeping them under the Environment parent object will help keep your scene organized.

Before the end of today's class, save your scene, then go to the Assets menu and select Export Package. Ignore what it says about "Nothing to Import!" and wait a few seconds. Then, you should see a list of all folders and assets in your Project tab. Make sure they are all checked and click Export. It will then save a `.unitypackage` file which you can take home on a USB drive or email to yourself, and then you can use this file with your own copy of Unity at home to explore on your own.

Tomorrow, we'll learn how to move the player around to explore the level.
