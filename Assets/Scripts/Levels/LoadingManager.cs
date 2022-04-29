using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LoadingManager : MonoBehaviour
{
    [SerializeField]private GameObject loadingCircle;

    [SerializeField] private int loadingSpeed = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loadingCircle.GetComponent<RectTransform>().Rotate(Vector3.forward* loadingSpeed *Time.deltaTime);
        Debug.Log("alpha kapalý iken çalýþýyor mu ?");
    }
}
