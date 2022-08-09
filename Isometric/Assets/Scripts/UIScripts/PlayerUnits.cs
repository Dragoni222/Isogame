using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
public class PlayerUnits : MonoBehaviour
{
    // Start is called before the first frame update
    public TurnOrdererScript turnOrder;
    public PlayerScript Player1;
    public PlayerScript Player2;
    public Image[] allTMPS;
    public Sprite transparent;
    public bool isInScene = false;
    [SerializeField] int player;
    void Start()
    {
        allTMPS = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (turnOrder.spawnPhase == true)
        {
            if (Player1.myTurn && player == 1)
            {
                SlideIn();
                foreach (Image image in allTMPS)
                {
                    image.preserveAspect = true;
                    if (image.gameObject.name == "Unit1Spash")
                    {
                        if(Player1.unitsToDrop.Count > 0)
                        {
                            image.sprite = Player1.unitsToDrop[0].splashArt;
                            if (Player1.selectedUnitID == 0)
                            {
                                image.color = new Color(0,255,0);
                            }
                            else
                            {
                                image.color = new Color(255, 255, 255);
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Spash")
                    {
                        if (Player1.unitsToDrop.Count > 1)
                        {
                            image.sprite = Player1.unitsToDrop[1].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 1)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }

                    }
                    else if (image.gameObject.name == "Unit3Spash")
                    {
                        if (Player1.unitsToDrop.Count > 2)
                        {
                            image.sprite = Player1.unitsToDrop[2].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 2)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit4Spash")
                    {
                        if (Player1.unitsToDrop.Count > 3)
                        {
                            image.sprite = Player1.unitsToDrop[3].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 3)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit5Spash")
                    {
                        if (Player1.unitsToDrop.Count > 4)
                        {
                            image.sprite = Player1.unitsToDrop[4].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 4)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit6Spash")
                    {
                        if (Player1.unitsToDrop.Count > 5)
                        {
                            image.sprite = Player1.unitsToDrop[5].splashArt;
                        }

                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 5)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit1Upgrade1")
                    {
                        if (Player1.unitsToDrop.Count > 0)
                        {
                            if(Player1.unitsToDrop[0].upgrade1 != null)
                                image.sprite = Player1.unitsToDrop[0].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit1Upgrade2")
                    {
                        if (Player1.unitsToDrop.Count > 0)
                        {
                            if (Player1.unitsToDrop[0].upgrade2 != null)
                                image.sprite = Player1.unitsToDrop[0].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade1")
                    {
                        if (Player1.unitsToDrop.Count > 1)
                        {
                            if (Player1.unitsToDrop[1].upgrade1 != null)
                                image.sprite = Player1.unitsToDrop[1].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade2")
                    {
                        if (Player1.unitsToDrop.Count > 1)
                        {
                            if (Player1.unitsToDrop[1].upgrade2 != null)
                                image.sprite = Player1.unitsToDrop[1].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade1")
                    {
                        if (Player1.unitsToDrop.Count > 2)
                        {
                            if (Player1.unitsToDrop[2].upgrade1 != null)
                                image.sprite = Player1.unitsToDrop[2].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade2")
                    {
                        if (Player1.unitsToDrop.Count > 2)
                        {
                            if (Player1.unitsToDrop[2].upgrade2 != null)
                                image.sprite = Player1.unitsToDrop[2].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade1")
                    {
                        if (Player1.unitsToDrop.Count > 3)
                        {
                            if (Player1.unitsToDrop[3].upgrade1 != null)
                                image.sprite = Player1.unitsToDrop[3].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade2")
                    {
                        if (Player1.unitsToDrop.Count > 3)
                        {
                            if (Player1.unitsToDrop[3].upgrade2 != null)
                                image.sprite = Player1.unitsToDrop[3].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade1")
                    {
                        if (Player1.unitsToDrop.Count > 4)
                        {
                            if (Player1.unitsToDrop[4].upgrade1 != null)
                                image.sprite = Player1.unitsToDrop[4].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade2")
                    {
                        if (Player1.unitsToDrop.Count > 4)
                        {
                            if (Player1.unitsToDrop[4].upgrade2 != null)
                                image.sprite = Player1.unitsToDrop[4].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade1")
                    {
                        if (Player1.unitsToDrop.Count > 5)
                        {
                            if (Player1.unitsToDrop[5].upgrade1 != null)
                                image.sprite = Player1.unitsToDrop[5].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }    
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade2")
                    {
                        if (Player1.unitsToDrop.Count > 5)
                        {
                            if (Player1.unitsToDrop[5].upgrade2 != null)
                                image.sprite = Player1.unitsToDrop[5].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }

                }
                SlideIn();
                

            }
            else if (Player2.myTurn && player == 2)
            {
                SlideIn();
                foreach (Image image in allTMPS)
                {
                    image.preserveAspect = true;
                    if (image.gameObject.name == "Unit1Spash")
                    {
                        if (Player2.unitsToDrop.Count > 0)
                        {
                            image.sprite = Player2.unitsToDrop[0].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 0)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit2Spash")
                    {
                        if (Player2.unitsToDrop.Count > 1)
                        {
                            image.sprite = Player2.unitsToDrop[1].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 1)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit3Spash")
                    {
                        if (Player2.unitsToDrop.Count > 2)
                        {
                            image.sprite = Player2.unitsToDrop[2].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 2)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit4Spash")
                    {
                        if (Player2.unitsToDrop.Count > 3)
                        {
                            image.sprite = Player2.unitsToDrop[3].splashArt;
                        }

                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 3)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit5Spash")
                    {
                        if (Player2.unitsToDrop.Count > 4)
                        {
                            image.sprite = Player2.unitsToDrop[4].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 4)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit6Spash")
                    {
                        if (Player2.unitsToDrop.Count > 5)
                        {
                            image.sprite = Player2.unitsToDrop[5].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 5)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }

                    }
                    else if (image.gameObject.name == "Unit1Upgrade1")
                    {
                        if (Player2.unitsToDrop.Count > 0)
                        {
                            if (Player2.unitsToDrop[0].upgrade1 != null)
                                image.sprite = Player2.unitsToDrop[0].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit1Upgrade2")
                    {
                        if (Player2.unitsToDrop.Count > 0)
                        {
                            if (Player2.unitsToDrop[0].upgrade2 != null)
                                image.sprite = Player2.unitsToDrop[0].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade1")
                    {
                        if (Player2.unitsToDrop.Count > 1)
                        {
                            if (Player2.unitsToDrop[1].upgrade1 != null)
                                image.sprite = Player2.unitsToDrop[1].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade2")
                    {
                        if (Player2.unitsToDrop.Count > 1)
                        {
                            if (Player2.unitsToDrop[1].upgrade2 != null)
                                image.sprite = Player2.unitsToDrop[1].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade1")
                    {
                        if (Player2.unitsToDrop.Count > 2)
                        {
                            if (Player2.unitsToDrop[2].upgrade1 != null)
                                image.sprite = Player2.unitsToDrop[2].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade2")
                    {
                        if (Player2.unitsToDrop.Count > 2)
                        {
                            if (Player2.unitsToDrop[2].upgrade2 != null)
                                image.sprite = Player2.unitsToDrop[2].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade1")
                    {
                        if (Player2.unitsToDrop.Count > 3)
                        {
                            if (Player2.unitsToDrop[3].upgrade1 != null)
                                image.sprite = Player2.unitsToDrop[3].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade2")
                    {
                        if (Player2.unitsToDrop.Count > 3)
                        {
                            if (Player2.unitsToDrop[3].upgrade2 != null)
                                image.sprite = Player2.unitsToDrop[3].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade1")
                    {
                        if (Player2.unitsToDrop.Count > 4)
                        {
                            if (Player2.unitsToDrop[4].upgrade1 != null)
                                image.sprite = Player2.unitsToDrop[4].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade2")
                    {
                        if (Player2.unitsToDrop.Count > 4)
                        {
                            if (Player2.unitsToDrop[4].upgrade2 != null)
                                image.sprite = Player2.unitsToDrop[4].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade1")
                    {
                        if (Player2.unitsToDrop.Count > 5)
                        {
                            if (Player2.unitsToDrop[5].upgrade1 != null)
                                image.sprite = Player2.unitsToDrop[5].upgrade1.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade2")
                    {
                        if (Player2.unitsToDrop.Count > 5)
                        {
                            if (Player2.unitsToDrop[5].upgrade2 != null)
                                image.sprite = Player2.unitsToDrop[5].upgrade2.icon;
                            else
                            {
                                image.sprite = transparent;
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }

                }
                SlideIn();


            }
            else
            {
                SlideOut();
            }
        }
        else if (turnOrder.shopPhase)
        {
            if (Player1.myTurn && player == 1)
            {
                SlideIn();
                foreach (Image image in allTMPS)
                {
                    image.preserveAspect = true;
                    if (image.gameObject.name == "Unit1Spash")
                    {
                        if (Player1.units.Count > 0)
                        {
                            image.sprite = Player1.units[0].splashArt;
                            if (Player1.selectedUnitID == 0)
                            {
                                image.color = new Color(0, 255, 0);
                            }
                            else
                            {
                                image.color = new Color(255, 255, 255);
                            }
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Spash")
                    {
                        if (Player1.units.Count > 1)
                        {
                            image.sprite = Player1.units[1].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 1)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }

                    }
                    else if (image.gameObject.name == "Unit3Spash")
                    {
                        if (Player1.units.Count > 2)
                        {
                            image.sprite = Player1.units[2].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 2)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit4Spash")
                    {
                        if (Player1.units.Count > 3)
                        {
                            image.sprite = Player1.units[3].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 3)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit5Spash")
                    {
                        if (Player1.units.Count > 4)
                        {
                            image.sprite = Player1.units[4].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 4)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit6Spash")
                    {
                        if (Player1.units.Count > 5)
                        {
                            image.sprite = Player1.units[5].splashArt;
                        }

                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player1.selectedUnitID == 5)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit1Upgrade1")
                    {
                        if (Player1.units.Count > 0)
                        {
                            if (Player1.units[0].upgrade1 != null)
                                image.sprite = Player1.units[0].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit1Upgrade2")
                    {
                        if (Player1.units.Count > 0)
                        {
                            if (Player1.units[0].upgrade2 != null)
                                image.sprite = Player1.units[0].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade1")
                    {
                        if (Player1.units.Count > 1)
                        {
                            if (Player1.units[1].upgrade1 != null)
                                image.sprite = Player1.units[1].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade2")
                    {
                        if (Player1.units.Count > 1)
                        {
                            if (Player1.units[1].upgrade2 != null)
                                image.sprite = Player1.units[1].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade1")
                    {
                        if (Player1.units.Count > 2)
                        {
                            if (Player1.units[2].upgrade1 != null)
                                image.sprite = Player1.units[2].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade2")
                    {
                        if (Player1.units.Count > 2)
                        {
                            if (Player1.units[2].upgrade2 != null)
                                image.sprite = Player1.units[2].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade1")
                    {
                        if (Player1.units.Count > 3)
                        {
                            if (Player1.units[3].upgrade1 != null)
                                image.sprite = Player1.units[3].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade2")
                    {
                        if (Player1.units.Count > 3)
                        {
                            if (Player1.units[3].upgrade2 != null)
                                image.sprite = Player1.units[3].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade1")
                    {
                        if (Player1.units.Count > 4)
                        {
                            if (Player1.units[4].upgrade1 != null)
                                image.sprite = Player1.units[4].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade2")
                    {
                        if (Player1.units.Count > 4)
                        {
                            if (Player1.units[4].upgrade2 != null)
                                image.sprite = Player1.units[4].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade1")
                    {
                        if (Player1.units.Count > 5)
                        {
                            if (Player1.units[5].upgrade1 != null)
                                image.sprite = Player1.units[5].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade2")
                    {
                        if (Player1.units.Count > 5)
                        {
                            if (Player1.units[5].upgrade2 != null)
                                image.sprite = Player1.units[5].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }

                }
                SlideIn();


            }
            else if (Player2.myTurn && player == 2)
            {
                SlideIn();
                foreach (Image image in allTMPS)
                {
                    image.preserveAspect = true;
                    if (image.gameObject.name == "Unit1Spash")
                    {
                        if (Player2.units.Count > 0)
                        {
                            image.sprite = Player2.units[0].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 0)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit2Spash")
                    {
                        if (Player2.units.Count > 1)
                        {
                            image.sprite = Player2.units[1].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 1)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit3Spash")
                    {
                        if (Player2.units.Count > 2)
                        {
                            image.sprite = Player2.units[2].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 2)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit4Spash")
                    {
                        if (Player2.units.Count > 3)
                        {
                            image.sprite = Player2.units[3].splashArt;
                        }

                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 3)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit5Spash")
                    {
                        if (Player2.units.Count > 4)
                        {
                            image.sprite = Player2.units[4].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 4)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }
                    }
                    else if (image.gameObject.name == "Unit6Spash")
                    {
                        if (Player2.units.Count > 5)
                        {
                            image.sprite = Player2.units[5].splashArt;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                        if (Player2.selectedUnitID == 5)
                        {
                            image.color = new Color(0, 255, 0);
                        }
                        else
                        {
                            image.color = new Color(255, 255, 255);
                        }

                    }
                    else if (image.gameObject.name == "Unit1Upgrade1")
                    {
                        if (Player2.units.Count > 0)
                        {
                            if (Player2.units[0].upgrade1 != null)
                                image.sprite = Player2.units[0].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit1Upgrade2")
                    {
                        if (Player2.units.Count > 0)
                        {
                            if (Player2.units[0].upgrade2 != null)
                                image.sprite = Player2.units[0].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade1")
                    {
                        if (Player2.units.Count > 1)
                        {
                            if (Player2.units[1].upgrade1 != null)
                                image.sprite = Player2.units[1].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit2Upgrade2")
                    {
                        if (Player2.units.Count > 1)
                        {
                            if (Player2.units[1].upgrade2 != null)
                                image.sprite = Player2.units[1].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade1")
                    {
                        if (Player2.units.Count > 2)
                        {
                            if (Player2.units[2].upgrade1 != null)
                                image.sprite = Player2.units[2].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit3Upgrade2")
                    {
                        if (Player2.units.Count > 2)
                        {
                            if (Player2.units[2].upgrade2 != null)
                                image.sprite = Player2.units[2].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade1")
                    {
                        if (Player2.units.Count > 3)
                        {
                            if (Player2.units[3].upgrade1 != null)
                                image.sprite = Player2.units[3].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit4Upgrade2")
                    {
                        if (Player2.units.Count > 3)
                        {
                            if (Player2.units[3].upgrade2 != null)
                                image.sprite = Player2.units[3].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade1")
                    {
                        if (Player2.units.Count > 4)
                        {
                            if (Player2.units[4].upgrade1 != null)
                                image.sprite = Player2.units[4].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit5Upgrade2")
                    {
                        if (Player2.units.Count > 4)
                        {
                            if (Player2.units[4].upgrade2 != null)
                                image.sprite = Player2.units[4].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade1")
                    {
                        if (Player2.units.Count > 5)
                        {
                            if (Player2.units[5].upgrade1 != null)
                                image.sprite = Player2.units[5].upgrade1.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
                    }
                    else if (image.gameObject.name == "Unit6Upgrade2")
                    {
                        if (Player2.units.Count > 5)
                        {
                            if (Player2.units[5].upgrade2 != null)
                                image.sprite = Player2.units[5].upgrade2.icon;
                        }
                        else
                        {
                            image.sprite = transparent;
                        }
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




    void SlideIn()
    {
        if (!isInScene && player == 1)
            GetComponent<RectTransform>().DOAnchorPosX(200, 0.1f);
        else if (!isInScene && player == 2)
            GetComponent<RectTransform>().DOAnchorPosX(-200, 0.1f);

        isInScene = true;
    }

    void SlideOut()
    {
        if (isInScene && player == 1)
            GetComponent<RectTransform>().DOAnchorPosX(-200, 0.1f);
        else if (!isInScene && player == 2)
            GetComponent<RectTransform>().DOAnchorPosX(200, 0.1f);
        isInScene = false;
    }


}
