using Monsters;

namespace Player
{
    public class PlayerBattleEntity : Monster
    {
        public PlayerStats Stats;
        public Player Player;

        public PlayerBattleEntity(PlayerStats stats) : base(stats.currentHp, stats.attack, stats.defense, stats.speed)
        {
        }

        public void reset()
        {
            var currentHpTemp = Stats.currentHp;
            Stats = new PlayerStats();
            Stats.currentHp = currentHpTemp;
        }
    }
}