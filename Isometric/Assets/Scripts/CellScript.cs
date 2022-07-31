using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 boardPos;
    public bool highlighted;
    bool renderHighlighted;
    public bool highlightedMove;
    bool renderHighlightedMove;
    public GameObject occupiedBy;


    private void Start()
    {
        highlighted = false;
        renderHighlighted = true;
        highlightedMove = false;
        renderHighlightedMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (highlighted && !renderHighlighted)
        {
            foreach(MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if(rendr.gameObject.tag == "highlight")
                    rendr.enabled = true;
                
            }
            renderHighlighted = true;
        }
        else if (!highlighted && renderHighlighted)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlight")
                    rendr.enabled = false;

            }
            renderHighlighted = false;
        }


        if (highlightedMove && !renderHighlightedMove)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlightMove")
                    rendr.enabled = true;

            }
            renderHighlightedMove = true;
        }
        else if (!highlightedMove && renderHighlightedMove)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlightMove")
                    rendr.enabled = false;

            }
            renderHighlightedMove = false;
        }


    }

    public void SetValues(Vector2 BoardPos,  GameObject OccupiedBy)
    {
        boardPos = BoardPos;
        occupiedBy = OccupiedBy;
    }

    

}
