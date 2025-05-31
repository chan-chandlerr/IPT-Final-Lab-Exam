// final-project/SanjiTheCook.cs
using System;
using System.Collections.Generic;
using System.Drawing;

namespace final_project
{
    public class SanjiTheCook : ClassroomChampion
    {
        public override ShapeType CharacterShape => ShapeType.RoundedRectangle;
        public override Brush CharacterBrush => Brushes.Goldenrod; // Suave gold/yellow

        public SanjiTheCook(string playerName) : base(playerName + " (Sanji the Cook)", 105)
        {
        }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Collier Strike", "A swift kick to the neck area.", 28, 38, 90, "Fast and precise damage.",
                (attacker, defender) => Tuple.Create(random.Next(28, 39), $"{attacker.Name} delivers a 'Collier Strike'!")
            ));

            Moves.Add(new AttackMove("Diable Jambe: Flambage Shot", "A flaming high kick.", 35, 50, 80, "Powerful fire kick. 25% chance to lower opponent's Defense.",
                (attacker, defender) => {
                    int damage = random.Next(35, 51);
                    string narrative = $"{attacker.Name} ignites 'Diable Jambe: Flambage Shot'!";
                    if (random.Next(1, 101) <= 25)
                    {
                        defender.ApplyStatusEffect(StatusEffect.DefenseDown, 2);
                        narrative += $" The intense heat weakened {GetDisplayName(defender)}'s defense!";
                    }
                    return Tuple.Create(damage, narrative);
                }
            ));

            Moves.Add(new AttackMove("Sky Walk Prep", "Prepares for an aerial assault.", 0, 0, 100, "Boosts user's Attack & Evasion for 2 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.AttackUp, 2);
                    attacker.ApplyStatusEffect(StatusEffect.EvasionUp, 2);
                    return Tuple.Create(0, $"{attacker.Name} readies for 'Sky Walk', feeling faster and stronger!");
                }
            ));

            Moves.Add(new AttackMove("Anti-Manner Kick Course", "A full course of devastating kicks.", 20, 25, 85, "Hits 2-3 times.",
                 (attacker, defender) => {
                     int hits = random.Next(2, 4); // 2 or 3 hits
                     int totalDamage = 0;
                     for (int i = 0; i < hits; i++) totalDamage += random.Next(20, 26);
                     return Tuple.Create(totalDamage, $"{attacker.Name} serves an 'Anti-Manner Kick Course', hitting {hits} times!");
                 }
            ));
        }
        private static string GetDisplayName(ClassroomChampion champion) =>
            champion.Name.Contains(" (") ? champion.Name.Substring(0, champion.Name.IndexOf(" (")) : champion.Name;
    }
}