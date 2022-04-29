using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingPanel;
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("whoGame"));
    }
}
