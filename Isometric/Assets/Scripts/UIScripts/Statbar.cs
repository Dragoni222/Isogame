using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Statbar : MonoBehaviour
{
    // Start is called before the first frame update
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
        if(turnOrder.attackPhase == true)
        {
            if (Player1.myTurn)
            {
                if(Player1.selectedUnit != null)
                {
                 
                    foreach (TextMeshProUGUI text in allTMPS)
                    {
                       
                        if (text.gameObject.name == "HealthValue")
                        {
                            text.text = Player1.selectedUnit.hp.ToString() + "/" + Player1.selectedUnit.maxHP.ToString();
                        }
                        else if (text.gameObject.name == "SpeedValue")
                        {
                            text.text = Player1.selectedUnit.speed.ToString();
                        }
                        else if (text.gameObject.name == "AttackValue")
                        {
                            text.text = Player1.selectedUnit.damage.ToString();
                        }
                        else if (text.gameObject.name == "RangeValue")
                        {
                            text.text = Player1.selectedUnit.range.ToString();
                        }
                        else if (text.gameObject.name == "UnitName")
                        {
                            if (Player1.selectedUnit.team == 2)
                                text.text = "Enemy's " + Player1.selectedUnit.charClass;
                            if (Player1.selectedUnit.team == 1)
                                text.text = "Your " + Player1.selectedUnit.charClass;
                        }
                        
                    }
                    SlideIn();
                }
                else
                {
                    SlideOut();
                }
            }
            else if (Player2.myTurn)
            {
                if (Player2.selectedUnit != null)
                {
                    foreach (TextMeshProUGUI text in allTMPS)
                    {
                        Debug.Log(text.gameObject.name);
                        if (text.gameObject.name == "HealthValue")
                        {
                            text.text = Player1.selectedUnit.hp.ToString() + "/" + Player1.selectedUnit.maxHP.ToString();
                        }
                        else if (text.gameObject.name == "SpeedValue")
                        {
                            text.text = Player1.selectedUnit.speed.ToString();
                        }
                        else if (text.gameObject.name == "AttackValue")
                        {
                            text.text = Player1.selectedUnit.damage.ToString();
                        }
                        else if (text.gameObject.name == "RangeValue")
                        {
                            text.text = Player1.selectedUnit.range.ToString();
                        }
                        else if (text.gameObject.name == "UnitName")
                        {
                            if(Player1.selectedUnit.team == 1)
                                text.text = "Enemy's " + Player1.selectedUnit.charClass;
                            if (Player1.selectedUnit.team == 2)
                                text.text = "Your " + Player1.selectedUnit.charClass;
                        }
                        
                    }
                    SlideIn();
                }
                else
                {
                    SlideOut();
                }
            }
            else
            {
                SlideOut();
            }
        }
        else
        {
            SlideOut();
        }
    }




    void SlideIn()
    {
        if(!isInScene)
            GetComponent<RectTransform>().DOMoveX(208.8f, 0.1f);
       
        isInScene = true;
    }

    void SlideOut()
    {
        if(isInScene)
            GetComponent<RectTransform>().DOMoveX(-300, 0.1f);
        isInScene = false;
    }


}
