using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public GameObject scoreTxt;
    public Rigidbody rb;
    private bool restart=false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.gameObject.name == "Multiplier2x")
        {
            
            Destroy(other.gameObject);
            ScoreController.multiplier = 2;
        }
        if (other.gameObject.name == "Multiplier4x")
        {
            Destroy(other.gameObject);
            if(ScoreController.multiplier>=2)
            { 
                ScoreController.multiplier = ScoreController.multiplier*2;
            }
            else
            {
                ScoreController.multiplier = 2;
            }
           
        }
        if (other.gameObject.tag == "Ending" && restart==false)
        {

            if (other.gameObject.name == "End2x" && ScoreController.gameEnded == false)
            {
                StartCoroutine(StopBall());
                // Debug.Log(other.name);
                ScoreController.score = ScoreController.score * 2;
                ScoreController.gameEnded = true;
                //Debug.Log(ScoreController.gameEnded);
            }
            else if (other.gameObject.name == "End3x" && ScoreController.gameEnded == false)
            {
                StartCoroutine(StopBall());
                //Debug.Log(other.name);
                ScoreController.score = ScoreController.score * 3;
                ScoreController.gameEnded = true;
            }
            else if (other.gameObject.name == "End5x" && ScoreController.gameEnded == false)
            {
                StartCoroutine(StopBall());
                //Debug.Log(other.name);
                ScoreController.score = ScoreController.score * 5;
                ScoreController.gameEnded = true;
            }
            else
            {

            }

            if (ScoreController.gameEnded == true)
            {
                //Debug.Log("I'm here");
                ScoreController.showString = "Level Completed! \nScore:" + ScoreController.score + "\nRestarting in \n5 Seconds.";  
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                ScoreController.score = 0;
                ScoreController.multiplier = 1;
                StartCoroutine(GameOverCoroutine());
                restart = true;
                
            }

        }
        else
        {
            var matColor = other.gameObject.GetComponent<Renderer>().material.color;  
            gameObject.GetComponent<MeshRenderer>().material.color =matColor ;
            
        }
    }
    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "Start")
        {
            ScoreController.score = 0;
            ScoreController.multiplier = 1;
            ScoreController.gameEnded = false;
        }
        if (col.gameObject.tag == "Ground")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            ScoreController.score = 0;
            ScoreController.multiplier = 1;
        }
        else if (col.gameObject.tag == "Roof")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,col.gameObject.transform.position.y-0.2f, gameObject.transform.position.z);
        }
        else if (col.gameObject.tag == "StickyObstacles")
        {
            rb.angularVelocity = new Vector3(0, 0);
            rb.velocity = new Vector3(0f , 0f, 0f);
            //StartCoroutine(stopBall());
            //rb.velocity = new Vector3(0.5f, 0.5f, 0.5f);
            //
            //StartCoroutine(stopBall());

            //rb.inertiaTensorRotation = new Quaternion(0.2f, 0.2f,0.2f, 1);
        }
        else if(col.gameObject.name=="Window")
        {

        }
      


    }
    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSecondsRealtime(5);
        ScoreController.gameEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator StopBall()
    {
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0);
    }

}
