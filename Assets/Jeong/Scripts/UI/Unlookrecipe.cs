using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlookrecipe : MonoBehaviour
{
    public Food[] food_twostars;
    public Food[] food_threestars;

    Image[] foodslots;

    void Start(){
        foodslots=GetComponentsInChildren<Image>();
    }

    public void setfoodlist(int num){ //스테이지 넘버를 전달
        if(num==2) setimg(food_twostars);
        else if(num==3) setimg(food_threestars);
    }

    void setimg(Food[] pfood){
        for(int i=0;i<pfood.Length;i++){
            foodslots[i].sprite=pfood[i].FoodSprite;
        }
    }

}
