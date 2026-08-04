using UnityEngine;

namespace Monsters
{
    public class Monster : ScriptableObject
    {
        public float maxHp;
        public float currentHp;
        public float attack;
        public float defense;
        public float attackSpeed;

        public Monster(float maxHp, float attack, float defense, float attackSpeed)
        {
            this.maxHp = maxHp;
            currentHp = maxHp;
            this.attack = attack;
            this.defense = defense;
            this.attackSpeed = attackSpeed;
        }
    }
}