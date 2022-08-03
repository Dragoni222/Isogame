using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public string description;

    public int damageMod;
    public int rangeMod;
    public int moveMod;
    public int aoeMod;
    public int maxHPMod;

    public bool heal;
    public bool burn;
    public bool applyToAdjOnDrop;
    public bool lastStand;


    public void ApplyUpgrade(UnitScript unit)
    {
        unit.damage += damageMod;
        unit.range += rangeMod;
        unit.speed += moveMod;
        unit.aoeRadius += aoeMod;
        unit.maxHP += maxHPMod;
        unit.hp += maxHPMod;

        if (heal)
        {
            unit.damage = -unit.damage;
        }

    }
}
