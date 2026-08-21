using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Monsters
{
    [CreateAssetMenu(fileName = "NewMonster", menuName = "Game/Monster")]
    public class Monster : ScriptableObject
    {
        public string Name;
        public float maxHp;
        public float attack;
        public float defense;
        public float attackSpeed;
        public Sprite sprite;
        public List<DropEntry> DropList;
    }
}