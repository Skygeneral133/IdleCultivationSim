using System;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    public const float TickTimerMax = .2f;
    private int _tick;
    private float _tickTimer;

    private void Awake()
    {
        _tick = 0;
    }

    // ReSharper disable Unity.PerformanceAnalysis 
    private void Update()
    {
        _tickTimer += Time.deltaTime;
        if (_tickTimer >= TickTimerMax)
        {
            _tickTimer -= TickTimerMax;
            _tick++;
            if (OnTick != null) OnTick(this, new OnTickEventArgs { Tick = _tick });
        }
    }

    public static event EventHandler<OnTickEventArgs> OnTick;

    public class OnTickEventArgs : EventArgs
    {
        public int Tick;
    }
}