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
    public string FoodName;     //���� �̸�
    [TextArea]
    public string FoodInfo;     //���� ����
    public FoodType foodtype;   //Ÿ��
    public Sprite FoodSprite;   //��������Ʈ
    public int Price;
    public Food[] Ingredients;  //��� (��� ������ ���� ��ũ 1���� 1��)


}
