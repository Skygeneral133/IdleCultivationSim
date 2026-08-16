using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Monsters
{
    public class Monster : ScriptableObject
    {
        public float maxHp;
        public float currentHp;
        public float attack;
        public float defense;
        public float attackSpeed;
        public Sprite sprite;
        public Dictionary<Item,float> DropList;

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