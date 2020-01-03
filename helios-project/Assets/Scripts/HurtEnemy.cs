﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;

    public GameObject DamageBurst;
    public GameObject DamageNumbers;

    //private PlayerStats thePS;
    private CharStats theCS;

    // Start is called before the first frame update
    void Start()
    {
        //thePS = FindObjectOfType<PlayerStats>();
        theCS = FindObjectOfType<CharStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + theCS.wpnPwr;

            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);

            Instantiate(DamageBurst, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            var clone = (GameObject) Instantiate(DamageNumbers, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
        
    }
}
