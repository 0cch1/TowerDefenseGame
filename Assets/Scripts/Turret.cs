using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    public float attackRate = 1f;
    private float nextAttactTime; // Time.time

    private Transform head;

    protected virtual void Start()
    {
        head = transform.Find("Head");
    }
    private void Update()
    {
        DirectionControl();
        Attack();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }

    protected virtual void Attack()
    {
        if (enemies == null || enemies.Count == 0) return;
        //GameObject go = enemies[0];

        if(Time.time> nextAttactTime)
        {
            Transform target = GetTarget();
            if(target != null)
            {
                GameObject go = GameObject.Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);
                go.GetComponent<Bullet>().setTarget(enemies[0].transform);
                nextAttactTime = Time.time + attackRate;

            }
        }
    }

    public Transform GetTarget()
    {
        if(enemies != null && enemies.Count > 0 && enemies[0]!= null)
        {
            return enemies[0].transform;
        }

        if(enemies == null || enemies.Count == 0) return null;

        List<int> indexList = new List<int>();
        for(int i=0; i<enemies.Count; i++)
        {
            if (enemies[i] == null || enemies[i].Equals(null))
            {
                indexList.Add(i);
            }
        }
        for(int i=indexList.Count-1; i>=0; i--)
        {
            enemies.RemoveAt(indexList[i]);
        }

        if(enemies!=null && enemies.Count != 0)
        {
            return enemies[0].transform;
        }
        return null;
    }

    private void DirectionControl()
    {
        Transform target = GetTarget();
        if (target == null) return;

        Vector3 targetPos = target.position;
        targetPos.y = head.position.y;

        head.LookAt(targetPos);
    }
}
