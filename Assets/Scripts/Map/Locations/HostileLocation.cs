using System.Collections.Generic;
using Battle;
using Monsters;
using UnityEngine;

namespace Map
{
    [CreateAssetMenu(fileName = "NewMonster", menuName = "Game/Location/Hostile")]
    public class HostileLocation : Location
    {
        public Dictionary<Monster, float> MonsterList = new  Dictionary<Monster, float>();
        public Monster defaultMonster;
        public List<Monster>  InitialMonsterList;
        //between 0 and 100
        public List<float> InitialChanceList;

        public void Awake()
        {
            
            for (int i = 0; i < InitialChanceList.Count; i++)
            {
                MonsterList.Add(InitialMonsterList[i], InitialChanceList[i]);
            }
            Debug.Log(MonsterList.Count);
        }
        
        public MonsterRuntimeCombatant GetRandomEnemy()
        {
            var randomNum =  Random.Range(1f, 100f);
            List<Monster> successList = new List<Monster>();
            foreach (var kvp in MonsterList)
            {
                if (randomNum <= kvp.Value)
                {
                    successList.Add(kvp.Key);
                }
            }

            if (successList.Count > 0)
            {
                return MakeMonsterRuntimeCombatant(successList[Random.Range(0, successList.Count)]);
            }
            return MakeMonsterRuntimeCombatant(defaultMonster);
        }

        private MonsterRuntimeCombatant MakeMonsterRuntimeCombatant(Monster monster)
        {
            return new MonsterRuntimeCombatant(monster);
        }
        
    }
}