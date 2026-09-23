# FruitNinja VR
This is a VR candy-slicing game built in Unity based on the mobile game Fruit Ninja. A player starts the game by grabbing a virtual Candy Cane to slice different types of candy worth different amounts of points as they fly up into the candy-themed arena and fall back down. 

## Gameplay

Objects are randomly spawned below the play area within a certain radius and launched upwards using Unity's physics system. The player must slice them with the virtual cane before they fall. 

- **Candy, chocolate, and lollipops** can be sliced to earn points. Sliced candy split into smaller pieces before disappearing. 
- **Mines** will subtract points and trigger an explosion effect when hit.
- **Clocks** will temporarily freeze time when sliced, allowing the player to slice all candy currently stuck in frozen time. 
- **Restart/Save Score** can be clicked to restart the game and save the score you have achieved up to that point, adding it to the leaderboard if it is high enough.
- **Increase Difficulty** can be clicked to make the game more difficult as clocks are disabled and there are more mines.

Object types, location, spawn time, and force are randomized.

## Built with
- Unity 2022.3.45f1
- C#
- Unity XR
- Unity Physics
- Unity XR Interaction Toolkit 2.6.4
- Unity OpenXR Plugin 1.12.0
- Oculus XR Plugin 4.2.0
- Unity XR Management 4.4.0
- Unity Input System 1.8.1
- Unity Physics
- Unity ProBuilder (asset creation)
- TextMeshPro

## How to Open
- Clone this repository.
- Open the project through Unity Hub.
- Use Unity 2022.3.45f1.
- Open the project's main scene.
- Run the project with the VR/XR setup configured in the project.

## Project Structure

The project contains Unity scenes, prefabs, GameObjects, scripts, UI, and other assets used to build the game.

The main gameplay logic is implemented in C# and handles object spawning, physics interactions, collision detection, scoring, the freeze mechanic, difficulty changes, and the high-score leaderboard.

## Project Status

This is an archived project originally developed around 2024. It is preserved as a record of the completed project and may require additional configuration to run on modern hardware or software.

## Credits
Programming & gameplay: Muaaz Aslam
3D assets & additional programming: Ryan Sharma