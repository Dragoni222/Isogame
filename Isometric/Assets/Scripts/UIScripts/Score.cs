using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Score : MonoBehaviour
{
    public TurnOrdererScript turnOrder;
    public TextMeshProUGUI[] allTMPS;

    void Start()
    {
        allTMPS = GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        foreach (TextMeshProUGUI text in allTMPS)
        {
            if (text.gameObject.name == "P1Score")
            {
                text.text = turnOrder.player1Score.ToString();
            }
            else if (text.gameObject.name == "P2Score")
            {

                text.text = turnOrder.player2Score.ToString();

            }
               


        }


        
       

    }





}
