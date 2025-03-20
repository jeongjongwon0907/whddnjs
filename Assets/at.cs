using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class at : MonoBehaviour
{
    public int damage = 5;
    private float attackRange = 5f;
    public LayerMask enemyLayer;
    public Camera cam;
    private Ray ray;
    RaycastHit hit;
    
    private float lasttack = 0;
    private float attackCoolTime = 1f;

    private void AttackSystem()
    {
        if (Time.time - lasttack >= attackCoolTime)
        {
            if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
            {
                hp ememyHp = hit.collider.GetComponent<hp>();
                Debug.Log("Attack Enemy");
                ememyHp.Damage(damage);
            }
            lasttack = Time.time;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    AttackSystem();
                }
            }
                
        }    
    }
}


