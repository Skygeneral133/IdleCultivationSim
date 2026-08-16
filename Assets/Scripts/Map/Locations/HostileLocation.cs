using System.Collections.Generic;
using Monsters;
using UnityEngine;

namespace Map
{
    public class HostileLocation
    {
        public Dictionary<Monster, float> MonsterList;
        public Monster defaultMonster;

        public Monster getRandomEnemy()
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
                return successList[Random.Range(0, successList.Count)];
            }
            return  defaultMonster;
        }
    }
}