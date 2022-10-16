using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 finalPos;
    public Ease smoothMoveProjectile;
    public Ease smoothMoveLob;
    public List<CellScript> affectedCells;
    UnitScript unit;
    public Rigidbody rb;
    public float speed;
    public float upForce;
    GameObject missileExplosion;
    public GameObject missileExplosion1;
    public GameObject missileExplosion2;
    public GameObject missileExplosion3;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= 4 && unit.lob)
        {
            ProjectileHit();
        }
    }

    private void ProjectileHit()
    {
        Instantiate(missileExplosion, transform.position, Quaternion.identity);
        foreach (CellScript cell in affectedCells)
        {
            if (cell.occupiedBy != null)
            {
                if (unit.hitsSelf)
                {
                    cell.occupiedBy.GetComponent<UnitScript>().hp -= unit.damage;
                }
                else if (cell.occupiedBy.GetComponent<UnitScript>().team != unit.team)
                {
                    cell.occupiedBy.GetComponent<UnitScript>().hp -= unit.damage;
                }


            }
        }
        DOTween.Clear();
        Destroy(gameObject);
        
    }

    public void SetSpawnValues(Vector3 FinalPos,List<CellScript> AffectedCells, UnitScript Unit)
    {
        finalPos = new Vector3(UnitScript.BoardToRealPos((int)FinalPos.x), 5, UnitScript.BoardToRealPos((int)FinalPos.y));
       
        affectedCells = AffectedCells;
        unit = Unit;
        Shoot();
    }

    private void Shoot()
    {
        if (unit.aoeRadius == 0)
            missileExplosion = missileExplosion1;
        if (unit.aoeRadius == 1)
            missileExplosion = missileExplosion2;
        if (unit.aoeRadius == 2)
            missileExplosion = missileExplosion3;

        if (unit.lob)
        {
            if (unit.flight)
            {
                rb.useGravity = true;
                rb.AddForce(new Vector3(finalPos.x - transform.position.x, 0, finalPos.z - transform.position.z) * 25);
                rb.AddForce(new Vector3(0, upForce, 0));
            }
            else
            {
                rb.useGravity = true;
                rb.AddForce(new Vector3(finalPos.x - transform.position.x, 0, finalPos.z - transform.position.z) * 30);
                rb.AddForce(new Vector3(0, upForce, 0));
            }
            


        }
        else
        {
            transform.DOMove(finalPos, 1).OnComplete(() => { ProjectileHit(); }).SetEase(smoothMoveProjectile);
        }
        
    
    }

    private void OnTriggerEnter(Collider other)
        
    {
        
        if(other.gameObject.tag == "Unit" || other.gameObject.tag == "Blocker")
        {
            finalPos = other.GetComponent<UnitScript>().boardPosition;
            affectedCells = PlayerScript.AllCellsInRadius(unit.board, (int)finalPos.x, (int)finalPos.y, unit.aoeRadius, true);
            
            ProjectileHit();
        }
       
    }
}
