# KarioMart
Created by Robin Zeitlin Talamo

# Setup 
To start the game extract the zip file. And start up the Assignment 2023-09-21 CarGame application. Or add it as a project in unity by pressing the Open button and adding the extracted project files.

The game is a 2 player car racing game. Player one uses the WAD keys to move after starting the engine with R, Player two uses the Arrow keys to move after starting the engine with Num 0.

# Goal 
The game is a 2 player local racing game where the players race around avoiding the obstacles (people walking over the road and cars driving around). There is level selection, pause menu and a start menu that the player can navigate through. The first player too do 3 laps wins and then it switches to the next map. If there are no more maps. The maps will loop around and the player will start from Level 1.

# Process
I started of by making the player controllers, and input. The cars have two scripts one for input handling and one for collsion. The cars move by using unitys built in physics system and the inputs work by using unity input system (new). I then made bumping and knockback. This is done by adding force to the player based on the rotation of the point of impact. As seen below ⬇️

![image](https://github.com/RobinZeitlin/KarioMart/assets/144109907/5cb14a29-104f-4fc2-9415-984e9548ce37)

I made a start system, lap counter and checkpoint system for finnishing. Then it came to powerups. I decided not to overcomplicate it and added a  trigger check on the cars checking for the tag of the object. I then added an initialization system. The scene changes to the startscene and the scenemanager gets loaded, which is the script controlling lap count and loading new scenes when a player wins. The initialization scene is easily chooseable through enum.

![image](https://github.com/RobinZeitlin/KarioMart/assets/144109907/0894cfa8-e7c3-4163-8246-8a60fa15ee6a)


# Resources

https://docs.unity.com/

# Sounds used

Race Start Beep - https://freesound.org/people/JustInvoke/sounds/446130/

GO sound effect - https://freesound.org/people/owly-bee/sounds/415341/

Car Engine - https://freesound.org/people/Grasopt/sounds/479351/

Car Running - https://freesound.org/people/MarlonHJ/sounds/242740/

Car Crash - https://freesound.org/people/qubodup/sounds/151624/
