using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startImage;
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("whoGame"));
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
        Debug.Log("oyun baþladý");
    }
}
