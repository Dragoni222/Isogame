using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    [SerializeField] Button unit1Button;
    [SerializeField] Button unit2Button;

    UnitScript unit1;
    UnitScript unit2;

    [SerializeField] Button upgrade1Button;
    [SerializeField] Button upgrade2Button;
    [SerializeField] Button upgrade3Button;
    [SerializeField] Button upgrade4Button;

    Upgrade upgrade1;
    Upgrade upgrade2;
    Upgrade upgrade3;
    Upgrade upgrade4;

    [SerializeField] PlayerScript player1;
    [SerializeField] PlayerScript player2;
    [SerializeField] TurnOrdererScript turnOrder;

    [SerializeField] GameObject unitPrefab;
    BoardScript board;
    GameObject[] allUpgrades;

    void Start()
    {
        board = turnOrder.board;
        unit1Button.GetComponent<Button>().onClick.AddListener(Unit1Pressed);
        unit2Button.GetComponent<Button>().onClick.AddListener(Unit2Pressed);
        upgrade1Button.GetComponent<Button>().onClick.AddListener(Upgrade1Pressed);
        upgrade2Button.GetComponent<Button>().onClick.AddListener(Upgrade2Pressed);
        upgrade3Button.GetComponent<Button>().onClick.AddListener(Upgrade3Pressed);
        upgrade4Button.GetComponent<Button>().onClick.AddListener(Upgrade4Pressed);
        allUpgrades = GameObject.FindGameObjectsWithTag("Upgrade");
        DestroyShop();


    }

    // Update is called once per frame
    void Update()
    {
        board = turnOrder.board;
        if (unit1 == null)
        {
            unit1Button.transform.parent.gameObject.SetActive(false);
        }
        else if (unit1 != null)
        {
            unit1Button.transform.parent.gameObject.SetActive(true);
        }
        if (unit2 == null)
        {
            unit2Button.transform.parent.gameObject.SetActive(false);
        }
        else if (unit2 != null)
        {
            unit2Button.transform.parent.gameObject.SetActive(true);
        }
        if (upgrade1 == null)
        {
            upgrade1Button.transform.parent.gameObject.SetActive(false);
        }
        else if (upgrade1 != null)
        {
            upgrade1Button.transform.parent.gameObject.SetActive(true);
        }
        if (upgrade2 == null)
        {
            upgrade2Button.transform.parent.gameObject.SetActive(false);
        }
        else if (upgrade2 != null)
        {
            upgrade2Button.transform.parent.gameObject.SetActive(true);
        }
        if (upgrade3 == null)
        {
            upgrade3Button.transform.parent.gameObject.SetActive(false);
        }
        else if (upgrade3 != null)
        {
            upgrade3Button.transform.parent.gameObject.SetActive(true);
        }
        if (upgrade4 == null)
        {
            upgrade4Button.transform.parent.gameObject.SetActive(false);
        }
        else if (upgrade4 != null)
        {
            upgrade4Button.transform.parent.gameObject.SetActive(true);
        }





        foreach (Image image in GetComponentsInChildren<Image>())
        {
            
            if(image.gameObject.name == "UnitSplash1" && unit1 != null)
            {
                image.sprite = unit1.splashArt;
                image.preserveAspect = true;
            }
            else if (image.gameObject.name == "UnitSplash2" && unit2 != null)
            {
                image.sprite = unit2.splashArt;
                image.preserveAspect = true;
            }
            else if(image.gameObject.name == "Image1" && upgrade1 != null)
            {
                image.sprite = upgrade1.icon;
                image.preserveAspect = true;
            }
            else if (image.gameObject.name == "Image2" && upgrade2 != null)
            {
                image.sprite = upgrade2.icon;
                image.preserveAspect = true;
            }
            else if (image.gameObject.name == "Image3" && upgrade3 != null)
            {
                image.sprite = upgrade3.icon;
                image.preserveAspect = true;
            }
            else if (image.gameObject.name == "Image4" && upgrade4 != null)
            {
                image.sprite = upgrade4.icon;
                image.preserveAspect = true;
            }

        }
        foreach (TextMeshProUGUI text in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (text.gameObject.name == "UnitName1" && unit1 != null)
            {
                text.text = unit1.charClass;
            }
            else if (text.gameObject.name == "UnitName2" && unit2 != null)
            {
                text.text = unit2.charClass;
            }
            else if (text.gameObject.name == "UpgradeText1" && upgrade1 != null)
            {
                text.text = upgrade1.description;

            }
            else if (text.gameObject.name == "UpgradeText2" && upgrade2 != null)
            {
                text.text = upgrade2.description;

            }
            else if (text.gameObject.name == "UpgradeText3" && upgrade3 != null)
            {
                text.text = upgrade3.description;

            }
            else if (text.gameObject.name == "UpgradeText4" && upgrade4 != null)
            {
                text.text = upgrade4.description;

            }
            else if (text.gameObject.name == "UpgradeName1" && upgrade1 != null)
            {
                text.text = upgrade1.Name;

            }
            else if (text.gameObject.name == "UpgradeName2"& upgrade1 != null)
            {
                text.text = upgrade2.Name;

            }
            else if (text.gameObject.name == "UpgradeName3" && upgrade1 != null)
            {
                text.text = upgrade3.Name;

            }
            else if (text.gameObject.name == "UpgradeName4" && upgrade1 != null)
            {
                text.text = upgrade4.Name;

            }
            if(text.gameObject.name == "P1Money")
            {
                text.text = "P1 Funds: "+player1.money.ToString();
            }
            if (text.gameObject.name == "P2Money")
            {
                text.text = "P2 Funds: " + player2.money.ToString();
            }



        }

    }

    public void ResetShop()
    {
        unit1Button.transform.parent.gameObject.SetActive(true);
        unit2Button.transform.parent.gameObject.SetActive(true);
        upgrade1Button.transform.parent.gameObject.SetActive(true);
        upgrade2Button.transform.parent.gameObject.SetActive(true);
        upgrade3Button.transform.parent.gameObject.SetActive(true);
        upgrade4Button.transform.parent.gameObject.SetActive(true);


        foreach (Image image in GetComponentsInChildren<Image>())
        {
            image.enabled = true;
            
        }
        foreach (TextMeshProUGUI text in GetComponentsInChildren<TextMeshProUGUI>())
        {
            text.enabled = true;
        }
        int randomUnit = Random.Range(1, 4);

        if(randomUnit == 1)
        {
            unit1 = PhotonNetwork.Instantiate(unitPrefab.name, new Vector3(1000, 1000, 1000), Quaternion.identity,0).GetComponent<UnitScript>();
            unit1.SpawnByClass(new Vector2(0, 0),  "Warrior", 0);
        }
        else if(randomUnit == 2)
        {
            unit1 = PhotonNetwork.Instantiate(unitPrefab.name, new Vector3(1000, 1000, 1000), Quaternion.identity,0).GetComponent<UnitScript>();
            unit1.SpawnByClass(new Vector2(0, 0), "Lobber", 0);
        }
        else if (randomUnit == 3)
        {
            unit1 = PhotonNetwork.Instantiate(unitPrefab.name, new Vector3(1000, 1000, 1000), Quaternion.identity,0).GetComponent<UnitScript>();
            unit1.SpawnByClass(new Vector2(0, 0), "Ranger", 0);
        }

        int randomUnit2 = Random.Range(1, 4);

        if (randomUnit2 == 1)
        {
            unit2 = PhotonNetwork.Instantiate(unitPrefab.name, new Vector3(1000, 1000, 1000), Quaternion.identity,0).GetComponent<UnitScript>();
            unit2.SpawnByClass(new Vector2(0, 0), "Warrior", 0);
        }
        else if (randomUnit2 == 2)
        {
            unit2 = PhotonNetwork.Instantiate(unitPrefab.name, new Vector3(1000, 1000, 1000), Quaternion.identity,0).GetComponent<UnitScript>();
            unit2.SpawnByClass(new Vector2(0, 0), "Lobber", 0);
        }
        else if (randomUnit2 == 3)
        {
            unit2 = PhotonNetwork.Instantiate(unitPrefab.name, new Vector3(1000, 1000, 1000), Quaternion.identity,0).GetComponent<UnitScript>();
            unit2.SpawnByClass(new Vector2(0, 0), "Ranger", 0);
        }


        int randomItem1 = Random.Range(0, allUpgrades.Length);
        upgrade1 = allUpgrades[randomItem1].GetComponent<Upgrade>();
        int randomItem2 = Random.Range(0, allUpgrades.Length);
        upgrade2 = allUpgrades[randomItem2].GetComponent<Upgrade>();
        int randomItem3 = Random.Range(0, allUpgrades.Length);
        upgrade3 = allUpgrades[randomItem3].GetComponent<Upgrade>();
        int randomItem4 = Random.Range(0, allUpgrades.Length);
        upgrade4 = allUpgrades[randomItem4].GetComponent<Upgrade>();





    }

    public void DestroyShop()
    {
        foreach(Image image in GetComponentsInChildren<Image>())
        {
            image.enabled = false;
        }
        foreach (TextMeshProUGUI text in GetComponentsInChildren<TextMeshProUGUI>())
        {
            text.enabled = false;
        }

        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            if(unit.GetComponent<UnitScript>().team == 0)
            {
                Destroy(unit);
            }
        }
    }

    void Unit1Pressed()
    {
        if (player1.myTurn && player1.money >= 2)
        {
            unit1.SpawnByClass(new Vector2(0,0),  unit1.charClass, 1);
            turnOrder.hasBought = true;
            player1.money -= 2;
            unit1 = null;
        }
        else if (player2.myTurn&&player2.money >= 2)
        {
            unit1.SpawnByClass(new Vector2(0, 0),  unit1.charClass, 2);
            turnOrder.hasBought = true;
            player2.money -= 2;
            unit1 = null;
        }


    }
    void Unit2Pressed()
    {
        if (player1.myTurn && player1.money >=2)
        {
            unit2.SpawnByClass(new Vector2(0, 0), unit2.charClass, 1);
            turnOrder.hasBought = true;
            player1.money -= 2;
            unit2 = null;
        }
        else if (player2.myTurn && player2.money >= 2)
        {
            unit2.SpawnByClass(new Vector2(0, 0),  unit2.charClass, 2);
            turnOrder.hasBought = true;
            player2.money -= 2;
            unit2 = null;
        }
        
    }

    void Upgrade1Pressed()
    {
        if (player1.myTurn && player1.money >= 1)
        {
            if (player1.units[player1.selectedUnitID].upgrade1 == null)
            {
                player1.units[player1.selectedUnitID].upgrade1 = upgrade1;
                turnOrder.hasBought = true;
                upgrade1 = null;
                player1.money -= 1;
            }

            else if (player1.units[player1.selectedUnitID].upgrade2 == null)
            {
                player1.units[player1.selectedUnitID].upgrade2 = upgrade1;
                turnOrder.hasBought = true;
                upgrade1 = null;
                player1.money -= 1;
            }
        }
        else if (player2.myTurn && player2.money >= 1)
        {
            if (player2.units[player2.selectedUnitID].upgrade1 == null)
            {
                player2.units[player2.selectedUnitID].upgrade1 = upgrade1;
                turnOrder.hasBought = true;
                upgrade1 = null;
                player2.money -= 1;
            }

            else if (player2.units[player2.selectedUnitID].upgrade2 == null)
            {
                player2.units[player2.selectedUnitID].upgrade2 = upgrade1;
                turnOrder.hasBought = true;
                upgrade1 = null;
                player2.money -= 1;
            }
        }

        
    }
    void Upgrade2Pressed()
    {
        if (player1.myTurn && player1.money >= 1)
        {
            if (player1.units[player1.selectedUnitID].upgrade1 == null)
            {
                player1.units[player1.selectedUnitID].upgrade1 = upgrade2;
                turnOrder.hasBought = true;
                upgrade2 = null;
                player1.money -= 1;
            }

            else if (player1.units[player1.selectedUnitID].upgrade2 == null)
            {
                player1.units[player1.selectedUnitID].upgrade2 = upgrade2;
                turnOrder.hasBought = true;
                upgrade2 = null;
                player1.money -= 1;
            }
        }
        else if (player2.myTurn && player2.money >= 1)
        {
            if (player2.units[player2.selectedUnitID].upgrade1 == null)
            {
                player2.units[player2.selectedUnitID].upgrade1 = upgrade2;
                turnOrder.hasBought = true;
                upgrade2 = null;
                player2.money -= 1;
            }

            else if (player2.units[player2.selectedUnitID].upgrade2 == null)
            {
                player2.units[player2.selectedUnitID].upgrade2 = upgrade2;
                turnOrder.hasBought = true;
                upgrade2 = null;
                player2.money -= 1;
            }
        }

    }
    void Upgrade3Pressed()
    {
        if (player1.myTurn && player1.money >= 1)
        {
            if (player1.units[player1.selectedUnitID].upgrade1 == null)
            {
                player1.units[player1.selectedUnitID].upgrade1 = upgrade3;
                turnOrder.hasBought = true;
                upgrade3 = null;
                player1.money -= 1;
            }

            else if (player1.units[player1.selectedUnitID].upgrade2 == null)
            {
                player1.units[player1.selectedUnitID].upgrade2 = upgrade3;
                turnOrder.hasBought = true;
                upgrade3 = null;
                player1.money -= 1;
            }
        }
        else if (player2.myTurn && player2.money >= 1)
        {
            if (player2.units[player2.selectedUnitID].upgrade1 == null)
            {
                player2.units[player2.selectedUnitID].upgrade1 = upgrade3;
                turnOrder.hasBought = true;
                upgrade3 = null;
                player2.money -= 1;
            }

            else if (player2.units[player2.selectedUnitID].upgrade2 == null)
            {
                player2.units[player2.selectedUnitID].upgrade2 = upgrade3;
                turnOrder.hasBought = true;
                upgrade3 = null;
                player2.money -= 1;
            }
        }

   
    }
    void Upgrade4Pressed()
    {
        if (player1.myTurn && player1.money >= 1)
        {
            if (player1.units[player1.selectedUnitID].upgrade1 == null)
            {
                player1.units[player1.selectedUnitID].upgrade1 = upgrade4;
                turnOrder.hasBought = true;
                upgrade4 = null;
                player1.money -= 1;

            }
            else if (player1.units[player1.selectedUnitID].upgrade2 == null)
            {
                player1.units[player1.selectedUnitID].upgrade2 = upgrade4;
                turnOrder.hasBought = true;
                upgrade4 = null;
                player1.money -= 1;
            }
        }
        else if (player2.myTurn && player2.money >= 1)
        {
            if (player2.units[player2.selectedUnitID].upgrade1 == null)
            {
                player2.units[player2.selectedUnitID].upgrade1 = upgrade4;
                turnOrder.hasBought = true;
                upgrade4 = null;
                player2.money -= 1;
            }

            else if (player2.units[player2.selectedUnitID].upgrade2 == null)
            {
                player2.units[player2.selectedUnitID].upgrade2 = upgrade4;
                turnOrder.hasBought = true;
                upgrade4 = null;
                player2.money -= 1;
            }
        }

    }


}
