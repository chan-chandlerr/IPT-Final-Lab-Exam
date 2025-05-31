// final-project/NamiTheNavigator.cs
using System;
using System.Collections.Generic;
using System.Drawing;

namespace final_project
{
    public class NamiTheNavigator : ClassroomChampion
    {
        public override ShapeType CharacterShape => ShapeType.Star;
        public override Brush CharacterBrush => Brushes.OrangeRed; // Changed slightly from Orange

        public NamiTheNavigator(string playerName) : base(playerName + " (Nami the Navigator)", 95)
        {
        }

        protected override void InitializeMoves()
        {
            Moves.Add(new AttackMove("Thunderbolt Tempo", "A shocking revelation.", 20, 30, 90, "25% chance to lower opponent's Defense.",
                (attacker, defender) => {
                    int damage = random.Next(20, 31);
                    string narrative = $"{attacker.Name} summons a 'Thunderbolt Tempo'!";
                    if (random.Next(1, 101) <= 25)
                    {
                        defender.ApplyStatusEffect(StatusEffect.DefenseDown, 3);
                        narrative += $" {GetDisplayName(defender)}'s defense fell!";
                    }
                    return Tuple.Create(damage, narrative);
                }
            ));

            Moves.Add(new AttackMove("Mirage Tempo", "Creates illusions, raising evasion.", 0, 0, 100, "Raises user's Evasion for 3 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.EvasionUp, 3);
                    return Tuple.Create(0, $"{attacker.Name} uses 'Mirage Tempo' and becomes elusive!");
                }
            ));

            Moves.Add(new AttackMove("Cyclone Tempo", "Whips up a confusing wind.", 15, 25, 85, "30% chance to lower opponent's Accuracy.",
                (attacker, defender) => {
                    int damage = random.Next(15, 26);
                    string narrative = $"{attacker.Name} conjures a 'Cyclone Tempo'!";
                    if (random.Next(1, 101) <= 30)
                    {
                        defender.ApplyStatusEffect(StatusEffect.AccuracyDown, 3);
                        narrative += $" {GetDisplayName(defender)}'s accuracy fell!";
                    }
                    return Tuple.Create(damage, narrative);
                }
            ));

            Moves.Add(new AttackMove("Fine Tempo", "Focuses and boosts attack power.", 0, 0, 100, "Raises user's Attack for 2 turns.",
                (attacker, defender) => {
                    attacker.ApplyStatusEffect(StatusEffect.AttackUp, 2);
                    return Tuple.Create(0, $"{attacker.Name} uses 'Fine Tempo'! Attack sharply rose!");
                }
            ));
        }
        private static string GetDisplayName(ClassroomChampion champion) =>
            champion.Name.Contains(" (") ? champion.Name.Substring(0, champion.Name.IndexOf(" (")) : champion.Name;
    }
}