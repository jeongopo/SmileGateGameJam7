using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredient : MonoBehaviour
{
    public Food IGD;
    Image image;
    private void Start() {
        image=this.gameObject.GetComponent<Image>();
    }

    public void setIGD(Food setIGD){
        IGD=setIGD;
        image.sprite=IGD.FoodSprite;
    }

    public void getIGD(){
        Debug.Log("IGD name : "+IGD.FoodName);
    }

}
