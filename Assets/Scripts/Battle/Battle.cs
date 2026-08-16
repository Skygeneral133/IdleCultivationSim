using Map;
using Monsters;
using UnityEngine;
using Player;
using TMPro;
using UnityEngine.UI;

public class Battle
{
    private const float BattleHit = 100f;
    private Monster _enemy;
    private float _enemyHitProgress;
    private PlayerBattleEntity _player;
    private float _playerHitProgress;
    public HostileLocation location;
    public Image MonsterImage;
    public TextMeshProUGUI MonsterName;
    private bool _isBattle;

    public Battle()
    {
        Ticker.OnTick += delegate { BattleTick(); };
    }

    public void BattleTick()
    {
        _player.Stats.addHp();
        if (_isBattle)
        {
            _enemyHitProgress += _enemy.attackSpeed;
            _playerHitProgress += _player.attackSpeed;

            if (_playerHitProgress > BattleHit) TriggerAttack(_player, _enemy);
            if (_enemy.currentHp <= 0) TriggerBattleEnd(true);
            if (_enemyHitProgress > BattleHit) TriggerAttack(_enemy, _player);
            if (_player.currentHp <= 0) TriggerBattleEnd(false);
        }
    }

    public void TriggerAttack(Monster guyAttacking, Monster guyDefending)
    {
        float damage = guyAttacking.attack - guyDefending.defense;
        if (damage > 0) guyDefending.currentHp -= damage;
    }

    public void TriggerBattleEnd(bool didPlayerWin)
    {
        if (didPlayerWin)
        {
            foreach (var kvp in _enemy.DropList)
            {
                var num = Random.Range(0, 100);
                if (kvp.Value <= num)
                {
                    _player.Player.Inventory.items.Add(kvp.Key);
                }
            }
        }
        else
        {
            _isBattle = false;
        }
        InitBatle();
    }
    

    public void InitBatle()
    {
        if (location is not null)
        {
            _enemy = location.getRandomEnemy();
            _player.reset();
            MonsterImage.sprite = _enemy.sprite;
            MonsterName.text = _enemy.name;
        }
    }
}