using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour
{
    Image image;
    void Start()
    {
        image=GetComponent<Image>();
    }

    public void changeimg(Sprite pimg){
        image.sprite=pimg;
    }

    public void doneimg(){
        Color tem=image.color;
        tem.a=0.5f;
        image.color=tem;
    }

}
