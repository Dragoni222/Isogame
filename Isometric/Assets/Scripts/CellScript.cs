using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 boardPos;
    public bool highlighted;
    bool renderHighlighted;
    public GameObject occupiedBy;
    // Update is called once per frame
    void Update()
    {
        if (highlighted && !renderHighlighted)
        {
            foreach(MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                rendr.enabled = true;
                
            }
            renderHighlighted = true;
        }
        else if (!highlighted && renderHighlighted)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                rendr.enabled = false;
                
            }
            renderHighlighted = false;
        }
    }

    public void SetValues(Vector2 BoardPos, bool Highlighted, GameObject OccupiedBy)
    {
        boardPos = BoardPos;
        highlighted = Highlighted;
        renderHighlighted = !Highlighted;
        occupiedBy = OccupiedBy;
    }

}
