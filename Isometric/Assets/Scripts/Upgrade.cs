using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public string description;
    public Sprite icon;

    public int damageMod;
    public int rangeMod;
    public int moveMod;
    public int aoeMod;
    public int maxHPMod;

    public bool heal;
    public bool hitsSelf;
    //public bool burn;
    //public bool applyToAdjOnDrop;
    //public bool lastStand;
    public bool flight;

    public void ApplyUpgrade(UnitScript unit)
    {

        if (Mathf.Abs(unit.damage) < unit.damage)
        {
            unit.damage -= damageMod;
        }
        else
        {
            unit.damage += damageMod;
        }
        unit.range += rangeMod;
        unit.speed += moveMod;
        unit.aoeRadius += aoeMod;
        unit.maxHP += maxHPMod;
        unit.hp += maxHPMod;
        unit.hitsSelf = true;
        
        if (flight)
        {
           
            unit.flight = true;
            unit.jetParticles.SetActive(true);
            
        }
        if (heal)
        {
            if(Mathf.Abs(unit.damage) < unit.damage)
            {
                unit.damage += 1;
            }
            else
            {
                unit.damage = -unit.damage;
                unit.hitsSelf = true;
            }
    
        }

    }
}
