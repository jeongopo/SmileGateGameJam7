using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] GameObject Gameinfo_obj;

    public void Show_Obj()
    {
        Gameinfo_obj.SetActive(true);
    }

    public void Hide_Obj()
    {
        Gameinfo_obj.SetActive(false);
    }
}
