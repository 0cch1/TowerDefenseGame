using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }

    public TurretData standardTurreData;
    public TurretData missileTurretData;
    public TurretData laserTurretData;

    public TurretData selectedTurretData;

    private void Awake()
    {
        Instance = this;
    }
    public void OnStandardSeleced(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurreData;
        }
    } 
    public void OnMissileSeleced(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    } 
    public void OnLaserSeleced(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }

}
