using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Select_ingredient : MonoBehaviour
{
    [SerializeField] Button B_Main_Ingredient;
    [SerializeField] Food F_Main_Food;
    [SerializeField] Button[] B_Sub_Ingredient;
    [SerializeField] Food[] F_Sub_Food = new Food[3];
    [SerializeField] Material Select;
    [SerializeField] Material Idle_Material;
    [SerializeField] Image Making_Image;
    [SerializeField] Text Error;
    [SerializeField] GameObject Error_Obj;
    int currentStageNumber;
    int SubFood_Count = 0;
    
    

    IEnumerator Change_Material()
    {
        Making_Image.material = Select;

        yield return new WaitForSeconds(1f);
        Making_Image.material = Idle_Material;
        yield break;

    }
    private void Start()
    {
        currentStageNumber = DataManager.instance.currentStageNumber;
    }

    void Show_ErrorText(string _text)
    {
        Error_Obj.SetActive(true);
        Error.text = _text;

        Invoke("Hide_ErrorText", 0.5f);
    }

    void Hide_ErrorText()
    {
        Error_Obj.SetActive(false);
    }


    //����� ����
    public void Main_Ingredient_Select(Food food)
    {
        if (Drink.IsCreatFood)
            return;
        if (food.foodtype != FoodType.Ingredients_Main)
            return;
        if (F_Main_Food != null)
        {
            Show_ErrorText("������ �ִ� 1�������� ���� �� �ֽ��ϴ�.");
            //Debug.Log("������ �ִ� 1�������� ���� �� �ֽ��ϴ�.");
            return;
        }

        F_Main_Food = food;
        DataManager.instance.UsePoint(-F_Main_Food.Price);
        Change_button(B_Main_Ingredient, food, 1);
        StartCoroutine(Change_Material());
    }

    //����� ����
    public void Main_Ingredient_UnSelect(bool isCreat = false)
    {
        if (F_Main_Food == null)
            return;
        if(isCreat)
            DataManager.instance.UsePoint(F_Main_Food.Price);
        F_Main_Food = null;
        Change_Alpha(B_Main_Ingredient, 0);
    }

    //����� ����
    public void Sub_Ingredient_Select(Food food)
    {
        if (Drink.IsCreatFood)
            return;
        if (food.foodtype != FoodType.Ingredients_Sub)
            return;
        if (SubFood_Count >= currentStageNumber) //���� üũ
        {
            string text = "������ �ִ� " + currentStageNumber + "�������� ���� �� �ֽ��ϴ�.";
            Show_ErrorText(text);
            Debug.Log("������ �ִ� " + currentStageNumber + "�������� ���� �� �ֽ��ϴ�.");
            return;
        }

        for (int i = 0; i < 2; i++) //�ߺ�üũ
        {
            if (F_Sub_Food[i] == food)
            {
                Show_ErrorText("�ߺ��� ���� ���� �� �����ϴ�.");
                //Debug.Log("�ߺ��� ���� ���� �� �����ϴ�.");
                return;
            }
        }

        F_Sub_Food[SubFood_Count] = food;
        Change_button(B_Sub_Ingredient[SubFood_Count], food, 1);
        DataManager.instance.UsePoint(-F_Sub_Food[SubFood_Count].Price);
        StartCoroutine(Change_Material());
        SubFood_Count++;
    }

    //����� ����
    public void Sub_Ingredient_UnSelect(int num, bool isCreat = false)
    {
        if (F_Sub_Food[num] == null)
            return;
        if(isCreat)
            DataManager.instance.UsePoint(F_Sub_Food[num].Price);
        F_Sub_Food[num] = null;
        Change_Alpha(B_Sub_Ingredient[num], 0);

        if (num+1 != SubFood_Count)//�߰� ��Ḧ �������� ���
            Swap_sub(num);
        SubFood_Count--;


    }

    public void Button_Sub_Ingredient_UnSelect(int num)
    {
        if (F_Sub_Food[num] == null)
            return;

        DataManager.instance.UsePoint(F_Sub_Food[num].Price);
        F_Sub_Food[num] = null;
        Change_Alpha(B_Sub_Ingredient[num], 0);

        if (num + 1 != SubFood_Count)//�߰� ��Ḧ �������� ���
            Swap_sub(num);
        SubFood_Count--;


    }

    //����� ��ġ ����
    void Swap_sub(int Unselect)
    {
        int Swap_Count = 0;
        switch (SubFood_Count)
        {
            case 2:
                Swap_Count = 1;
                break;

            case 3:
                if (Unselect == 0)
                    Swap_Count = 2;
                else if (Unselect == 1)
                    Swap_Count = 1;
                break;
        }
        for(int i = Unselect; i< Unselect+Swap_Count; i++)
        {
            F_Sub_Food[i] = F_Sub_Food[i + 1];
            F_Sub_Food[i + 1] = null;
            Change_button(B_Sub_Ingredient[i], F_Sub_Food[i], 1);
            Change_Alpha(B_Sub_Ingredient[i + 1], 0);
        }

    }

    void Change_button(Button button, Food food, float alpha)
    {
        button.image.sprite = food.FoodSprite;
        Change_Alpha(button, alpha);
    }

    void Change_Alpha(Button button, float alpha)
    {
        Color color = button.image.color;
        color.a = alpha;
        button.image.color = color;
        if (alpha <= 0)
        
            button.interactable = false;      
        else
            button.interactable = true;

    }

    public Food Return_Main()
    {
        return F_Main_Food;
    }

    public Food[] Return_Sub()
    {
        return F_Sub_Food;
    }

    public void Select_ingredient_Reset()
    {
        int deleteCount = SubFood_Count;
        Main_Ingredient_UnSelect(false);
        for (int i = 0; i < deleteCount; i++)
            Sub_Ingredient_UnSelect(0, false);
    }
}
