using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    
    [SerializeField]public Text ScoreText;
    [SerializeField]public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDistance();
    }
    private void ScoreDistance()
    {
        ScoreText.text = "" + playerPosition.position.x.ToString("0");
    }

}
