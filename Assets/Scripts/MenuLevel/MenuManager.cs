using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    void Start()
    {
        menuPanel.GetComponent<CanvasGroup>().DOFade(1,1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBack);
    }

    public void StartLevelMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        //Daha sonra
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
