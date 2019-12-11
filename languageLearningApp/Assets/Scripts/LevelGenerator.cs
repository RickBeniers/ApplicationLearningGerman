using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_SPLIT_PART = 1000f;
    public Transform Levelpart_Split;

    [SerializeField] private string platform1 = "platform1";
    [SerializeField] private string platform2 = "platform2";
    [SerializeField] private Transform levelpart_Start;
    [SerializeField] private Transform chosenLevelPart;
    [SerializeField] private Transform lastLevelPartTransform;
    [SerializeField] private List<Transform> levelpartList;
    [SerializeField] private List<string> levelplatformList;
    [SerializeField] private Vector3 lastEndPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private float TimeLeft = 10;

    private void Awake()
    {
        //Debug.Log(levelpart_Start.Find("platform").Find("platformEndPosition").position);
        lastEndPosition = levelpart_Start.Find("platform").Find("platformEndPosition").position;
        SpawnLevelpart();
        SpawnLevelpart();
        int startingSpawnLevelPart = 5;
        for(int i=0; i<startingSpawnLevelPart; i++)
        {
            SpawnLevelpart();
        }
        
    }
    private void Start()
    {
        levelplatformList.Add(platform1);
        levelplatformList.Add(platform2);
    }
    private void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //spawn level part
            SpawnLevelpart();
        }
        TimeLeft -= Time.deltaTime;
    }
    private void chooseLevelpart()
    {
       chosenLevelPart = levelpartList[Random.Range(0, levelpartList.Count)];
    }
    private void SpawnLevelpart()
    {
        chooseLevelpart();
        //&& Vector3.Distance(player.transform.position, lastEndPosition) > PLAYER_DISTANCE_SPAWN_LEVEL_SPLIT_PART

        float distance = Vector3.Distance(player.transform.position, lastEndPosition);
            if (chosenLevelPart == Levelpart_Split && TimeLeft < 0)
            {
                //Debug.Log("Split");
                lastLevelPartTransform = SpawnLevelParts(chosenLevelPart, lastEndPosition);
                string chosenplatformSplitPart = levelplatformList[Random.Range(0, levelplatformList.Count)];
                lastEndPosition = lastLevelPartTransform.Find(chosenplatformSplitPart).Find("platformEndPosition").position;
                TimeLeft = 10;
            }
            else
            {
                //Debug.Log("chose platform again");
                chosenLevelPart = levelpartList[0];
                lastLevelPartTransform = SpawnLevelParts(chosenLevelPart, lastEndPosition);
                lastEndPosition = lastLevelPartTransform.Find("platform").Find("platformEndPosition").position;
            }
    }
    private Transform SpawnLevelParts(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
