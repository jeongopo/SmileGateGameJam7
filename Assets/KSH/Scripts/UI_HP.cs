using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    public Image[] images;
    private void Update()
    {
        for(int i = 0; i < DataManager.instance.fullHp; i++)
        {
            if(i < DataManager.instance.hp)
                images[i].gameObject.SetActive(true);
            else 
                images[i].gameObject.SetActive(false);
        }
    }
}
