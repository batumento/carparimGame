using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LoadingManager : MonoBehaviour
{
    
    [SerializeField] private GameObject loadingCircle;
    [SerializeField] private int loadingSpeed = 100;

    private LevelManager levelManager;

    private bool circleEnable;
    private void Awake()
    {
        circleEnable = true;
        levelManager = Object.FindObjectOfType<LevelManager>();
        
    }
    void Start()
    {
        StartCoroutine(WaitLoading());
    }

    // Update is called once per frame
    void Update()
    {
        LoadingCircleEnable();
    }
    IEnumerator WaitLoading()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<CanvasGroup>().DOFade(0, 1.5f);
        yield return new WaitForSeconds(0.8f);
        circleEnable = false;
    }

    //Yükleme panelim yok olduðunda çeberim arkada iþlem görmesin diye yazdýðým metot.
    private void LoadingCircleEnable()
    {
        if (circleEnable)
        {
            loadingCircle.GetComponent<RectTransform>().Rotate(Vector3.forward * loadingSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
            levelManager.StartLevelPanel();
        }
    }
}
