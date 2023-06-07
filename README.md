# dino-frontier
User Interface (UI) and Menu System

The UI and menu system in the game are developed using Unity with C#.
The buttons in the UI are based on a template and utilize Unity Events for customizing their behavior.
Resource bars are implemented using the Unity Slider component to display the amount of each resource.
Blur Effect

A blur effect is applied when the menu opens to create a visually appealing transition.
The effect is achieved by using a custom script and leveraging Unity's UI blurred material.
Watch System

A watch is displayed on the screen, showcasing the current time.
The watch functionality is implemented by attaching a script to the watch GameObject, which updates the time display.
Character Movement with Unity NavMesh

Game characters are moved using Unity's NavMesh system.
Moveable characters have a NavMesh Agent component attached.
Navigation modifiers are used to designate specific areas as walkable or not walkable.
A NavMesh Surface GameObject generates the navigation mesh for the NavMesh Agents to move on.
Camera Movement

The camera movement system supports two modes: locked-in and edge-scrolling.
In the locked-in mode, the camera follows the player character.
Edge-scrolling allows the camera to move freely when the player moves the mouse to the screen edges.
A camera movement script handles edge-scrolling and includes correction for sudden camera jumps caused by low framerates.
Function Timer

The Function Timer class facilitates timing events in the game.
It creates a new GameObject with a timer counter and executes a specified action when the time elapses.
After execution, the GameObject is destroyed.
Resource Types and Manager

Resource types are defined as Unity Scriptable Objects, which store information about each resource type, such as capacity.
A Resource Manager GameObject acts as the engine for the resource system.
Buildings set the production of resources through the Resource Manager and update the resource bars' sliders accordingly.
Interaction System

The game features an interaction system for objects the player can interact with.
The Interactable script designates objects as interactable and makes the UI visible.
Collision detection using colliders is employed to detect interactions.
The Player Interact script handles player input for interacting with objects.
Interactable objects can have individual interaction actions through Unity Actions.
Building System

Buildings in the game can be constructed by the player.
A Unity Scriptable Object is used to define buildings, including their properties.
Each building has its own prefab and script.
The Build Manager script checks if the player can place a building in a specific spot and creates the building GameObject upon mouse click.
Task System

The game incorporates a task system that can be solved by NPCs or the player.
Each task contains information about its position and the action to be performed when completed.
The Task System provides a function, requestNextTask, to retrieve the next available task.
Future Development

The game will include a storm system with timed storms.
Additional civilizations will be introduced, expanding beyond just the player.
A story mode will be implemented to enhance the game's narrative experience.
This programming documentation provides an overview of the various features and systems implemented in [Game Name]. It serves as a reference for understanding the game's mechanics and can aid in further development and maintenance.

Please note that this documentation covers version 1.0 of the game and may require updates as the project progresses.
The codes are in the asset/ scripts folder.
