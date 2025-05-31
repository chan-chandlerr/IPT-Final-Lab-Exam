# Classroom Champions Battle Simulator

## Description
This project is a personalized RPG-style battle simulator created using C# and Windows Forms. 
Characters are themed around a classroom environment but use fun names inspired by the Straw Hat Pirates from One Piece.
Players can select their characters and engage in a turn-based battle until one champion emerges victorious.

## Characters
The simulator features characters with unique abilities, inspired by generic classroom themes:

1.  **Luffy "The Quiz Whiz"**:
    * **Theme**: Represents a student who excels at quizzes and quick thinking.
    * **Abilities**: Has a mix of attacks like "Gum-Gum Pistol Quiz" (standard barrage of questions), "Gum-Gum Gatling Answers" (rapid-fire correct answers), and a powerful "Conqueror's Haki Lecture" that deals significant damage representing an undeniable argument or flow of information.
    * **Health**: Slightly higher to represent resilience.

2.  **Zoro "The Sharpener"**:
    * **Theme**: Represents a student with a sharp mind, or perhaps always having perfectly sharpened pencils, symbolizing readiness and precision.
    * **Abilities**: Attacks like "Single-Pencil Strike" (a precise, standard attack), "Two-Pencil Style: Slash!" (a more focused and stronger attack), and the special "Three-Pencil Style: Onigiri!" representing a powerful and skillful intellectual blow.
    * **Health**: Standard.

## How OOP Principles Were Applied

1.  **Abstraction**:
    * An abstract class `ClassroomChampion` was created.
    * It defines the common properties (e.g., `Name`, `Health`, `MaxHealth`) and methods (e.g., `TakeDamage()`, `Heal()`) that all characters must have.
    * It includes an abstract method `Attack(ClassroomChampion opponent)`, which forces derived classes to implement their specific attack logic. This hides the complex implementation details of different attacks behind a simple interface.

2.  **Inheritance**:
    * Specific character classes like `LuffyTheQuizWhiz` and `ZoroTheSharpener` inherit from the `ClassroomChampion` abstract base class.
    * This allows them to reuse the common functionalities defined in `ClassroomChampion` (like `TakeDamage`) and also provide their own specialized implementations (like `Attack`).
    * *Comment Example*: `public class LuffyTheQuizWhiz : ClassroomChampion`

3.  **Polymorphism**:
    * The `Attack()` method is declared as `abstract` in `ClassroomChampion` and then `override`n in each derived character class (`LuffyTheQuizWhiz`, `ZoroTheSharpener`).
    * This means that when `player.Attack(opponent)` is called, the correct `Attack` method for the actual type of `player` (e.g., `LuffyTheQuizWhiz.Attack()`) is executed at runtime.
    * The battle logic in `Form1.cs` can treat all characters as `ClassroomChampion` objects but still invoke their specific behaviors.
    * *Comment Example*: `public override string Attack(ClassroomChampion opponent)` in derived classes.

4.  **Encapsulation**:
    * The internal state of `ClassroomChampion` and its derived classes (like the `_health` and `_name` fields) are kept `private` or `protected`.
    * Access to these fields is controlled through `public` properties (e.g., `Health`, `Name`).
    * For example, the `Health` property's setter includes logic to ensure health doesn't go below 0 or exceed `MaxHealth`. This protects the object's integrity.
    * *Comment Example*: `private int _health; public int Health { get; protected set; }`

5.  **Exception Handling**:
    * `try-catch` blocks are used in `Form1.cs` within the `btnStartBattle_Click` event handler.
    * These blocks handle potential issues such as users not entering player names or not selecting characters from the ComboBoxes.
    * User-friendly error messages are displayed using `MessageBox.Show()` to inform the user of the problem without crashing the application.
    * A general `catch (Exception ex)` is also included to handle any other unexpected errors during the setup phase.
    * *Comment Example*: `try { ... } catch (ArgumentNullException ex) { MessageBox.Show(...); }`

## Challenges Faced (and How They Were Addressed)

1.  **UI Responsiveness & Updates**:
    * **Challenge**: Ensuring the UI (health bars, battle log) updates immediately after each action.
    * **Solution**: Calling methods like `UpdateHealthDisplays()` and `AddToBattleLog()` at appropriate points in the battle logic, particularly after an attack and when initializing the battle.

2.  **Character Selection & Instantiation**:
    * **Challenge**: Dynamically creating character objects based on ComboBox selections.
    * **Solution**: Used a `Dictionary<string, Type>` to map the display names of characters in the ComboBox to their actual class `Type`. Then, `Activator.CreateInstance(type, constructorArgs)` was used to instantiate the selected characters. This makes adding new characters easier as well – just add them to the dictionary and create their class.

3.  **Turn Management**:
    * **Challenge**: Implementing a simple yet clear turn-based system.
    * **Solution**: Used a boolean flag `isPlayer1Turn` which toggles after each attack. The "Start Battle" button changes its text to "Next Turn" (or similar) to control the flow of the game after it starts.

4.  **Balancing Character Abilities**:
    * **Challenge**: Making character attacks varied and somewhat balanced without overcomplicating the damage logic.
    * **Solution**: Used `Random` for attack damage ranges and probabilities for different types of moves (normal, strong, special) within each character's `Attack` method. This provides unpredictability while allowing for distinct character "feels". Fine-tuning these ranges would be an iterative process based on playtesting.

5.  **Code Structure and Readability**:
    * **Challenge**: Keeping the code organized, especially with UI logic and game logic potentially mixing in the Form class.
    * **Solution**: Separated character class definitions into their own files (`ClassroomChampion.cs`, `LuffyTheQuizWhiz.cs`, etc.). Within `Form1.cs`, methods were created for specific tasks like `UpdateHealthDisplays`, `ResetUI`, `TakeTurn`, `EndBattle` to improve organization. Comments were added to explain OOP principles and design choices.

## Setup and Running the Project
1.  Open the project in Visual Studio.
2.  Ensure all `.cs` files (`Program.cs`, `Form1.cs`, `Form1.Designer.cs`, `ClassroomChampion.cs`, `LuffyTheQuizWhiz.cs`, `ZoroTheSharpener.cs`, and files under `Properties`) are included in the project.
3.  Build the solution.
4.  Run the application.
5.  Enter names for Player 1 and Player 2.
6.  Select a character for each player from the dropdowns.
7.  Click "Start Battle!".
8.  Click the button (which will now say "Next Turn" or similar) to proceed through the battle turns.
9.  The battle log will display actions, and health bars will update.
10. A winner will be announced when one character's health reaches zero.