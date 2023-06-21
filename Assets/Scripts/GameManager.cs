using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private InGameRanking ig;

    private GameObject[] runner;
    List<RankingSystem> sortArray= new List<RankingSystem>();

    private void Awake()
    {
        instance = this;
        runner = GameObject.FindGameObjectsWithTag("Runner");
        ig = FindObjectOfType<InGameRanking>();
    }

    void Start()
    {
        for (int i = 0; i < runner.Length; i++)
        {
            sortArray.Add(runner[i].GetComponent<RankingSystem>());
        }
    }

    
    void Update()
    {
        CalculateRanking();
    }

    void CalculateRanking()
    {
        sortArray = sortArray.OrderBy(x => x.distance).ToList();
        sortArray[0].rank = 1;
        sortArray[1].rank = 2;
        sortArray[2].rank = 3;
        sortArray[3].rank = 4;
        sortArray[4].rank = 5;
        sortArray[5].rank = 6;
        sortArray[6].rank = 7;

        ig.a = sortArray[6].name;
        ig.b = sortArray[5].name;
        ig.c = sortArray[4].name;
        ig.d = sortArray[3].name;
        ig.e = sortArray[2].name;
        ig.f = sortArray[1].name;
        ig.g = sortArray[0].name;
    }
}
