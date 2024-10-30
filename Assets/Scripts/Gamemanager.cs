using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    public static Gamemanager Instance { get; private set; }

    [SerializeField]
    UIManager UIManager;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ToggleDeathScreen(bool c) 
    {
        UIManager.Active(c);
    
    
    }





    private void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
