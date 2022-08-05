using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
public class Statbar : MonoBehaviour
{
    // Start is called before the first frame update
    public TurnOrdererScript turnOrder;
    public PlayerScript Player1;
    public PlayerScript Player2;
    public TextMeshProUGUI[] allTMPS;
    public Image[] allImages;
    public bool isInScene = false;
    void Start()
    {
        allTMPS = GetComponentsInChildren<TextMeshProUGUI>();
        allImages = GetComponentsInChildren<Image>();
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
                        else if (text.gameObject.name == "Upgrade1name" && Player1.selectedUnit.upgrade1 != null)
                        {
                            text.text = Player1.selectedUnit.upgrade1.name;
                        }
                        else if (text.gameObject.name == "Upgrade2name" && Player1.selectedUnit.upgrade2 != null)
                        {
                            text.text = Player1.selectedUnit.upgrade2.name;
                        }
                        else if (text.gameObject.name == "Upgrade1text" && Player1.selectedUnit.upgrade1 != null)
                        {
                            text.text = Player1.selectedUnit.upgrade1.description;
                        }
                        else if (text.gameObject.name == "Upgrade2text" && Player1.selectedUnit.upgrade2 != null)
                        {
                            text.text = Player1.selectedUnit.upgrade2.description;
                        }

                    }
                    foreach (Image image in allImages)
                    {

                        if (image.gameObject.name == "Upgrade1Icon" && Player1.selectedUnit.upgrade1 != null)
                        {
                            image.sprite = Player1.selectedUnit.upgrade1.icon;
                        }
                        else if (image.gameObject.name == "Upgrade2Icon" && Player1.selectedUnit.upgrade2 != null)
                        {
                            image.sprite = Player1.selectedUnit.upgrade2.icon;
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
                        if (text.gameObject.name == "HealthValue")
                        {
                            text.text = Player2.selectedUnit.hp.ToString() + "/" + Player2.selectedUnit.maxHP.ToString();
                        }
                        else if (text.gameObject.name == "SpeedValue")
                        {
                            text.text = Player2.selectedUnit.speed.ToString();
                        }
                        else if (text.gameObject.name == "AttackValue")
                        {
                            text.text = Player2.selectedUnit.damage.ToString();
                        }
                        else if (text.gameObject.name == "RangeValue")
                        {
                            text.text = Player2.selectedUnit.range.ToString();
                        }
                        else if (text.gameObject.name == "UnitName")
                        {
                            if(Player2.selectedUnit.team == 1)
                                text.text = "Enemy's " + Player2.selectedUnit.charClass;
                            else if (Player2.selectedUnit.team == 2)
                                text.text = "Your " + Player2.selectedUnit.charClass;
                        }
                        else if (text.gameObject.name == "Upgrade1name" && Player2.selectedUnit.upgrade1 != null)
                        {
                            text.text = Player2.selectedUnit.upgrade1.name;
                        }
                        else if (text.gameObject.name == "Upgrade2name" && Player2.selectedUnit.upgrade2 != null)
                        {
                            text.text = Player2.selectedUnit.upgrade2.name;
                        }
                        else if (text.gameObject.name == "Upgrade1text" && Player2.selectedUnit.upgrade1 != null)
                        {
                            text.text = Player2.selectedUnit.upgrade1.description;
                        }
                        else if (text.gameObject.name == "Upgrade2text" && Player2.selectedUnit.upgrade2 != null)
                        {
                            text.text = Player2.selectedUnit.upgrade2.description;
                        }

                    }
                    foreach (Image image in allImages)
                    {

                        if (image.gameObject.name == "Upgrade1Icon" && Player2.selectedUnit.upgrade1 != null)
                        {
                            image.sprite = Player2.selectedUnit.upgrade1.icon;
                        }
                        else if (image.gameObject.name == "Upgrade2Icon" && Player2.selectedUnit.upgrade2 != null)
                        {
                            image.sprite = Player2.selectedUnit.upgrade2.icon;
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
        if (!isInScene)
            GetComponent<RectTransform>().anchoredPosition = new Vector2( 200f, GetComponent<RectTransform>().anchoredPosition.y);

        isInScene = true;
    }

    void SlideOut()
    {
        if(isInScene)
            GetComponent<RectTransform>().anchoredPosition = new Vector2(-200f, GetComponent<RectTransform>().anchoredPosition.y);
        isInScene = false;
    }


}
