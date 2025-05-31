# Straw Hat Champions: RPG Battle Simulator

## 🌟 Project Description
Welcome to the Straw Hat Champions: RPG Battle Simulator! This C# Windows Forms application brings a slice of the One Piece world to life through turn-based RPG combat. Players select their favorite Straw Hat Pirate, each rendered as a unique geometric shape with distinct colors and abilities, and battle it out. The game features a custom GDI+ rendered battle scene, interactive attack choices, complex moves with status effects, and a dynamic battle log, all inspired by classic handheld RPGs like Pokémon Game Boy.

This project was developed with a strong emphasis on applying core Object-Oriented Programming (OOP) principles to create a flexible and extensible game structure.

## ✨ Key Features
* **Turn-Based Combat System:** Engage in strategic battles where players take turns selecting actions.
* **Character Selection:** Choose from a growing roster of characters inspired by the Straw Hat Pirates.
    * Currently implemented: Luffy, Zoro, Nami, Usopp, and Sanji, each with unique visual designs and gameplay styles.
* **Unique Character Abilities:** Every character has a custom set of `AttackMove` objects reflecting their iconic skills.
* **Interactive Attack Choice:** During their turn, players see a list of their character's available moves, view details, and strategically choose their action.
* **Complex Attack Moves & Status Effects:** Attacks go beyond simple damage, incorporating:
    * **Status Effects:** Poison, Attack Up/Down, Defense Up/Down, Accuracy Down, Evasion Up.
    * **Variable Damage & Accuracy:** Moves have defined damage ranges and accuracy percentages.
    * **Buffs & Debuffs:** Characters can boost their own stats or weaken opponents.
    * **Utility Moves:** Some moves focus on applying effects or healing rather than direct damage.
* **GDI+ Rendered Battle Scene:**
    * Characters are visually represented by distinct **geometric shapes** (e.g., Circle for Luffy, Triangle for Zoro) and character-specific colors.
    * Custom-drawn **health bars** directly on the battle panel provide clear visual feedback.
    * **Status effect icons** appear next to affected characters.
    * Simple visual **"hit" animations** (shapes flashing) provide combat feedback.
    * Thematic background and character "platforms".
* **Dynamic Battle Log:** A running commentary details all actions, damage dealt, status effects applied, and knockout announcements.
* **Robust Exception Handling:** User input and potential runtime issues are managed to prevent crashes.

## 👒 Characters
The heart of the game lies in its characters, each a unique interpretation of a Straw Hat Pirate, designed for this classroom-themed battle simulator.

* **Luffy the Quiz Whiz:**
    * **Shape & Color:** Crimson Circle.
    * **Description:** A resilient fighter with a mix of powerful single-target and multi-hit "quiz" and "answer" based attacks. Can also boost his own evasion or attempt high-power, less accurate "Conqueror's Queries."
* **Zoro the Sharpener:**
    * **Shape & Color:** Dark Green Triangle.
    * **Description:** A focused attacker with strong, precise "sharpened" slashes. Can boost his own attack power significantly and has moves with high critical hit potential or that can lower opponent's accuracy.
* **Nami the Navigator:**
    * **Shape & Color:** OrangeRed Star.
    * **Description:** A strategic character excelling in "weather" and "tempo" based moves that often apply status effects like lowering opponent's Defense or Accuracy, or boosting her own Evasion or Attack.
* **Usopp the Sniper:**
    * **Shape & Color:** OliveDrab Hexagon.
    * **Description:** A ranged specialist using various "Star" projectiles. His attacks can cause explosions, create smokescreens to lower opponent accuracy, or inflict poison with fiery shots.
* **Sanji the Cook:**
    * **Shape & Color:** Goldenrod Rounded Rectangle.
    * **Description:** A fast and powerful kicker with "Diable Jambe" flaming attacks that can lower opponent's defense. He can also prepare for an aerial assault by boosting his own Attack and Evasion.

*(The game is designed to easily add the remaining Straw Hat crew members – Chopper, Robin, Franky, Brook, and Jinbe – by creating new character classes that define their unique shape, color, stats, and move sets.)*

## 💻 Object-Oriented Programming (OOP) Principles Applied

OOP principles are central to the project's design:

* **Abstraction:**
    * The `ClassroomChampion` abstract class defines the essential contract for all fighters. It includes abstract properties like `CharacterShape`, `CharacterBrush`, and `InitializeMoves()`, forcing derived classes to provide concrete implementations while hiding the specific details.
    * Common attributes (`Name`, `Health`) and behaviors (`TakeDamage`, `ExecuteChosenAttack`, status effect management) are also part of this abstraction.
    * The `AttackMove` class encapsulates the properties and execution logic of an attack, abstracting the specific action behind a common `ExecuteAction` delegate.

* **Inheritance:**
    * Each specific character class (e.g., `LuffyTheQuizWhiz`, `ZoroTheSharpener`, `NamiTheNavigator`) inherits from `ClassroomChampion`.
    * This allows them to inherit shared functionality (health system, status effect dictionary, attack execution framework) and extend it with their unique characteristics (specific moves, shape, color).

* **Polymorphism:**
    * The `InitializeMoves()` method is overridden by each character class, allowing each character to have a distinct set of `AttackMove` objects.
    * The `CharacterShape` and `CharacterBrush` abstract properties are overridden in derived classes, enabling the `DrawCharacterShape` method in `Form1.cs` to render different visuals for each character type through a common `ClassroomChampion` reference.
    * The `ExecuteAction` `Func` within each `AttackMove` object allows for diverse attack behaviors (damage, status effects, healing) to be invoked through a common call in `ClassroomChampion.ExecuteChosenAttack`.

* **Encapsulation:**
    * Character data like `_health` is encapsulated within `ClassroomChampion` (as a private field, with controlled access via a public property that clamps values).
    * The `ActiveStatusEffects` dictionary and its management logic (applying, ticking down) are encapsulated within `ClassroomChampion`.
    * Each `AttackMove` object encapsulates its own data (name, damage range, accuracy, effect details) and behavior (`ExecuteAction`).

* **Exception Handling:**
    * `try-catch` blocks are used in `Form1.cs` (e.g., in `btnStartBattle_Click`) to gracefully handle potential issues like missing user input (empty names, no character selection) or other unexpected runtime errors, preventing application crashes and providing informative messages to the user.

## 🚀 How to Run the Project
1.  **Clone or Download:** Obtain the project files.
2.  **Open in Visual Studio:** Launch the `.sln` solution file in Visual Studio (2019 or newer recommended).
3.  **Ensure Files:** Verify all `.cs` files (core classes, character classes, `Form1`, `Program`) are included in the Solution Explorer.
4.  **Build:** From the menu, select `Build > Build Solution` (or `Ctrl+Shift+B`). Address any build errors.
5.  **Run:** Click the "Start" button (green play icon) or press `F5`.
6.  **Play:**
    * Enter player names and select characters using the ComboBoxes.
    * Click "Start Battle!". The main button will guide you to prepare turns.
    * When prompted, select an attack from the list (details appear below it).
    * Click "ATTACK!" to execute the move.
    * Enjoy the battle!

## 🛠️ Technologies Used
* **C# Programming Language**
* **.NET Framework** (based on project structure, e.g., `App.config`)
* **Windows Forms (WinForms)** for the application UI framework.
* **GDI+ (System.Drawing namespace)** for all custom 2D graphics rendering in the battle scene (character shapes, health bars, status icons, effects).

## 🚧 Challenges Faced & Potential Future Improvements

### Challenges Faced During Development:
* **GDI+ Integration:** Implementing smooth, flicker-free custom drawing for the dynamic battle scene (character shapes, health updates, status icons, hit animations) within the WinForms framework required careful management of `Paint` events and `Invalidate()` calls.
* **Complex Game State Management:** Handling turns, attack choices, the application and duration of multiple status effects, and ensuring the UI correctly reflected all these states became intricate.
* **Character & Move Design:** Creating distinct, thematic, and somewhat balanced move sets with varied effects for multiple characters was an iterative design challenge.
* **UI Layout & Aesthetics:** Designing an intuitive and visually appealing UI that incorporates both standard WinForms controls and a custom-drawn battle panel, while drawing inspiration from a retro Game Boy style.

### Potential Future Improvements:
* **Complete the Straw Hat Crew:** Implement classes for Chopper, Robin, Franky, Brook, and Jinbe with unique moves, shapes, and abilities.
* **Advanced Status Effects:** Introduce more nuanced effects like Sleep, Paralysis (chance to not act), Confusion, multi-turn charging moves, or stat-stealing attacks.
* **Animated Visuals:**
    * Animate character shapes during idle states, attacks, or when hit (beyond simple flashing).
    * Add visual effects for specific attack moves.
* **Sound Design:** Incorporate sound effects for attacks, menu navigation, and background music to enhance the game's atmosphere.
* **AI Opponent:** Develop varying levels of AI for a single-player mode.
* **Refined Graphics:** Potentially move towards using actual pixel art sprites for characters and backgrounds for a truer retro aesthetic, though this would be a significant graphical overhaul.
* **More Environment Interaction:** Different battle backgrounds or stages.
* **Save/Load Game State.**
