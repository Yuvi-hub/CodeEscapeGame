# CodeEscapeGame
Code Escape

About the Game

Code Escape is a puzzle adventure game developed in Unity using C#. The player must navigate through a maze, collect three keys, move obstacles, and unlock the exit to escape.

The game demonstrates core gameplay mechanics, Unity physics, and modular code architecture.

Gameplay Features

* Maze-based puzzle gameplay
* Player movement using keyboard or on-screen controls
* Three collectible keys
* Movable physics crate
* Locked exit that opens after collecting the keys
* Win condition and restart functionality
* One complete playable level

Controls

* WASD / Arrow Keys: Move the player
* On-screen buttons: Alternative movement controls
* R: Restart the game

How to Play

1. Start the game.
2. Navigate through the maze.
3. Collect all three keys.
4. Move the crate to clear obstacles.
5. Reach the unlocked exit to win.
6. Restart to play again.

Technologies

* Unity 6
* C#
* Unity Physics
* WebGL

Project Structure

Assets/
├── Scenes/
├── Scripts/
│   ├── Player/
│   ├── Collectibles/
│   ├── Physics/
│   ├── Game/
│   └── UI/
Packages/
ProjectSettings/

Each script is organized according to its responsibility to keep the project maintainable and easy to extend.

Architecture and Class Relationships

The project separates player movement, collectible interactions, physics, game rules, and UI.

flowchart TD
    Player[Player Controller]
    Keys[Key Collectibles]
    Physics[Physics Interactions]
    Events[Game Events]
    State[Game State]
    UI[Game UI]
    Exit[Exit Trigger]
    Player --> Keys
    Player --> Physics
    Player --> Exit
    Keys --> Events
    Exit --> State
    Events --> State
    State --> UI

Architecture Decisions

1. Separation of Responsibilities

Player movement, collectibles, physics, and game rules are handled separately. This makes the game easier to maintain and extend.

2. Event-Based Communication

Game events can notify other components about collected keys or changes in the game state, reducing direct dependencies between gameplay and UI components.

3. Configurable Gameplay

Gameplay values should be configurable through Unity’s Inspector rather than hardcoded throughout the scripts.

Extending the Game

To add a new collectible, create a new collectible object and connect it to the existing collection logic.

To add a new obstacle, create an object with the appropriate collider and physics components.

To add another level, create a new Unity scene and configure its maze, collectibles, and exit.

Running the Project

1. Clone or download this repository.
2. Open Unity Hub.
3. Select Add project from disk.
4. Open the project using Unity 6.
5. Open Assets/Scenes/Main.unity.
6. Press Play.

Play Online

itch.io: https://yvvvvvv.itch.io/code-escape-2

GitHub Repository

This repository contains the Unity project source code, gameplay scripts, scenes, and project configuration.
