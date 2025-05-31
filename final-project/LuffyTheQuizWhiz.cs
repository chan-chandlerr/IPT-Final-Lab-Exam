// final-project/LuffyTheQuizWhiz.cs
using System;
using System.Collections.Generic;
using System.Drawing;

namespace final_project
{
    public class LuffyTheQuizWhiz : ClassroomChampion
    {
        public override ShapeType CharacterShape => ShapeType.Circle;
        public override Brush CharacterBrush => Brushes.Crimson;

        public LuffyTheQuizWhiz(string playerName) : base(playerName + " (Luffy the Quiz Whiz)", 125)
        {
        }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Pistol Quiz", "A rapid-fire, stretchy question!", 25, 35, 95, "Standard reliable quiz attack.",
                (attacker, defender) => Tuple.Create(random.Next(25, 36), $"{attacker.Name} stretches out a 'Pistol Quiz'!")
            ));

            Moves.Add(new AttackMove("Gatling Answers", "A flurry of correct answers pummels the foe.", 10, 15, 90, "Hits 2-4 times.",
                (attacker, defender) => {
                    int hits = random.Next(2, 5);
                    int totalDamage = 0;
                    for (int i = 0; i < hits; i++) totalDamage += random.Next(10, 16);
                    return Tuple.Create(totalDamage, $"{attacker.Name} unleashes 'Gatling Answers', hitting {hits} times with sheer knowledge!");
                }
            ));

            Moves.Add(new AttackMove("Observation Haki Study", "Focuses, predicting thoughts.", 5, 10, 100, "Small damage. Boosts user's Evasion for 2 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.EvasionUp, 2);
                    return Tuple.Create(random.Next(5, 11), $"{attacker.Name} uses 'Observation Haki Study', becoming harder to hit!");
                }
            ));

            Moves.Add(new AttackMove("Conqueror's Query", "An overwhelmingly insightful question.", 40, 60, 75, "High power. 30% chance to lower opponent's Attack.",
                (attacker, defender) => {
                    int damage = random.Next(40, 61);
                    string narrative = $"{attacker.Name} poses a 'Conqueror's Query'!";
                    if (random.Next(1, 101) <= 30)
                    {
                        defender.ApplyStatusEffect(StatusEffect.AttackDown, 2);
                        narrative += $" {GetDisplayName(defender)}'s confidence wavers, Attack Down!";
                    }
                    return Tuple.Create(damage, narrative);
                }
            ));
        }
        // Helper to get just the player-inputted name if available for narratives
        private static string GetDisplayName(ClassroomChampion champion) =>
            champion.Name.Contains(" (") ? champion.Name.Substring(0, champion.Name.IndexOf(" (")) : champion.Name;
    }
}