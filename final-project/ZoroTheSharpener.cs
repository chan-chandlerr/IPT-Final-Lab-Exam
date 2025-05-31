// final-project/ZoroTheSharpener.cs
using System;
using System.Collections.Generic;
using System.Drawing;

namespace final_project
{
    public class ZoroTheSharpener : ClassroomChampion
    {
        public override ShapeType CharacterShape => ShapeType.Triangle;
        public override Brush CharacterBrush => Brushes.DarkGreen;

        public ZoroTheSharpener(string playerName) : base(playerName + " (Zoro the Sharpener)", 110)
        {
        }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Sharpened Slash", "A precise cut with a perfectly sharpened pencil.", 30, 40, 90, "Good, reliable damage.",
                (attacker, defender) => Tuple.Create(random.Next(30, 41), $"{attacker.Name} delivers a 'Sharpened Slash'!")
            ));

            Moves.Add(new AttackMove("Three-Style Focus", "Focuses intensely, boosting attack power.", 0, 0, 100, "Raises user's Attack for 3 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.AttackUp, 3);
                    return Tuple.Create(0, $"{attacker.Name} enters 'Three-Style Focus'! Attack sharply rose!");
                }
            ));

            Moves.Add(new AttackMove("Dragon Twister Draft", "A whirlwind of sharp diagrams confuses the foe.", 20, 30, 85, "Mod. damage. 25% chance to lower opponent's Accuracy.",
                (attacker, defender) => {
                    int damage = random.Next(20, 31);
                    string narrative = $"{attacker.Name} creates a 'Dragon Twister Draft'!";
                    if (random.Next(1, 101) <= 25)
                    {
                        defender.ApplyStatusEffect(StatusEffect.AccuracyDown, 2);
                        narrative += $" {GetDisplayName(defender)} is disoriented, Accuracy Down!";
                    }
                    return Tuple.Create(damage, narrative);
                }
            ));

            Moves.Add(new AttackMove("Asura: Silver Mist", "An illusionary nine-pencil strike.", 45, 65, 70, "Very high power. Ignores Evasion (concept).",
                (attacker, defender) => {
                    // True ignore evasion would require modification in ClassroomChampion.ExecuteChosenAttack
                    // This is just a strong attack for now.
                    return Tuple.Create(random.Next(45, 66), $"{attacker.Name} unleashes 'Asura: Silver Mist' with blinding speed!");
                }
            ));
        }
        private static string GetDisplayName(ClassroomChampion champion) =>
            champion.Name.Contains(" (") ? champion.Name.Substring(0, champion.Name.IndexOf(" (")) : champion.Name;
    }
}