using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField] private Text timeText;
    int kalanSure;
    bool sureSaysinmi;
    // Start is called before the first frame update
    void Start()
    {
        kalanSure = 10;
        sureSaysinmi = true;

        StartCoroutine(SureTimerRoutine());
    }
    
    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                timeText.text = "0"+kalanSure.ToString();
            }
            else
            {
                timeText.text = kalanSure.ToString();
            }
            if (kalanSure <= 0)
            {
                sureSaysinmi = false;
                timeText.text = "";
            }
            kalanSure--;
        }
    }
}
