using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShow : MonoBehaviour
{
    public static UIShow instance;

    [SerializeField]
    private Text ReloadUI;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeReload(string text) 
    {
        ReloadUI.text = text;
    }

}
