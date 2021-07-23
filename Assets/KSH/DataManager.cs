using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public Dictionary<int, int> clearPoint; //스테이지 클리어까지 목표점수
    public Dictionary<int, List<int>> successPoint; //손님의 주문을 성공적으로 수행했을때 보상
    // public Dictionary<string, string> drinkExplanation; //음료 이름, 설명

    public int currentStageNumber;
    public int currentStagePoint;
    public bool isStagePlaying = false;

    private void Awake() 
    {
        if(instance == null)
            instance = this;
    }

    List<Dictionary<int, int>> ReadIntIntFile(string file)
    {
        List<Dictionary<int,int>> list = new List<Dictionary<int, int>>();
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
            list.Add(int.Parse(data_values[0]), int.Parse(data_values[1]));
        }
        return list;
    }

    List<Dictionary<string, string>> ReadStringStringFile(string file)
    {
        List<Dictionary<string,string>> list = new List<Dictionary<string, string>>();
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
            list.Add(int.Parse(data_values[0]), int.Parse(data_values[1]));
        }
        return list;
    }

    List<Dictionary<string, List<int>>> ReadSuccessPointFile(string file)
    {
        List<Dictionary<string,List<int>>> list = new List<Dictionary<string, List<int>>>();
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
            List<int> tmp = new List<int>();
            for(int i = 0 ; i < 3; i++)
            {
                tmp.Add(int.Parse(data_values[i + 1]));
            }
            list.Add(data_values[0], tmp);
        }
        return list;
    }

    void DataSetting()
    {
        //todo//
        //clearPoint = ReadIntIntFile(파일이름);
        //successPoint = ReadSuccessPointFile(파일이름);
    }

    void Start() 
    {
        DataSetting();
    }

    public int ChangeStage(int _stageNumber) //스테이지를 변경할 때 호출해야 하는 함수 (변경된 스테이지 번호를 return)
    {
        currentStageNumber = _stageNumber;
        return currentStageNumber;
    }

    void CheckStageClear()
    {
        if(currentStagePoint.Equals(clearPoint[currentStageNumber]))
        {
            //Stage Clear
            //todo..
        }
    }

    public int AcheiveStagePoint(int _OrderSuccessCount)
    {
        currentStagePoint += _OrderSuccessCount;
        CheckStageClear();
    }

    public void ResetStage()
    {
        isStagePlaying = false;
        currentStagePoint = 0;
    }
}
