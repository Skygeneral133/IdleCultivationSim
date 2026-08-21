
using Battle;
using Map;

using UnityEngine;
using Player;
using Random = UnityEngine.Random;

public class BattleInstance : MonoBehaviour
{
    private const float BattleHit = 100f;
    private MonsterRuntimeCombatant _enemy;
    private float _enemyHitProgress;
    private PlayerRuntimeCombatant _player;
    private float _playerHitProgress;
    public HostileLocation location;
    public BattleUIScript BattleUI;

    private bool _isBattle = false;

    public void Start()
    {
        Ticker.OnTick += delegate { BattleTick(); };
        _player = new PlayerRuntimeCombatant(FindAnyObjectByType<PlayerStats>());
        InitBatle();
    }
    

    public void BattleTick()
    {
        _player.addHp();
        if (_isBattle)
        {
            _enemyHitProgress += _enemy.AttackSpeed;
            _playerHitProgress += _player.AttackSpeed;

            if (_playerHitProgress > BattleHit) TriggerAttack(_player, _enemy, ref _playerHitProgress);
            if (_enemy.CurrentHealth <= 0) TriggerBattleEnd(true);
            if (_enemyHitProgress > BattleHit) TriggerAttack(_enemy, _player, ref _enemyHitProgress);
            if (_player.CurrentHealth <= 0) TriggerBattleEnd(false);
        }
        else if (!_isBattle && _player.CurrentHealth >= _player.MaxHealth)
        {
            _isBattle = true;
        }
        UpdateUI();
    }

    public void TriggerAttack(Runtime_Combatant guyAttacking, Runtime_Combatant guyDefending, ref float whatToReset)
    {
        float damage = guyAttacking.Attack - guyDefending.Defense;
        if (damage > 0) guyDefending.CurrentHealth -= damage;
        whatToReset = 0;
    }

    public void TriggerBattleEnd(bool didPlayerWin)
    {
        if (didPlayerWin)
        {
            Debug.Log("Player wins!");
            foreach (var drop in _enemy.baseData.DropList)
            {
                var num = Random.Range(0, 100);
                if (num <= drop.chance)
                {
                    _player.PlayerStats.inventory.items.Add(drop.item);
                    Debug.Log($"Player got {drop.item.itemName}");
                }
            }
            InitBatle();
        }
        else
        {
            _isBattle = false;
        }
    }
    

    public void InitBatle()
    {
        if (location is not null)
        {
            _enemy = location.GetRandomEnemy();
            _player.reset();
            BattleUI.MonsterImage.sprite = _enemy.baseData.sprite;
            BattleUI.MonsterName.text = _enemy.baseData.Name;
            BattleUI.MonsterHealthBar.maximum = _enemy.MaxHealth;
            BattleUI.PlayerHealthBar.maximum = _player.MaxHealth;
            BattleUI.MonsterHealthBar.current = _enemy.CurrentHealth;
            BattleUI.PlayerHealthBar.current = _player.CurrentHealth;
            BattleUI.MonsterHealthBar.GetCurrentFill();
            BattleUI.PlayerHealthBar.GetCurrentFill();
            BattleUI.MonsterHealthBar.maximum = _enemy.MaxHealth;
            BattleUI.PlayerHealthBar.maximum = _player.MaxHealth;
            BattleUI.MonsterProgressBar.current = 0;
            BattleUI.PlayerProgressBar.current = 0;
            BattleUI.MonsterProgressBar.GetCurrentFill();
            BattleUI.PlayerProgressBar.GetCurrentFill();
            _isBattle = true;
        }
    }

    public void UpdateUI()
    {
        BattleUI.MonsterHealthBar.current = _enemy.CurrentHealth;
        BattleUI.PlayerHealthBar.current = _player.CurrentHealth;
        BattleUI.MonsterHealthBar.GetCurrentFill();
        BattleUI.PlayerHealthBar.GetCurrentFill();
        BattleUI.MonsterProgressBar.current = _enemyHitProgress;
        BattleUI.PlayerProgressBar.current = _playerHitProgress;
        BattleUI.MonsterProgressBar.GetCurrentFill();
        BattleUI.PlayerProgressBar.GetCurrentFill();
    }
}