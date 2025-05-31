// final-project/StatusEffect.cs
namespace final_project
{
    public enum StatusEffect
    {
        None,
        Poisoned,       // Takes damage each turn
        AttackUp,       // Deals more damage
        DefenseUp,      // Takes less damage
        AttackDown,     // Deals less damage
        DefenseDown,    // Takes more damage
        AccuracyDown,   // Higher chance for own moves to "miss" 
        EvasionUp       // Higher chance for opponent's moves to "miss"
    }
}