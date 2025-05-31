// final-project/AttackMove.cs
using System;

namespace final_project
{
    public class AttackMove
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public string EffectDetails { get; set; }
        public int Accuracy { get; set; } // Accuracy percentage (e.g., 90 for 90%)

        // Func takes: Attacker, Defender. Returns: Damage dealt (int), Attack narrative (string)
        public Func<ClassroomChampion, ClassroomChampion, Tuple<int, string>> ExecuteAction { get; set; }

        public AttackMove(string name, string description, int minDamage, int maxDamage, int accuracy,
                          string effectDetails, Func<ClassroomChampion, ClassroomChampion, Tuple<int, string>> executeAction)
        {
            this.Name = name;
            this.Description = description;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Accuracy = accuracy;
            this.EffectDetails = effectDetails;
            this.ExecuteAction = executeAction;
        }

        public override string ToString()
        {
            return $"{Name} (Dmg: {MinDamage}-{MaxDamage}, Acc: {Accuracy}%) - {EffectDetails}";
        }

        public string GetFullDescription()
        {
            return $"{Description}\nDamage: {MinDamage}-{MaxDamage} | Accuracy: {Accuracy}%\nEffects: {EffectDetails}";
        }
    }
}