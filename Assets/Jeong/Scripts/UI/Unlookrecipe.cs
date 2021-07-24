using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlookrecipe : MonoBehaviour
{
    public Food[] food_twostars;
    public Food[] food_threestars;

    public Image[] foodslots;

    void Start(){
        //foodslots=GetComponentsInChildren<Image>();
    }

    public void setfoodlist(int num){ //스테이지 넘버를 전달
        if(num==2) {
            for(int i=0;i<food_twostars.Length;i++){
                Debug.Log("확인 : "+food_twostars[i].FoodSprite);
                foodslots[i].sprite=food_twostars[i].FoodSprite;
            }
        }else if(num==3){
            for(int i=0;i<food_threestars.Length;i++){
            foodslots[i].sprite=food_threestars[i].FoodSprite;
            }
        }
    }

    // void setimg(Food[] pfood){
    //     for(int i=0;i<pfood.Length;i++){
    //         foodslots[i].sprite=pfood[i].FoodSprite;
    //     }
    // }

}
