using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class TurnChangeScript : MonoBehaviour
{
    [SerializeField] Sprite Player1Sprite;
    [SerializeField] Sprite Player2Sprite;
    public void ChangeTurn(int player)
    {
        if(player == 1)
        {
            GetComponent<Image>().sprite = Player1Sprite;
            GetComponentInChildren<TextMeshProUGUI>().text = "Player 1's Turn!";
            GetComponent<RectTransform>().DOMoveX(1000, 0.5f).SetEase(Ease.OutQuad).OnComplete(() => { GetComponent<RectTransform>().DOMoveX(-2000, 0.5f).SetEase(Ease.InQuad); });
        }
        if (player == 2)
        {
            GetComponent<Image>().sprite = Player2Sprite;
            GetComponentInChildren<TextMeshProUGUI>().text = "Player 2's Turn!";
            GetComponent<RectTransform>().DOMoveX(1000, 0.5f).SetEase(Ease.OutQuad).OnComplete(() => { GetComponent<RectTransform>().DOMoveX(4000, 0.5f).SetEase(Ease.InQuad); });
        }
    }
}
