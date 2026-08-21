using System.Buffers.Text;
using Monsters;

namespace Battle
{
    public class MonsterRuntimeCombatant : Runtime_Combatant
    {
        public Monster baseData;
        
        public MonsterRuntimeCombatant(Monster data) : base(data.maxHp)
        {
            baseData = data;
            Attack = data.attack;
            Defense = data.defense;
            AttackSpeed = data.attackSpeed;
            MaxHealth = data.maxHp;
            CurrentHealth = data.maxHp;
        }
    }
}