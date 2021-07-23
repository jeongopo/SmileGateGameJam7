using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "New Food/Food")]
public class Food : ScriptableObject
{
    public string FoodName;     //���� �̸�
    [TextArea]
    public string FoodInfo;     //���� ����
    public FoodType foodtype;   //Ÿ��
    public Sprite FoodSprite;   //��������Ʈ

    public Food[] Ingredients;  //��� (��� ������ ���� ��ũ 1���� 1��)

    public enum FoodType
    {
        Drink,
        Ingredients
    }
}
