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
    bool shoot = false;
    UnitScript unit;
    Rigidbody rb;
    public float speed;
    public float upForce;
    GameObject missileExplosion;
    public GameObject missileExplosion1;
    public GameObject missileExplosion2;
    public GameObject missileExplosion3;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            if (unit.aoeRadius == 0)
                missileExplosion = missileExplosion1;
            if (unit.aoeRadius == 1)
                missileExplosion = missileExplosion2;
            if (unit.aoeRadius == 2)
                missileExplosion = missileExplosion3;

            if (unit.lob)
            {
                rb.useGravity = true;
                rb.AddForce(new Vector3(finalPos.x - transform.position.x, 0, finalPos.z - transform.position.z) * speed);
                rb.AddForce(new Vector3(0, upForce, 0));
                

            }
            else
            {
                transform.DOMove(finalPos, 1).OnComplete(() => { ProjectileHit(); }).SetEase(smoothMoveProjectile);
            }
            shoot = false;
        }
        if (transform.position.y <= 4)
            ProjectileHit();

    }

    private void ProjectileHit()
    {
        Instantiate(missileExplosion, transform.position, Quaternion.identity);
        foreach (CellScript cell in affectedCells)
        {
            Debug.Log(cell.boardPos.ToString());
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
        Destroy(gameObject);
        
    }

    public void SetSpawnValues(Vector3 FinalPos,List<CellScript> AffectedCells, UnitScript Unit)
    {
        finalPos = new Vector3(UnitScript.BoardToRealPos((int)FinalPos.x), 5, UnitScript.BoardToRealPos((int)FinalPos.y));
       
        affectedCells = AffectedCells;
        unit = Unit;
        shoot = true;
    }
}
