using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class EndScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool end;
    public TurnOrdererScript turnOrder;
    [SerializeField] Button titleScreenButton;

    [SerializeField] Image p1Image;
    [SerializeField] Image p2Image;
    [SerializeField] Image buttonImage;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        titleScreenButton.GetComponent<Button>().onClick.AddListener(Restartgame);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (end)
        {
            p1Image.enabled = true;
            p2Image.enabled = true;
            buttonImage.enabled = true;
            text.enabled = true;
            titleScreenButton.enabled = true;

            GetComponent<Image>().enabled = true;
            if(turnOrder.player1Score >= 5)
            {
                GetComponent<Image>().color = new Color(228, 114, 32);
                foreach(Image image in GetComponentsInChildren<Image>())
                {
                    if(image.gameObject.name == "Player1End")
                    {
                        image.enabled = true;
                        GetComponent<Image>().color = new Color(228, 114, 32);
                    }
                }
            }
            else
            {
                GetComponent<Image>().color = new Color(139,225,43);
                foreach (Image image in GetComponentsInChildren<Image>())
                {
                    if (image.gameObject.name == "Player2End")
                    {
                        image.enabled = true;
                        GetComponent<Image>().color = new Color(139, 225, 43);
                    }
                }
            }
        }
        
    }

    void Restartgame()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
