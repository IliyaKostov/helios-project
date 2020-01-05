using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{ 
    [Header("Spell Type")]
    public bool isDamaging;
    public bool isBuff;

    [Header("Spell Details")]
    public string spellName;
    public string description;
    public int spellLevel = 0;
    public Sprite spellSprite;

    public int damageAmount;
    public int manaCost;
    public float spellRange = 1.2f;
    public float castTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        if (isDamaging)
        {
            gameObject.GetComponent<HurtEnemy>().damageToGive = damageAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
