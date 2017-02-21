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

Create a Sphere object and place it so it's on top of the floor. This will be our player for now. Make sure to tag it "Player".

Begin building your maze using Cube objects. You will make a lot of cubes, but keeping them under the Environment parent object will help keep your scene organized.

Tomorrow, we'll learn how to move the player around to explore the level.