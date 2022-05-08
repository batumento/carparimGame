using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheckedManager : MonoBehaviour
{
    public void SoundOpen()
    {
        PlayerPrefs.SetInt("soundStatus", 1);
    }
    public void SoundClosed()
    {
        PlayerPrefs.SetInt("soundStatus", 0);
    }
}
