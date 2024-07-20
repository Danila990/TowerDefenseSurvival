using System;
using UnityEngine;

public enum UpgradeWaveType 
{
    DamagePercent,
    HealthPercent,
    Armor,
    EnemyCount,
}

[Serializable]
public struct UpgradeWave
{
    [field: SerializeField] public UpgradeItem[] UpgradeItem {  get; private set; }
    [field: SerializeField] public int UpdateDelay { get; private set; }
}

[Serializable]
public struct UpgradeItem
{
    [field: SerializeField] public UpgradeWaveType UpgradeType { get; private set; }
    [field: SerializeField] public int Count { get; private set; }
}