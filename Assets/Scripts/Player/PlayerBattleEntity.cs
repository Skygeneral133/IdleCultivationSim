using Monsters;

namespace Map.Battle
{
    public class PlayerBattleEntity : Monster
    {
        public PlayerStats Stats;
        public Player.Player Player;

        public PlayerBattleEntity(PlayerStats stats) : base(stats.currentHp, stats.attack, stats.defense, stats.speed)
        {
        }
    }
}