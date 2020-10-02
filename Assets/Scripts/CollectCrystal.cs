using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCrystal : MonoBehaviour
{
    public int score;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="PlayerBall")
        {
            //Debug.Log(other.name);
            
            ScoreController.score += 10 * ScoreController.multiplier;
            Destroy(gameObject);
        }
        
    }
}
