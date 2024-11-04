using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4;
    private int pointIndex = 0;

    private Vector3 targetPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = WayPoints.instance.GetWayPoint(pointIndex);
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
            Die();
            return;
        }
        targetPos = WayPoints.instance.GetWayPoint(pointIndex);
    }

    void Die()
    {
        Destroy(gameObject);
        EnemySpawner.Instance.DecreaseEnemyCount();
    }
}
