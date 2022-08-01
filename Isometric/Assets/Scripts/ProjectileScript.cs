using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 finalPos;
    public bool lob;
    public GameObject kaboom;
    public bool slash;
    bool shoot = false; 
    public Ease smoothMoveProjectile;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            transform.DOMove(finalPos, 1).OnComplete(() => { ProjectileHit(); }).SetEase(smoothMoveProjectile);
            shoot = false;
        }
    }

    private void ProjectileHit()
    {

        Destroy(gameObject);
        
    }

    public void SetSpawnValues(Vector3 FinalPos, bool Lob, GameObject Kaboom, bool SlashEffect)
    {
        finalPos = new Vector3(UnitScript.BoardToRealPos((int)FinalPos.x), 5, UnitScript.BoardToRealPos((int)FinalPos.y));
        lob = Lob;
        kaboom = Kaboom;
        slash = SlashEffect;
        shoot = true;
    }
}
