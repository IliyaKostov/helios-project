using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talent : MonoBehaviour
{
    public Text talentPoints;

    [Header("Talent type")]
    public bool isPassive;
    public bool isActive;

    [Header("Talent Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr, affectDef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpendTalentPoint()
    {
        if (isPassive)
        {
            if (affectHP)
            {
                CharStats.instance.maxHP += amountToChange;
            }

            if (affectMP)
            {
                CharStats.instance.maxMP += amountToChange;
            }

            if (affectStr)
            {
                CharStats.instance.strength += amountToChange;
            }

            if (affectDef)
            {
                CharStats.instance.defence += amountToChange;
            }
        }
    }
}

