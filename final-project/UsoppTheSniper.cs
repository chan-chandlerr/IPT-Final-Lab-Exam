// final-project/UsoppTheSniper.cs
using System;
using System.Collections.Generic;
using System.Drawing;

namespace final_project
{
    public class UsoppTheSniper : ClassroomChampion
    {
        public override ShapeType CharacterShape => ShapeType.Hexagon;
        public override Brush CharacterBrush => Brushes.OliveDrab; // Earthy tone

        public UsoppTheSniper(string playerName) : base(playerName + " (Usopp the Sniper)", 90)
        {
        }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Lead Star", "A basic slingshot pellet.", 15, 25, 95, "Simple and reliable.",
                (attacker, defender) => Tuple.Create(random.Next(15, 26), $"{attacker.Name} fires a 'Lead Star'!")
            ));

            Moves.Add(new AttackMove("Exploding Star", "A pellet that explodes on impact.", 25, 40, 85, "Deals good AoE-like damage.", // AoE is conceptual here
                (attacker, defender) => Tuple.Create(random.Next(25, 41), $"{attacker.Name}'s 'Exploding Star' bursts on {GetDisplayName(defender)}!")
            ));

            Moves.Add(new AttackMove("Smoke Star", "Creates a smokescreen.", 0, 0, 100, "Lowers opponent's Accuracy for 3 turns.",
                (attacker, defender) => {
                    defender.ApplyStatusEffect(StatusEffect.AccuracyDown, 3);
                    return Tuple.Create(0, $"{attacker.Name} uses 'Smoke Star'! {GetDisplayName(defender)}'s vision is obscured!");
                }
            ));

            Moves.Add(new AttackMove("Fire Bird Star", "A powerful, flaming bird projectile.", 35, 55, 70, "High power. 20% chance to Poison.",
                 (attacker, defender) => {
                     int damage = random.Next(35, 56);
                     string narrative = $"{attacker.Name} shoots the 'Fire Bird Star'!";
                     if (random.Next(1, 101) <= 20)
                     { // 20% poison chance
                         defender.ApplyStatusEffect(StatusEffect.Poisoned, 3);
                         narrative += $" {GetDisplayName(defender)} was also poisoned!";
                     }
                     return Tuple.Create(damage, narrative);
                 }
            ));
        }
        private static string GetDisplayName(ClassroomChampion champion) =>
            champion.Name.Contains(" (") ? champion.Name.Substring(0, champion.Name.IndexOf(" (")) : champion.Name;
    }
}