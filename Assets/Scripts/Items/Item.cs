using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "NewMonster", menuName = "Game/Item")]
    public class Item : ScriptableObject
    {
        public Sprite sprite;
        public string itemName;
        public int itemID;
        public string itemDescription;
    }
}