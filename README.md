# C# Console Engine (Snake)

## Overview
While this project takes the visual form of a classic console game, it was specifically built as an exercise in **Enterprise Architecture Patterns**, **Clean Code**, and **Separation of Concerns (SoC)** in .NET. 

The goal of this project was to take a standard procedural `while(true)` loop and refactor it into a highly decoupled, object-oriented system capable of broadcasting non-blocking side effects.

##  Architecture & Technical Highlights

* **Event-Driven Architecture:** Implemented standard C# `Action` delegates (`OnGameOver`, `OnAppleEaten`) to act as the Observer pattern. This allows independent systems to react to state changes without tightly coupling them to the core logic engine.
* **Separation of Concerns (SoC):** The application is strictly divided into logical components. The `Engine` handles pure math and collision, the `Renderer` translates state to the UI, and the `InputHandler` processes keystrokes.
* **Data Immutability:** Utilized C# `readonly record structs` for spatial coordinates to enforce immutability, ensuring that grid positions are evaluated by value equality rather than reference, preventing reference-mutation bugs.
* **Optimized I/O Rendering:** Replaced standard `Console.Clear()` calls with a single-pass `StringBuilder` buffer. The renderer paints the entire grid in memory before dumping it to the console in one operation, completely eliminating screen tearing and flickering.

##  How to Run

Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.

1. Clone the repository:
   ```bash
    git clone https://github.com/Fowmaro/SnakeGame.git
   ```
2. Navigate to the project directory:
   ```Bash
    cd SnakeGame
   ```
3. Run the application:
   ```Bash
    dotnet run
   ```
