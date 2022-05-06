using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private AudioClip buttonClip;
    void Start()
    {

    }
    public void WhoGameOpen(string whoGame)
    {
        audioSource.PlayOneShot(buttonClip);
        PlayerPrefs.SetString("whoGame",whoGame);
        SceneManager.LoadScene(2);
    }

    public void AgainMenu()
    {
        audioSource.PlayOneShot(buttonClip);
        SceneManager.LoadScene(0);
    }
    public void StartLevelPanel()
    {
        levelPanel.GetComponent<CanvasGroup>().DOFade(1, 1);
        levelPanel.GetComponent<RectTransform>().DOScale(1, 1);
    }
}
