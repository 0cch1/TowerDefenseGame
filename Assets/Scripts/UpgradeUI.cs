using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    private Animator anim;

    public Button upgradeButton;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Show(Vector3 position, bool isDisableUpgrade)
    {
        if(transform.localScale!= Vector3.zero && transform.position == position)
        {
            Hide();
            return;
        }

        upgradeButton.interactable = !isDisableUpgrade;
        transform.position = position;
        anim.SetBool("isShow",true);
    }
    public void Hide()
    {
        anim.SetBool("isShow", false);
    }

    public void OnUpgradeButtonClick()
    {
        BuildManager.Instance.OnTurretUpgrade();
    }

    public void OnDestroyButtonClick()
    {
        BuildManager.Instance.OnTurretDestroy();
    }
}
