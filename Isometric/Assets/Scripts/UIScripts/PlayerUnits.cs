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
    public bool isInScene = false;
    [SerializeField] int player;
    [SerializeField] Sprite Warrior1;
    [SerializeField] Sprite Warrior2;
    [SerializeField] Sprite Lobber1;
    [SerializeField] Sprite Lobber2;
    [SerializeField] Sprite Ranger1;
    [SerializeField] Sprite Ranger2;
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

                    if (image.gameObject.name == "Unit1Spash")
                    {
                        if(Player1.unitsToDrop.Count > 0)
                        {
                            if (Player1.unitsToDrop[0].charClass == "Warrior")
                                image.sprite = Warrior1;
                            else if (Player1.unitsToDrop[0].charClass == "Lobber")
                                image.sprite = Lobber1;
                            else if (Player1.unitsToDrop[0].charClass == "Ranger")
                                image.sprite = Ranger1;
                        }

                       

                    }
                    else if (image.gameObject.name == "Unit2Spash")
                    {
                        if (Player1.unitsToDrop.Count > 1)
                        {
                            if (Player1.unitsToDrop[1].charClass == "Warrior")
                                image.sprite = Warrior1;
                            else if (Player1.unitsToDrop[1].charClass == "Lobber")
                                image.sprite = Lobber1;
                            else if (Player1.unitsToDrop[1].charClass == "Ranger")
                                image.sprite = Ranger1;
                        }
                      

                    }
                    else if (image.gameObject.name == "Unit3Spash")
                    {
                        if (Player1.unitsToDrop.Count > 2)
                        {
                            if (Player1.unitsToDrop[2].charClass == "Warrior")
                                image.sprite = Warrior1;
                            else if (Player1.unitsToDrop[2].charClass == "Lobber")
                                image.sprite = Lobber1;
                            else if (Player1.unitsToDrop[2].charClass == "Ranger")
                                image.sprite = Ranger1;
                        }
                      

                    }
                    else if (image.gameObject.name == "Unit4Spash")
                    {
                        if (Player1.unitsToDrop.Count > 3)
                        {
                            if (Player1.unitsToDrop[3].charClass == "Warrior")
                                image.sprite = Warrior1;
                            else if (Player1.unitsToDrop[3].charClass == "Lobber")
                                image.sprite = Lobber1;
                            else if (Player1.unitsToDrop[3].charClass == "Ranger")
                                image.sprite = Ranger1;
                        }
                        

                    }
                    else if (image.gameObject.name == "Unit5Spash")
                    {
                        if (Player1.unitsToDrop.Count > 4)
                        {
                            if (Player1.unitsToDrop[4].charClass == "Warrior")
                                image.sprite = Warrior1;
                            else if (Player1.unitsToDrop[4].charClass == "Lobber")
                                image.sprite = Lobber1;
                            else if (Player1.unitsToDrop[4].charClass == "Ranger")
                                image.sprite = Ranger1;
                        }
                      

                    }
                    else if (image.gameObject.name == "Unit6Spash")
                    {
                        if (Player1.unitsToDrop.Count > 5)
                        {
                            if (Player1.unitsToDrop[5].charClass == "Warrior")
                                image.sprite = Warrior1;
                            else if (Player1.unitsToDrop[5].charClass == "Lobber")
                                image.sprite = Lobber1;
                            else if (Player1.unitsToDrop[5].charClass == "Ranger")
                                image.sprite = Ranger1;
                        }
                       

                    }
                    else if (image.gameObject.name == "Unit1Upgrade1")
                    {


                    }
                    else if (image.gameObject.name == "Unit1Upgrade2")
                    {


                    }
                    else if (image.gameObject.name == "Unit2Upgrade1")
                    {


                    }
                    else if (image.gameObject.name == "Unit2Upgrade2")
                    {


                    }
                    else if (image.gameObject.name == "Unit3Upgrade1")
                    {


                    }
                    else if (image.gameObject.name == "Unit3Upgrade2")
                    {


                    }
                    else if (image.gameObject.name == "Unit4Upgrade1")
                    {


                    }
                    else if (image.gameObject.name == "Unit4Upgrade2")
                    {


                    }
                    else if (image.gameObject.name == "Unit5Upgrade1")
                    {


                    }
                    else if (image.gameObject.name == "Unit5Upgrade2")
                    {


                    }
                    else if (image.gameObject.name == "Unit6Upgrade1")
                    {


                    }
                    else if (image.gameObject.name == "Unit6Upgrade2")
                    {


                    }

                }
                SlideIn();
                

            }
            else if (Player2.myTurn && player == 2)
            {
                SlideIn();
                if (Player2.selectedUnit != null)
                {
                    foreach (Image image in allTMPS)
                    {
                        if (image.gameObject.name == "Unit1Spash")
                        {
                            if (Player2.unitsToDrop.Count > 0)
                            {
                                if (Player2.unitsToDrop[0].charClass == "Warrior")
                                    image.sprite = Warrior1;
                                else if (Player2.unitsToDrop[0].charClass == "Lobber")
                                    image.sprite = Lobber1;
                                else if (Player2.unitsToDrop[0].charClass == "Ranger")
                                    image.sprite = Ranger1;
                            }
                           

                        }
                        else if (image.gameObject.name == "Unit2Spash")
                        {
                            if (Player2.unitsToDrop.Count > 1)
                            {
                                if (Player2.unitsToDrop[1].charClass == "Warrior")
                                    image.sprite = Warrior1;
                                else if (Player2.unitsToDrop[1].charClass == "Lobber")
                                    image.sprite = Lobber1;
                                else if (Player2.unitsToDrop[1].charClass == "Ranger")
                                    image.sprite = Ranger1;
                            }
                      

                        }
                        else if (image.gameObject.name == "Unit3Spash")
                        {
                            if (Player2.unitsToDrop.Count > 2)
                            {
                                if (Player2.unitsToDrop[2].charClass == "Warrior")
                                    image.sprite = Warrior1;
                                else if (Player2.unitsToDrop[2].charClass == "Lobber")
                                    image.sprite = Lobber1;
                                else if (Player2.unitsToDrop[2].charClass == "Ranger")
                                    image.sprite = Ranger1;
                            }
                        

                        }
                        else if (image.gameObject.name == "Unit4Spash")
                        {
                            if (Player2.unitsToDrop.Count > 3)
                            {
                                if (Player2.unitsToDrop[3].charClass == "Warrior")
                                    image.sprite = Warrior1;
                                else if (Player2.unitsToDrop[3].charClass == "Lobber")
                                    image.sprite = Lobber1;
                                else if (Player2.unitsToDrop[3].charClass == "Ranger")
                                    image.sprite = Ranger1;
                            }
                            

                        }
                        else if (image.gameObject.name == "Unit5Spash")
                        {
                            if (Player2.unitsToDrop.Count > 4)
                            {
                                if (Player2.unitsToDrop[4].charClass == "Warrior")
                                    image.sprite = Warrior1;
                                else if (Player2.unitsToDrop[4].charClass == "Lobber")
                                    image.sprite = Lobber1;
                                else if (Player2.unitsToDrop[4].charClass == "Ranger")
                                    image.sprite = Ranger1;
                            }
                          

                        }
                        else if (image.gameObject.name == "Unit6Spash")
                        {
                            if (Player2.unitsToDrop.Count > 5)
                            {
                                if (Player2.unitsToDrop[5].charClass == "Warrior")
                                    image.sprite = Warrior1;
                                else if (Player2.unitsToDrop[5].charClass == "Lobber")
                                    image.sprite = Lobber1;
                                else if (Player2.unitsToDrop[5].charClass == "Ranger")
                                    image.sprite = Ranger1;
                            }
                          

                        }
                        else if (image.gameObject.name == "Unit1Upgrade1")
                        {


                        }
                        else if (image.gameObject.name == "Unit1Upgrade2")
                        {


                        }
                        else if (image.gameObject.name == "Unit2Upgrade1")
                        {


                        }
                        else if (image.gameObject.name == "Unit2Upgrade2")
                        {


                        }
                        else if (image.gameObject.name == "Unit3Upgrade1")
                        {


                        }
                        else if (image.gameObject.name == "Unit3Upgrade2")
                        {


                        }
                        else if (image.gameObject.name == "Unit4Upgrade1")
                        {


                        }
                        else if (image.gameObject.name == "Unit4Upgrade2")
                        {


                        }
                        else if (image.gameObject.name == "Unit5Upgrade1")
                        {


                        }
                        else if (image.gameObject.name == "Unit5Upgrade2")
                        {


                        }
                        else if (image.gameObject.name == "Unit6Upgrade1")
                        {


                        }
                        else if (image.gameObject.name == "Unit6Upgrade2")
                        {


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
        if (!isInScene && player == 1)
            GetComponent<RectTransform>().DOMoveX(208.8f, 0.1f);
        else if (!isInScene && player == 2)
            GetComponent<RectTransform>().DOMoveX(1710.8f, 0.1f);

        isInScene = true;
    }

    void SlideOut()
    {
        if (isInScene && player == 1)
            GetComponent<RectTransform>().DOMoveX(-300, 0.1f);
        else if (!isInScene && player == 2)
            GetComponent<RectTransform>().DOMoveX(2300, 0.1f);
        isInScene = false;
    }


}
