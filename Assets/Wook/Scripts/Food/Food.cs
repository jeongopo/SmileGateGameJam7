using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum FoodType
    {
        Drink,
        Ingredients_Main,
        Ingredients_Sub
    }
[CreateAssetMenu(fileName = "New Food", menuName = "New Food/Food")]
public class Food : ScriptableObject
{
    public string FoodName;     //음식 이름
    [TextArea]
    public string FoodInfo;     //음식 정보
    public FoodType foodtype;   //타입
    public Sprite FoodSprite;   //스프라이트
    public int Price;
    public Food[] Ingredients;  //재료 (재료 개수에 따라 랭크 1개면 1성)


}
