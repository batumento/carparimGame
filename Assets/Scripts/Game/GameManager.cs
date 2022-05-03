using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startImage;
    [SerializeField] private Text questionText;
    [SerializeField] private Text trueQuestion1,trueQuestion2,trueQuestion3;
    [SerializeField] private Text trueText, falseText, scoreText;

    private string whoGame;
    private int firstMultiplier;
    private int secondMultiplier;
    private int trueValue;
    private int falseValue1;
    private int falseValue2;
    private int trueCounter;
    private int falseCounter;
    private int scoreCounter;
    


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
        trueValue = firstMultiplier * secondMultiplier;
        PrintResult();
    }

    void PrintResult()
    {
        falseValue1 = trueValue + Random.Range(2, 8);
        if (trueValue > 10 )
        {
            falseValue2 = trueValue - Random.Range(2, 8);
        }
        else
        {
            falseValue2 = Mathf.Abs(trueValue - Random.Range(2, 5));
        }
        int randomValue = Random.Range(1,100);
        if (randomValue <=33)
        {
            trueQuestion1.text = trueValue.ToString();
            trueQuestion2.text = falseValue1.ToString();
            trueQuestion3.text = falseValue2.ToString();
        }
        else if (randomValue <= 66)
        {
            trueQuestion2.text = trueValue.ToString();
            trueQuestion1.text = falseValue2.ToString();
            trueQuestion3.text = falseValue1.ToString();
        }
        else
        {
            trueQuestion3.text = trueValue.ToString();
            trueQuestion1.text = falseValue1.ToString();
            trueQuestion2.text = falseValue2.ToString();
        }
    }
    public void ResultChecked(int resultText)
    {
        if (resultText == trueValue)
        {
            Debug.Log("Nice");
            trueCounter++;
            scoreCounter += 10;
        }
        else
        {
            Debug.Log("Fucking");
            falseCounter++;
            
        }
        trueText.text = trueCounter.ToString() + " Doðru";
        falseText.text = falseCounter.ToString() + " Yanlýþ";
        scoreText.text = scoreCounter.ToString() + " Puan";
        PrintQuestion();
    }
}
