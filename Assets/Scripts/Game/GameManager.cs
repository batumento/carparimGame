using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startImage;
    [SerializeField] private Text questionText;

    private string whoGame;
    private int firstMultiplier;
    private int secondMultiplier;
    void Start()
    {
        if (PlayerPrefs.HasKey("whoGame"))
        {
            this.whoGame = PlayerPrefs.GetString("whoGame");
        }
        StartCoroutine(StartImage());
    }

    IEnumerator StartImage()
    {
        startImage.GetComponent<RectTransform>().DOScale(0,1f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        startImage.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
        yield return new WaitForSeconds(0.5f);
        StartGame();
    }
    public void StartGame()
    {
        PrintQuestion();
    }

    void FirstMultiplier()
    {
        switch (whoGame)
        {
            case "two":
                firstMultiplier = 2;
                break;

            case "three":
                firstMultiplier = 3;
                break;

            case "four":
                firstMultiplier = 4;
                break;

            case "five":
                firstMultiplier = 5;
                break;

            case "six":
                firstMultiplier = 6;
                break;

            case "seven":
                firstMultiplier = 7;
                break;

            case "eight":
                firstMultiplier = 8;
                break;

            case "nine":
                firstMultiplier = 9;
                break;

            case "teen":
                firstMultiplier = 10;
                break;

            case "mixed":
                firstMultiplier = Random.Range(2,11);
                break;
        }
        Debug.Log(firstMultiplier);
    }
    void PrintQuestion()
    {
        FirstMultiplier();
        secondMultiplier = Random.Range(2, 11);
        int randomValue = Random.Range(0, 100);
        if (randomValue <=50)
        {
            questionText.text = firstMultiplier.ToString() +"x"+ secondMultiplier.ToString();
        }
        else
        {
            questionText.text = secondMultiplier.ToString() + "x" + firstMultiplier.ToString();
        }

    }
}
