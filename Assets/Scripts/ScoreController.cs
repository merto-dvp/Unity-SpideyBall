using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameObject scoreTxt;
    public static int multiplier=1;
    public static int score;
    public static bool gameEnded = false;
    public static string showString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (gameEnded == false)
        {
            showString="Score:" + score + "\n" + multiplier + "x";
            scoreTxt.GetComponent<Text>().text = showString;
        }
        else
        {
            scoreTxt.GetComponent<Text>().text = showString;
        }
            
    }
}
