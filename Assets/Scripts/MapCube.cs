using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{

    private GameObject turretGO;
    private TurretData turretData;
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == true) return;

        TurretData selectedTD = BuildManager.Instance.selectedTurretData;
        if (selectedTD == null || selectedTD.turretPrefab == null) return;

        if (turretGO != null) return;

        turretData = selectedTD;
        turretGO = GameObject.Instantiate(selectedTD.turretPrefab, transform.position, Quaternion.identity);
    }
}
