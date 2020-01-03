using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int currentDamage;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //currentDamage = damageToGive - thePS.currentDefence - thePS.tempDefence;
            currentDamage = damageToGive - theCS.defence;
            if (currentDamage < 0)
            {
                currentDamage = 1;
            }

            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
        }
    }
}
