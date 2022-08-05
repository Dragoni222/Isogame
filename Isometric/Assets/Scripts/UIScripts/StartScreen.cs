using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button upgrade1Button;
    public bool startGame;
    void Start()
    {
        upgrade1Button.GetComponent<Button>().onClick.AddListener(StartButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartButton()
    {
        startGame = true;
        GetComponent<RectTransform>().DOAnchorPosY(2000, 2f).SetEase(Ease.InBack);
    }
}
