using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject DeadScreen;

    [SerializeField]
    GameObject WinScreen;

    public void Active(bool s)
    {
        DeadScreen.SetActive(s);

    }
    public void WinScreenUI(bool s)
    {
        WinScreen.SetActive(s);

    }

}
