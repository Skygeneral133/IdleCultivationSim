using Battle;
using Monsters;

namespace Player
{
    public class PlayerRuntimeCombatant : Runtime_Combatant
    {
        public PlayerStats PlayerStats;
        
        public PlayerRuntimeCombatant(PlayerStats stats) : base(stats.currentHp)
        {
            this.PlayerStats = stats;
            this.CurrentHealth = PlayerStats.maxHp;
            this.Attack = PlayerStats.attack;
            this.Defense = PlayerStats.defense;
            this.AttackSpeed = PlayerStats.speed;
        }
        
        public void addHp()
        {
            if (CurrentHealth < PlayerStats.maxHp) CurrentHealth += PlayerStats.hpRegen;
        }

        public void reset()
        {
            this.MaxHealth = PlayerStats.maxHp;
            this.Attack = PlayerStats.attack;
            this.Defense = PlayerStats.defense;
            this.AttackSpeed = PlayerStats.speed;
        }
    }
}