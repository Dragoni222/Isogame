using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject selectedObject;
    public GameObject selectWallsPrefab;

    void Update()
    {

        //On click, find an object that the ray from the camera hits. If on the board, highlight tile. 
        if (Input.GetButtonDown("click"))
        {
            if(selectedObject != null)
                selectedObject.GetComponent<CellScript>().highlighted = false;
            selectedObject = ClickSelect(Camera.main, 0);
            if (selectedObject != null)
            {
                selectedObject.GetComponent<CellScript>().highlighted = true;
            }
        }

    }
    //returns Vector2 of board pos
    
    public GameObject ClickSelect(Camera mainCam, int layer)
    {
        int layerMask = 1 << layer;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 500, layerMask))
        {
            Debug.Log(hit.transform.position.x + " " + hit.transform.position.z);
            return hit.transform.gameObject;
        }
        Debug.Log("hitnothing");
        return null;
      

    }
    
}
