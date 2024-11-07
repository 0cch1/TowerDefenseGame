using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 50;
    public float speed = 50;

    public GameObject bulletExplosionEffect;

    private Transform target;


    private void Update()
    {
        if (target == null)
        {
            Dead();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward* speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) < 1.2)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
            Dead();
        }
    }

    public void setTarget(Transform t)
    {
        this.target= t;
    }

    private void Dead()
    {
        Destroy(this.gameObject);
        GameObject go = GameObject.Instantiate(bulletExplosionEffect,transform.position, Quaternion.identity);
        Destroy(go, 1);

        if(target != null)
        {
            go.transform.parent = target.transform;
        }
    }
}
