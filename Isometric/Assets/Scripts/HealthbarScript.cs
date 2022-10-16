using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HealthbarScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int deltaHealth;
    public int maxHealth;
    public List<GameObject> bar;
    public GameObject cellPrefab;
    public UnitScript unit;
    public bool hasAttacked;
    public bool hasMoved;
    public MeshRenderer movedIcon;
    public MeshRenderer attackedIcon;
    void Start()
    {
        
        foreach (HealthCellScript cell in GetComponentsInChildren<HealthCellScript>())
        {
            bar.Add(cell.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localEulerAngles = new Vector3(0,-unit.transform.rotation.eulerAngles.y + 225,180);
        
        if (unit.deltaHealth != deltaHealth || unit.maxHP != maxHealth || unit.hp != health)
        {
            maxHealth = unit.maxHP;
            health = unit.hp;
            deltaHealth = unit.deltaHealth;
            Resetbar(maxHealth, health, deltaHealth);
        }
        hasAttacked = unit.hasAttacked;
        hasMoved = unit.hasMoved;

        if (hasMoved || unit.turnOrder.whosTurn != unit.team)
        {
            movedIcon.enabled = false;
        }
        else
        {
            movedIcon.enabled = true;
        }
        if (hasAttacked || unit.turnOrder.whosTurn != unit.team)
        {
            attackedIcon.enabled = false;
        }
        else if (unit.turnOrder.whosTurn == unit.team)
        {
            attackedIcon.enabled = true;
        }
    }

    public void Resetbar(int maxHealth, int health, int deltaHealth)
    {
        foreach(GameObject go in bar)
        {
            Destroy(go);
        }
        bar.Clear();

        while(bar.Count < maxHealth)
        {
            var newCell = Instantiate(cellPrefab, transform.position + transform.rotation * new Vector3(((maxHealth / 2) - bar.Count) * 2f, 0, 0), transform.rotation * Quaternion.Euler(-45, 0, 0));
            newCell.transform.parent = gameObject.transform;
            bar.Add(newCell);
        }

        for (int i = 0; i < health; i++)
        {
            bar[i].GetComponent<HealthCellScript>().state = 0;
        }
        
        for (int i = health; i < maxHealth; i++)
        {
            bar[i].GetComponent<HealthCellScript>().state = 2;
        }

        for(int i = 0; i != deltaHealth; i += Mathf.Abs(deltaHealth)/deltaHealth)
        {
            if(Mathf.Abs(deltaHealth) / deltaHealth > 0)
                bar[health + i].GetComponent<HealthCellScript>().state = 3;
            else
                bar[health + i - 1].GetComponent<HealthCellScript>().state = 1;
        }
        

    }
}
