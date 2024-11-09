using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 4;
    private int pointIndex = 0;

    private Vector3 targetPos = Vector3.zero;

    public float hp = 100;
    private float maxHP = 0;
    public GameObject explosionPrefab;

    private Slider hpSlider;
    
    void Start()
    {
        targetPos = WayPoints.instance.GetWayPoint(pointIndex);
        hpSlider = transform.Find("Canvas/HPSlider").GetComponent<Slider>();
        hpSlider.value = 1;
        maxHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPos - transform.position).normalized * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            MoveNextPoint(); 
           
        }


    }

    private void MoveNextPoint()
    {
        pointIndex++;
        if (pointIndex > WayPoints.instance.GetLength() - 1)
        {
            GameManager.Instance.Fail();
            Die();
            return;
        }
        targetPos = WayPoints.instance.GetWayPoint(pointIndex);
    }

    void Die()
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreaseEnemyCount();
        GameObject go = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(go,1);
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = hp / maxHP;
        if(hp <= 0)
        {
            Die();
        }
    }
}
