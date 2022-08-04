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
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardScript>();
        unit1Button.GetComponent<Button>().onClick.AddListener(Unit1Pressed);
        unit2Button.GetComponent<Button>().onClick.AddListener(Unit2Pressed);
        allUpgrades = GameObject.FindGameObjectsWithTag("Upgrade");
        DestroyShop();


    }

    // Update is called once per frame
    void Update()
    {

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
            else if (image.gameObject.name == "Image2" && upgrade1 != null)
            {
                image.sprite = upgrade2.icon;
                image.preserveAspect = true;
            }
            else if (image.gameObject.name == "Image3" && upgrade1 != null)
            {
                image.sprite = upgrade3.icon;
                image.preserveAspect = true;
            }
            else if (image.gameObject.name == "Image4" && upgrade1 != null)
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
            else if (text.gameObject.name == "UpgradeText2" && upgrade1 != null)
            {
                text.text = upgrade2.description;

            }
            else if (text.gameObject.name == "UpgradeText3" && upgrade1 != null)
            {
                text.text = upgrade3.description;

            }
            else if (text.gameObject.name == "UpgradeText4" && upgrade1 != null)
            {
                text.text = upgrade4.description;

            }
        }

    }

    public void ResetShop()
    {
        unit1Button.transform.parent.gameObject.SetActive(true);
        unit2Button.transform.parent.gameObject.SetActive(true);
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
            unit1 = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity).GetComponent<UnitScript>();
            unit1.SpawnByClass(new Vector2(0, 0), board, "Warrior", 0);
        }
        else if(randomUnit == 2)
        {
            unit1 = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity).GetComponent<UnitScript>();
            unit1.SpawnByClass(new Vector2(0, 0), board, "Lobber", 0);
        }
        else if (randomUnit == 3)
        {
            unit1 = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity).GetComponent<UnitScript>();
            unit1.SpawnByClass(new Vector2(0, 0), board, "Ranger", 0);
        }

        int randomUnit2 = Random.Range(1, 4);

        if (randomUnit2 == 1)
        {
            unit2 = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity).GetComponent<UnitScript>();
            unit2.SpawnByClass(new Vector2(0, 0), board, "Warrior", 0);
        }
        else if (randomUnit2 == 2)
        {
            unit2 = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity).GetComponent<UnitScript>();
            unit2.SpawnByClass(new Vector2(0, 0), board, "Lobber", 0);
        }
        else if (randomUnit2 == 3)
        {
            unit2 = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity).GetComponent<UnitScript>();
            unit2.SpawnByClass(new Vector2(0, 0), board, "Ranger", 0);
        }


        int randomItem1 = Random.Range(0, allUpgrades.Length);
        upgrade1 = allUpgrades[randomItem1].GetComponent<Upgrade>();
        int randomItem2 = Random.Range(0, allUpgrades.Length);
        upgrade2 = allUpgrades[randomItem1].GetComponent<Upgrade>();
        int randomItem3 = Random.Range(0, allUpgrades.Length);
        upgrade3 = allUpgrades[randomItem1].GetComponent<Upgrade>();
        int randomItem4 = Random.Range(0, allUpgrades.Length);
        upgrade4 = allUpgrades[randomItem1].GetComponent<Upgrade>();





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
        if (player1.myTurn)
        {
            player1.units.Add(unit1);
        }
        else
        {
            player2.units.Add(unit1);
        }

        unit1 = null;
    }
    void Unit2Pressed()
    {
        if (player1.myTurn)
        {
            player1.units.Add(unit2);
        }
        else
        {
            player2.units.Add(unit2);
        }
        unit2 = null;
    }



}
