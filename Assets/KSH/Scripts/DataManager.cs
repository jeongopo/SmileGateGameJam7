using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    public int defaultPoint;
    public List<int> clearPoint = new List<int>();
    [Space]
    public Dictionary<int, List<int>> successPoint; //손님의 주문을 성공적으로 수행했을때 보상
    public Dictionary<int, List<int>> DrinkNumberPercentage; //갯수
    public Dictionary<int, List<int>> DrinkRankPercentage; //등급
    public List<string> Drink_1 = new List<string>();//1등급 음료들
    public List<string> Drink_2 = new List<string>();//2등급 음료들
    public List<string> Drink_3 = new List<string>();//3등급 음료들
    [Space]
    public int customerTimer;
    public int currentStageNumber;
    public int currentStagePoint;
    public bool isStagePlaying = false;

    Dictionary<int, int> ReadIntIntFile(string file)
    {
        Dictionary<int,int> tmp = new Dictionary<int, int>();
        StreamReader sr = new StreamReader(Application.dataPath + "/" + file);

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            string[] data_values = data_String.Split(',');
            tmp.Add(int.Parse(data_values[0]), int.Parse(data_values[1]));
        }
        return tmp;
    }

    Dictionary<string, string> ReadStringStringFile(string file)
    {
        Dictionary<string,string> tmp = new Dictionary<string, string>();
        StreamReader sr = new StreamReader(Application.dataPath + "/" + file);

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            string[] data_values = data_String.Split(',');
            tmp.Add(data_values[0], data_values[1]);
        }
        return tmp;
    }

    Dictionary<int, List<int>> ReadSuccessPointFile(string file)
    {
        Dictionary<int, List<int>> tmp = new Dictionary<int, List<int>>();
        StreamReader sr = new StreamReader(Application.dataPath + "/" + file);

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            string[] data_values = data_String.Split(',');
            List<int> listTmp = new List<int>();
            for(int i = 0 ; i < 3; i++)
            {
                listTmp.Add(int.Parse(data_values[i + 1]));
            }
            tmp.Add(int.Parse(data_values[0]), listTmp);
        }
        return tmp;
    }

    Dictionary<int, List<string>> ReadDrinkFile(string file)
    {
        Dictionary<int, List<string>> tmp = new Dictionary<int, List<string>>();
        StreamReader sr = new StreamReader(Application.dataPath + "/" + file);

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            string[] data_values = data_String.Split(',');
            List<string> listTmp = new List<string>();
            for(int i = 1 ; i < data_values.Length; i++)
            {
                listTmp.Add(data_values[i]);
            }
            tmp.Add(int.Parse(data_values[0]), listTmp);
        }
        return tmp;
    }

    List<string> ReadStringFile(string file)
    {
        List<string> tmp = new List<string>();
        StreamReader sr = new StreamReader(Application.dataPath + "/" + file);

        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_String = sr.ReadLine();
            if (data_String == null)
            {
                endOfFile = true;
                break;
            }
            string[] data_values = data_String.Split(',');
            tmp.Add(data_values[0]);
        }
        return tmp;
        
    }

    void DataSetting()
    {
        //todo//
        DrinkNumberPercentage = ReadSuccessPointFile("DrinkNumberPercentage.csv");
        DrinkRankPercentage = ReadSuccessPointFile("DrinkRankPercentage.csv");
        Drink_1 = ReadStringFile("Drink_1.csv");
        Drink_2 = ReadStringFile("Drink_2.csv");
        Drink_3 = ReadStringFile("Drink_3.csv");
        //successPoint = ReadSuccessPointFile(파일이름);
    }

    private void Awake() 
    {
        if(instance == null)
        {
            DataSetting();
            instance = this;
        }

    }

    public int ChangeStage(int _stageNumber) //스테이지를 변경할 때 호출해야 하는 함수 (변경된 스테이지 번호를 return)
    {
        currentStageNumber = _stageNumber;
        return currentStageNumber;
    }

    void CheckStageClear() //점수 흭득시마다 클리어 확인
    {
        if(currentStagePoint.Equals(clearPoint[currentStageNumber]))
        {
            //todo..
            //StageClear();
            ResetStage();
        }
    }

    public void AcheiveStagePoint(int _OrderSuccessCount) //점수 흭득시 콜백함수
    {
        currentStagePoint += _OrderSuccessCount;
        CheckStageClear();
    }

    public void ResetStage() //스테이지 종료시 콜백함수
    {
        isStagePlaying = false;
        currentStagePoint = 0;
    }

    public float GetCustomerTimer(int _orderCount) //손님 제한시간 생성
    {
        return customerTimer * _orderCount;
    }

    public int GetSuccessPoint(int _successOrder) //손님 보상 점수 생성
    {
        return successPoint[currentStageNumber][_successOrder];
    }

    public List<string> GetPossibleOrderDrink(ref int _orderCount)//손님의 주문 생성
    {
        List<string> tmp = new List<string>();
        int randomTmp = Random.Range(0, 10);
        int count;

        if(randomTmp <= DrinkNumberPercentage[currentStageNumber][0])
        {
            count = 1;
        }
        else if(randomTmp <= DrinkNumberPercentage[currentStageNumber][1])
        {
            count = 2;
        }
        else 
        {
            count = 3;
        }

        for(int i = 0 ; i < count; i++)
        {
            randomTmp = Random.Range(0, 10);

            if (randomTmp <= DrinkRankPercentage[currentStageNumber][0])
            {
                tmp.Add(Drink_1[Random.Range(0, Drink_1.Count)]);
            }
            else if (randomTmp <= DrinkRankPercentage[currentStageNumber][1])
            {
                tmp.Add(Drink_2[Random.Range(0, Drink_2.Count + 1)]);
            }
            else
            {
                tmp.Add(Drink_3[Random.Range(0, Drink_3.Count + 1)]);
            }
        }
        _orderCount = count;
        return tmp;
    }

    public void UsePoint(int _Point)
    {
        currentStagePoint += _Point;
    }
}
