# AI Usage Log — Code Escape

## Assignment 4: Core Gameplay, Physics and Architecture

### 1. AI Tools Used

ChatGPT was used to assist with the development, debugging, architecture planning, and documentation of Code Escape.

AI assistance included:
- Generating and organizing Unity C# scripts.
- Implementing player movement and physics interactions.
- Designing the class architecture.
- Creating the UML/Mermaid diagram.
- Debugging gameplay and Web build issues.
- Reviewing the implementation against Assignment 4 requirements.

### 2. Architecture Review

AI was used to compare the planned architecture with the final implementation.

The final project separates responsibilities between the following components:

| Component | Responsibility |
|---|---|
| LevelBuilder | Creates the maze and game objects |
| PlayerMovement | Handles player movement and interaction |
| PushableCrate | Handles crate physics |
| KeyPickup | Handles key collection |
| ExitZone | Detects the exit |
| GameSession | Manages game progress and victory |
| GameHUD | Displays gameplay information |
| BoardView | Renders the game visually |

The architecture uses events to communicate game-state changes to the user interface.

### 3. Differences Between Planned and Final Architecture

**Change 1 — Rendering system**

The initial implementation used Unity 3D objects and materials to display the level.

During testing, rendering problems appeared in the browser version.

The final version uses a separate `BoardView` component for visual rendering while keeping Unity physics for gameplay interactions.

**Reason:** Improve browser compatibility and separate visual presentation from gameplay logic.

**Change 2 — Exit detection**

Earlier implementations relied primarily on trigger detection to complete the game.

Testing revealed that the player could reach the green exit without activating the win condition.

The implementation was revised to improve exit detection.

**Reason:** Ensure the game reliably recognizes successful completion.

**Change 3 — Component responsibilities**

The architecture was organized into smaller classes for player movement, collectibles, physics, game state, and UI.

**Reason:** Improve maintainability and follow the Single Responsibility Principle.

### 4. Physics Implementation Review

The project includes the five physics features required by Assignment 4:

| Physics feature | Implementation |
|---|---|
| CharacterController | PlayerMovement |
| Rigidbody | PushableCrate |
| AddForce | PushableCrate |
| Raycast | PlayerMovement |
| Collision | PushableCrate |

The physics logic is separated from the game's visual presentation.

### 5. Event-Based Communication

`GameSession` publishes events when keys are collected, messages change, or the player wins.

`GameHUD` listens to these events and updates the interface.

This approach was selected instead of direct calls between game rules and UI components, reducing dependencies.

### 6. Testing and Debugging

Several iterations were tested during development.

**Problems encountered:**
- Incorrect or missing Unity scenes.
- Web rendering problems.
- Exit detection not activating correctly.
- Differences between Unity Editor and browser behavior.

**Improvements made:**
- Included a proper Unity scene.
- Revised the rendering approach.
- Improved the exit detection logic.
- Added a victory screen and restart functionality.

The final revised project was tested in the Unity Editor and confirmed to run successfully.

### 7. AI Contributions and Developer Decisions

AI generated code suggestions, architecture diagrams, documentation, and debugging recommendations.

The developer tested the game in Unity, identified problems, reviewed the results, and requested corrections.

The final design prioritizes clear class responsibilities, event-based communication, and reliable gameplay.

### 8. Conclusion

AI assistance helped develop and revise Code Escape throughout Assignment 4.

The architecture review documented differences between the initial design and the final implementation, particularly in rendering, exit detection, and component organization.

The resulting project demonstrates the required physics features and a modular architecture designed for future extensions.
