using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private GameObject soundPanel;

    bool soundPanelSetActive;
    void Start()
    {
        soundPanelSetActive = false;
        soundPanel.GetComponent<RectTransform>().localScale = Vector3.one;
        audioSource = GetComponent<AudioSource>();
        menuPanel.GetComponent<CanvasGroup>().DOFade(1,1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutBack);
    }

    public void StartLevelMenu()
    {
        audioSource.PlayOneShot(buttonClip);
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        //Daha sonra
    }
    public void ExitGame()
    {
        audioSource.PlayOneShot(buttonClip);
        Application.Quit();
    }
}
