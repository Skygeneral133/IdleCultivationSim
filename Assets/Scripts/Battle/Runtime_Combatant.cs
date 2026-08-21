using Monsters;

namespace Battle
{
    public abstract class Runtime_Combatant
    {
        public float Attack;
        public float Defense;
        public float AttackSpeed;
        public float MaxHealth;
        public float CurrentHealth;


        public Runtime_Combatant(float startHp)
        {
            CurrentHealth = startHp;
        }
        
    }
}