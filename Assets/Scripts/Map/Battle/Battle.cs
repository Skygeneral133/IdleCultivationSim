using Monsters;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private const float BattleHit = 100f;
    private Monster _enemy;
    private float _enemyHitProgress;
    private Monster _player;
    private float _playerHitProgress;

    public Battle()
    {
        Ticker.OnTick += delegate { BattleTick(); };
    }

    public void BattleTick()
    {
        _enemyHitProgress += _enemy.attackSpeed;
        _playerHitProgress += _player.attackSpeed;

        if (_playerHitProgress > BattleHit) TriggerAttack(_player, _enemy);
        if (_enemy.currentHp <= 0) TriggerBattleEnd(true);
        if (_enemyHitProgress > BattleHit) TriggerAttack(_enemy, _player);
        if (_player.currentHp <= 0) TriggerBattleEnd(false);
    }

    public void TriggerAttack(Monster guyAttacking, Monster guyDefending)
    {
        float damage = guyAttacking.attack - guyDefending.defense;
        if (damage > 0) guyDefending.currentHp -= damage;
    }

    public void TriggerBattleEnd(bool didPlayerWin)
    {
    }
}