using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TurretData
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpgradedPrefab;
    public int upgradeCost;

    public TurretType type;
}

public enum TurretType
{
    StandardTurre,
    MissileTurret,
    LaserTurre
}
