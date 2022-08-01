using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    // Start is called before the first frame update
    public float deathTimerMax;
    float deathTimer;
    void Start()
    {
        deathTimer = deathTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;
        if(deathTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
