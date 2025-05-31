// final-project/ClassroomChampion.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace final_project
{
    public enum ShapeType // Defined within this file or as a separate Enums.cs
    {
        Circle,
        Square,
        Triangle,
        Star,
        Hexagon,
        RoundedRectangle
    }

    public abstract class ClassroomChampion
    {
        private string _name;
        public string Name { get; protected set; }

        private int _health;
        public int Health
        {
            get => _health;
            // Health is set and clamped by TakeDamage or direct Heal calls
            // This protected set is mainly for initialization and direct healing.
            set => _health = Math.Max(0, Math.Min(value, MaxHealth));
        }

        private int _maxHealth;
        public int MaxHealth { get; protected set; }

        protected static Random random = new Random();

        public Dictionary<StatusEffect, int> ActiveStatusEffects { get; private set; }
        public abstract ShapeType CharacterShape { get; }
        public abstract Brush CharacterBrush { get; }

        public List<AttackMove> Moves { get; protected set; }

        public ClassroomChampion(string name, int maxHealth)
        {
            this.Name = name;
            this.MaxHealth = maxHealth;
            this.Health = maxHealth; // Initial health set here
            this.Moves = new List<AttackMove>();
            this.ActiveStatusEffects = new Dictionary<StatusEffect, int>();
            InitializeMoves();
        }

        protected abstract void InitializeMoves();

        public void ApplyStatusEffect(StatusEffect effect, int duration)
        {
            if (effect == StatusEffect.None) return;
            // If effect already exists, refresh or stack duration (here, we refresh)
            ActiveStatusEffects[effect] = duration;
        }

        public string HandleTurnStartStatusEffects(ClassroomChampion opponent)
        {
            string effectMessage = "";
            if (ActiveStatusEffects.ContainsKey(StatusEffect.Poisoned))
            {
                int poisonDamage = Math.Max(1, (int)(this.MaxHealth * 0.0625));
                this.Health -= poisonDamage;
                effectMessage += $"{this.Name} takes {poisonDamage} damage from poison! ";
            }
            // Example: Check for sleep, paralysis etc. here and return true if turn is skipped
            // For now, only poison has a direct start-of-turn effect beyond stat mods.
            return effectMessage.Trim();
        }

        public void TickDownStatusEffects()
        {
            var keys = ActiveStatusEffects.Keys.ToList(); // ToList allows modification during iteration
            foreach (var key in keys)
            {
                ActiveStatusEffects[key]--;
                if (ActiveStatusEffects[key] <= 0)
                {
                    ActiveStatusEffects.Remove(key);
                }
            }
        }

        public virtual string TakeDamage(int damageAmount)
        {
            if (damageAmount <= 0) return $"{this.Name} avoids the damage!";

            float defenseMultiplier = 1.0f;
            if (ActiveStatusEffects.ContainsKey(StatusEffect.DefenseUp)) defenseMultiplier -= 0.33f; // Takes 33% less
            if (ActiveStatusEffects.ContainsKey(StatusEffect.DefenseDown)) defenseMultiplier += 0.33f; // Takes 33% more

            int finalDamage = Math.Max(1, (int)(damageAmount * defenseMultiplier));

            this.Health -= finalDamage; // Setter clamps health >= 0

            string message = $"{this.Name} takes {finalDamage} damage";
            if (ActiveStatusEffects.ContainsKey(StatusEffect.DefenseUp) && defenseMultiplier < 1.0f) message += " (Defense Up helped!)";
            if (ActiveStatusEffects.ContainsKey(StatusEffect.DefenseDown) && defenseMultiplier > 1.0f) message += " (Defense Down hurt!)";

            if (this.IsDefeated())
            {
                message += " and has been defeated!";
            }
            else
            {
                message += $", {this.Health}/{this.MaxHealth} HP remaining.";
            }
            return message;
        }

        public string ExecuteChosenAttack(ClassroomChampion opponent, AttackMove chosenMove)
        {
            if (chosenMove == null || chosenMove.ExecuteAction == null)
            {
                return $"{this.Name} is hesitating and does nothing...";
            }

            int effectiveAccuracy = chosenMove.Accuracy;
            if (this.ActiveStatusEffects.ContainsKey(StatusEffect.AccuracyDown)) effectiveAccuracy -= 20;
            if (opponent.ActiveStatusEffects.ContainsKey(StatusEffect.EvasionUp)) effectiveAccuracy -= 20;
            effectiveAccuracy = Math.Max(10, Math.Min(100, effectiveAccuracy));

            if (random.Next(1, 101) > effectiveAccuracy)
            {
                return $"{this.Name} uses {chosenMove.Name}, but it misses!";
            }

            Tuple<int, string> attackResult = chosenMove.ExecuteAction(this, opponent);
            int baseDamageFromMove = attackResult.Item1;
            string attackNarrative = attackResult.Item2;

            float attackStatMultiplier = 1.0f;
            if (ActiveStatusEffects.ContainsKey(StatusEffect.AttackUp)) attackStatMultiplier += 0.5f;
            if (ActiveStatusEffects.ContainsKey(StatusEffect.AttackDown)) attackStatMultiplier -= 0.33f;

            int damageToDeal = (int)(baseDamageFromMove * attackStatMultiplier);
            if (baseDamageFromMove > 0 && damageToDeal <= 0) damageToDeal = 1; // Ensure damaging moves deal at least 1 after stat mods
            else if (baseDamageFromMove == 0) damageToDeal = 0; // Status moves deal no damage unless their action says so

            string damageTakenMessage = "";
            if (damageToDeal > 0)
            {
                damageTakenMessage = opponent.TakeDamage(damageToDeal);
            }
            else
            {
                // If no damage from this part, the narrative from ExecuteAction usually covers the effect.
                // We might still want a generic "affected by the move" if narrative is sparse.
                if (!string.IsNullOrEmpty(attackNarrative) && !attackNarrative.ToLower().Contains(opponent.Name.ToLower()))
                {
                    // If the narrative doesn't explicitly mention the opponent, add a generic confirmation.
                    damageTakenMessage = $"{opponent.Name} is affected by {chosenMove.Name}!";
                }
                else if (string.IsNullOrEmpty(attackNarrative))
                {
                    damageTakenMessage = $"{opponent.Name} is affected by {chosenMove.Name}!";
                }
            }

            string finalNarrative = attackNarrative;
            if (damageToDeal > 0)
            {
                finalNarrative += $"\n{this.Name} deals {damageToDeal} damage.";
            }
            finalNarrative += $"\n{damageTakenMessage}";

            return finalNarrative.Trim();
        }

        public bool IsDefeated() => this.Health <= 0; // Health setter handles clamping
        public override string ToString() => Name;
    }
}