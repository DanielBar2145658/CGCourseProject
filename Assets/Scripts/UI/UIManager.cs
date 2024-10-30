using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject DeadScreen;

    public void Active(bool s)
    {
        DeadScreen.SetActive(s);

    }
    
}
