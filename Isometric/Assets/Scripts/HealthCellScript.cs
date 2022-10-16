using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCellScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int state;
    public MeshRenderer meshRenderer;
    public Material[] materials;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material = materials[state];
    }
}
