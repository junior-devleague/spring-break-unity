# 5-Day Unity Workshop Flow (Maze Game)

## Guide to the Repo
The repo has five folders corresponding to each of the five days.  This should not be used as a roadmap to deliver a 5-day workshop; it instead should be used as learning materials for an instructor.  Each 'day folder' has excellent documentation about how to use Unity for each stage of the project.  The solutions branch will contain all scripts pertaining to the project.

The actual workshop flow is detailed below in this document and has been updated to reflect two rounds of delivery during Spring Break 2017.

## Overview of Workshop Flow
Throughout the entire workshop, twice daily standups and stretching exercises, one in the morning and one before lunch are given with a brief status update and any difficulties students have. The curriculum is built in a way that hand-coded systems are introduced before using a turn-key solution such as Unity's Navigation system and built-in FPSController prototyping GameObject so that students can appreciate what happens at a lower level.  The overall flow is also designed to be on train tracks until end of day 2 when the training wheels slowly come off ending in a Demo Day.

*Day 1 and 2* are very rigorous hands-on guided coding and troubleshooting days as students follow along with live-coding scripts.  

*On Day 3* when most of the complex scripts are out of the way, students are allowed to go on the asset store to download *free* assets and slowly put some creativity and polish to their game.  

*Day 4* the training wheels come off and MVP concepts, make-it-work-before-polishing, and project management concepts are introduced.  Students are guided to research problems on their own as instructors nudge them in the correct direction whether it's troubleshooting what they already have or implementing new features that weren't taught in the class. Student's are encouraged to research and implement new features. Instructor's can also demo stretch goals and polish features which are listed at the end of this readme.

*Day 5* culminates with a Demo Day where everybody builds their game into an executable and presents it on the big screen, practicing their presentation skills and learning how to speak about technical things.

## Day 1 
1. Gather up students away from computers in a circle, Nat introduces herself and gives a formal welcome & housekeeping stuff.
1. Talk about student expectations, more about collaborating and not competing.  Helping each other get unstuck etc.
1. Set up Unity Dev environment, making sure all students can sign into their Unity and create a folder they save their projects into
1. Intro to the Asset Pane, Game View, Inspector, Hierarchy. Concepts of 3d coordinate space and Unity's 'Transform' component
1. Have students follow along and create a quad to be used as the game floor.
1. Have students create a sphere to act as a player.
1. Show students what Rigidbodies are by demonstrating on the sphere dropping through the floor if there isn't one.
1. Live-code PlayerMove.cs without jump functionality.
1. Live-code CameraFollow.cs
1. Show students how to create new materials in order to color their primitive game objects.
1. Have students color all their objects.
1. Have students create another sphere for the enemy.
1. Live-code EnemyMove.cs 
1. Have students create a goal box.
1. Show students how to create a trigger collider on the goal box
1. Go back to PlayerMove.cs and add jump functionality.
1. Rest of the time: Have class use primitive objects to architect out their 'maze'.

### Notes:
*The reason why we don't implement jump functionality right away is to introduce students the concept of going back to an 
existing script and patching something in.  This will give them an early start of jumping into a context they have previously built.
*Depending on the skill-level distribution of the class, each live-coding session should have a high-level overview of what's actually going on and what the script is doing.  This is up to the instructor to decide how deep to go according to the classes skill-level distribution.

## Day 2
1. Have students create a Canvas
1. Have students create a Slider as a child of Canvas
1. Set Slider to not-interactable, maxHealth to 10 and value to 10
1. Live-code PlayerHealth.cs
1. Live-code EnemyAttack.cs
1. Live-code EnemyHealth.cs
1. Live-code PlayerAttack.cs
1. Only after all the previous scripts have been debugged, allow students to go onto Asset store.

### Notes:
* The second day has a lot of scripts that interact with each other which will slow the class down.  These are not trivial things for non coders.  A lot of handholding will happen.
* A strategy that can be employed to accomodate wider ranges of skill-level in workshops is when the asset store is introduced, they will pretty much be in guided sandbox mode.  So instructors can ask if students want a deeper explanation of the code, and the ones who want - usually the more advanced ones, can break off into a group with the instructor taking them deeper while the rest of the class will be in 'building/minecrafting' mode with the asset store.

## Day 3
1. Finish the game loop by introducing Menu Screens & Restart Buttons
1. Have students save their current scene and create a *new* scene
1. Have students create a Canvas
1. Have students attach a Button to the Canvas
1. Have students create RestartButton.cs script and attack to Button
1. Live-Code RestartButton.cs 
  1. In the script, make a reference to the Button component
  1. Add an event listener to the Button
  2. Execute a loadScene function that calls SceneManager.LoadScene("their_maze_scene_here")
1. Go into their goal.cs OnTriggerEnter hook functions and add SceneManager.LoadScene("their_menu_or_restart_scene_here")
1. Refactor EnemyMove.cs to use NavMesh baking and NavMesh Agents.
1. Show the students FPSController.
1. Rest of the day: Guided research into new features and troubleshooting.

### Notes
* Navmesh baking and Navmesh Agent is introduced on Day 3 because we want them to do navigation the 'hard-way' 
so they can appreciate the intracacies of physics and navigation.  Also usually by this time, their maze is complex
enough that they see a need to fix their enemies simple navigation system because they will keep bumping into walls
and get stuck.

## Day 4
1. Re-emphasize project scope and MVP, let them know they are presenting tomorrow after lunch so try to finish and polish
by end of day so the next day morning can be left to unforseen problems and additional polish.
1. The rest of the day should be dedicated to directed research and troubleshooting completely taking off training wheels.
1. Encourage students to learn new features, such as simple animations which is a good opportunity to show them how to self-learn.
1. A list of 'stretch goals' and 'polish' type of features will be listed below that can be sprinkled throughout the day
by showing students how to do it on the big screen.
1. Remind students to bring flash drive for last day.

## Day 5
1. Show students how to make a build of their game.
1. Show students how to export their entire project so they can work on it at home.
1. Before lunch, have a round-robin play test where everybody switches computers to play each others games.
1. Show students how to give constructive feedback.
1. After lunch have Demo Day
1. Give out stickers & swag
1. Have a final standup, thank the students, and get feedback about the course from the students.

### Summary Script Order:
1. PlayerMove.cs - Day 1
1. CameraFollow.cs - Day 1
1. Goal.cs - Day 1
1. PlayerHealth.cs - Day 2
1. EnemyAttack.cs - Day 2
1. EnemyHealth.cs - Day 2
1. PlayerAttack.cs - Day 2
1. Canvas/UI/Buttons & SceneManager - Day 3
1. RestartButton.cs (not in repo yet) - Day 3

### Stretch Goals:
These are additional features & polish ideas that are outside of the main structured curriculum that can be sprinkled across
the second half of the workshop when they are in project mode.
* Health Packs
* Regenerating Health
* Skybox
* Audio, background music
* Skybox
* Countdown timers that trigger certain events
* Zones that increase health
* Zones that decrease health
* Having enemies patrol certain waypoints on the Navmesh
* Animation


### Other Notes:
1. *IMPORTANT!* When parents come to pick the students up, make sure to greet the parents!
1. It was found out that students who had prior exposure up to object oriented programming had an easier time implementing new behaviour and features that required code.  Basic OOP and all the fundamental programming concepts that lead up to it can be a pre-req for an 'intermediate/advanced' Unity track/workshop.
1. Days 4 and 5 are excellent days to train instructors since these days are showing polish/stretch-goal items ala-carte and are not interwoven too tightly with any of the complex scripts.
