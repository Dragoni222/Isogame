using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 boardPos;
    public bool highlightedAttack;
    bool renderHighlightedAttack;
    public bool highlightedMove;
    bool renderHighlightedMove;
    public bool highlightedHover;
    bool renderHighlightedHover;
    public bool highlightedRange;
    bool renderHighlightedRange;
    public GameObject occupiedBy;
    private BoardScript board;

    private void Start()
    {
        highlightedAttack = false;
        renderHighlightedAttack = true;
        highlightedMove = false;
        renderHighlightedMove = true;
        highlightedHover = false;
        renderHighlightedHover = true;
        highlightedRange = false;
        renderHighlightedRange = true;
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (highlightedAttack && !renderHighlightedAttack)
        {
            foreach(MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if(rendr.gameObject.tag == "highlightAttack")
                    rendr.enabled = true;
                
            }
            renderHighlightedAttack = true;
        }
        else if (!highlightedAttack && renderHighlightedAttack)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlightAttack")
                    rendr.enabled = false;

            }
            renderHighlightedAttack = false;
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
        if (highlightedHover && !renderHighlightedHover)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlightHover")
                    rendr.enabled = true;

            }
            renderHighlightedHover = true;
        }
        else if (!highlightedHover && renderHighlightedHover)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlightHover")
                    rendr.enabled = false;

            }
            renderHighlightedHover = false;
        }
        if (highlightedRange && !renderHighlightedRange)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlightRange")
                    rendr.enabled = true;

            }
            renderHighlightedRange = true;
        }
        else if (!highlightedRange && renderHighlightedRange)
        {
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "highlightRange")
                    rendr.enabled = false;

            }
            renderHighlightedRange = false;
        }
    }

    public void SetValues(Vector2 BoardPos,  GameObject OccupiedBy)
    {
        boardPos = BoardPos;
        occupiedBy = OccupiedBy;
    }

    

}
