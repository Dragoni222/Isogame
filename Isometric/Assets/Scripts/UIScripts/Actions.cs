using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Actions : MonoBehaviour
{
    public TurnOrdererScript turnOrder;
    public PlayerScript Player1;
    public PlayerScript Player2;
    public TextMeshProUGUI[] allTMPS;
    public bool isInScene = false;
    void Start()
    {
        allTMPS = GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnOrder.attackPhase)
        {
            SlideIn();
            if (Player1.myTurn)
            {
                foreach (TextMeshProUGUI text in allTMPS)
                {
                    if (text.gameObject.name == "P1/P2Actions")
                    {
                        text.text = "Player 1 (Orange)";
                    }
                    else if (text.gameObject.name == "Move")
                    {

                        text.text = "Move";
                        if (turnOrder.hasMoved)
                            text.color = new Color(255,0,0);
                        else
                            text.color = new Color(0, 255, 0);
                    }
                    else if (text.gameObject.name == "Attack or Extra Move")
                    {
                        text.text = "Attack or Extra Move";
                        if (turnOrder.hasAttacked)
                            text.color = new Color(255, 0, 0);
                        else
                            text.color = new Color(0, 255, 0);
                    }


                }
            }
            if (Player2.myTurn)
            {
                foreach (TextMeshProUGUI text in allTMPS)
                {

                    if (text.gameObject.name == "P1/P2Actions")
                    {
                        text.text = "Player 2 (Green)";
                    }
                    else if (text.gameObject.name == "Move")
                    {
                        text.text = "Move";
                        if (turnOrder.hasMoved)
                            text.color = new Color(255, 0, 0);
                        else
                            text.color = new Color(0, 255, 0);
                    }
                    else if (text.gameObject.name == "Attack or Extra Move")
                    {
                        text.text = "Attack or Extra Move";
                        if (turnOrder.hasAttacked)
                            text.color = new Color(255, 0, 0);
                        else
                            text.color = new Color(0, 255, 0);
                    }


                }
            }


        }
        else if (turnOrder.spawnPhase)
        {
            SlideIn();
            if (Player1.myTurn)
            {
                foreach (TextMeshProUGUI text in allTMPS)
                {

                    if (text.gameObject.name == "P1/P2Actions")
                    {
                        text.text = "Player 1 (Orange)";
                    }
                    else if (text.gameObject.name == "Move")
                    {
                        text.text = "Place Unit";
                        if (turnOrder.hasPlaced)
                            text.color = new Color(255, 0, 0);
                        else
                            text.color = new Color(0, 255, 0);
                    }
                    else if (text.gameObject.name == "Attack or Extra Move")
                    {
                        text.text = "";

                    }


                }
            }
            if (Player2.myTurn)
            {
                foreach (TextMeshProUGUI text in allTMPS)
                {

                    if (text.gameObject.name == "P1/P2Actions")
                    {
                        text.text = "Player 2 (Green)";
                    }
                    else if (text.gameObject.name == "Move")
                    {
                        text.text = "Place Unit";
                        if (turnOrder.hasPlaced)
                            text.color = new Color(255, 0, 0);
                        else
                            text.color = new Color(0, 255, 0);
                    }
                    else if (text.gameObject.name == "Attack or Extra Move")
                    {
                        text.text = "";

                    }


                }
            }
        }
        else
        {
            SlideOut();
        }
    }

    void SlideIn()
    {
        if (!isInScene)
            GetComponent<RectTransform>().DOMoveX(1712f, 0.1f);

        isInScene = true;
    }

    void SlideOut()
    {
        if (isInScene)
            GetComponent<RectTransform>().DOMoveX(2300, 0.1f);
        isInScene = false;
    }



}
