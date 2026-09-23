using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lollipop;
    public GameObject chocolate;
    public GameObject candy;
    public GameObject mine;
    public GameObject clock;
    public GameObject cane;
    private GameObject spawned;
    private int score; 
    public TMP_Text scoreText;
    public TMP_Text leaderboard;
    private int mineRand = 0;
    private int clockRand = 0;
    private float spawnRate = 1f;
    private bool freeze = false;
    private bool isSpawning = true;
    private bool disableClocks = false;
    private bool started = false;


    void Start()
    {
        score = 0;
        scoreText.SetText("Score: " + score);
    }

    public void startSpawn()
    {
        randFruit(); //invokes each time in randFruit so rate can change
        started = true;
    }

    public void randFruit()
    {
        if(!freeze) //stops new fruits spawning until freeze ends
        {
            isSpawning = true;
            int num = Random.Range(0, 3);
            mineRand = Random.Range(0, 8);
            clockRand = Random.Range(0, 8); 

        

            for (int i = 0; i < num; i++)
            {
                spawnFruit();
            }

            if (mineRand == 0 || mineRand == 1)
            {
                spawnMine();
            }

            if ((clockRand == 0 || clockRand == 1) && !disableClocks) 
            {
                spawnClock();
            }

            //invokes each time in randFruit so rate can change
            spawnRate = Random.Range(0.5f,1.85f);
            Invoke("randFruit", spawnRate);
        }
        else isSpawning = false;
    }

    public void spawnMine()
    {
        float rad = Random.Range(1.05f, 1.17f);
        float angle = Random.Range(0f, 180f);
        float xpos = rad * Mathf.Cos(angle);
        float zpos = rad * Mathf.Sin(angle);
        Vector3 fruitSpawn = new Vector3(xpos, -2, zpos);

        spawned = Instantiate(mine, fruitSpawn, Quaternion.identity);
        spawned.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 630f);
        Destroy(spawned, 5);
    }

    public void spawnClock()
    {
        float rad = Random.Range(1.05f, 1.17f);
        float angle = Random.Range(0f, 180f);
        float xpos = rad * Mathf.Cos(angle);
        float zpos = rad * Mathf.Sin(angle);
        Vector3 fruitSpawn = new Vector3(xpos, -2, zpos);

        spawned = Instantiate(clock, fruitSpawn, Quaternion.identity);
        spawned.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 450f);
        Destroy(spawned, 5);
    }

    public void spawnFruit()
    {
        int fruitRand = Random.Range(0, 3);
        float rad = Random.Range(1.05f, 1.17f);
        float angle = Random.Range(0f, 180f) * Mathf.Deg2Rad;
        float xpos = rad * Mathf.Cos(angle);
        float zpos = rad * Mathf.Sin(angle); 
        Vector3 fruitSpawn = new Vector3(xpos, -2, zpos);

        

        switch (fruitRand)
        {
            case 0:
                spawned = Instantiate(lollipop, fruitSpawn, Quaternion.identity);
                spawned.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 550f);
                Destroy(spawned, 5);
                break;
            case 1:
                spawned = Instantiate(chocolate, fruitSpawn, Quaternion.identity);
                spawned.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 450f);
                Destroy(spawned, 5);
                break;
            case 2:
                spawned = Instantiate(candy, fruitSpawn, Quaternion.identity);
                spawned.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 600f);
                Destroy(spawned, 5);
                break;
        }
    }

    public void updateLeaderboard()
    { 
        string s = "High Scores: ";
        s += "\n 1. " + PlayerPrefs.GetFloat("Position1", 0) + " Points";
        s += "\n 2. " + PlayerPrefs.GetFloat("Position2", 0) + " Points";
        s += "\n 3. " + PlayerPrefs.GetFloat("Position3", 0) + " Points";
        //Debug.Log("Current Score " + score);

        leaderboard.SetText(s);
    }

    public void endLeader()
    {
        List<float> list = new List<float>();
        list.Add(PlayerPrefs.GetFloat("Position1", 0));
        list.Add(PlayerPrefs.GetFloat("Position2", 0));
        list.Add(PlayerPrefs.GetFloat("Position3", 0));
        list.Add(score);

        list.Sort((a, b) => b.CompareTo(a));

        PlayerPrefs.SetFloat("Position1", list[0]);
        PlayerPrefs.SetFloat("Position2", list[1]);
        PlayerPrefs.SetFloat("Position3", list[2]);


        PlayerPrefs.Save();

        string s = "High Scores: ";
        s += "\n 1. " + PlayerPrefs.GetFloat("Position1", 0) + " Points";
        s += "\n 2. " + PlayerPrefs.GetFloat("Position2", 0) + " Points";
        s += "\n 3. " + PlayerPrefs.GetFloat("Position3", 0) + " Points";
        leaderboard.SetText(s);
        SceneManager.LoadScene(0);
        //Application.Quit();
        

    }

    public void startFreeze()
    {
        if(freeze)
        {
            CancelInvoke("randFruit");
            StartCoroutine(FreezeCoroutine());
        }
    }

     private IEnumerator FreezeCoroutine() //waits to start new spawns
    {
        yield return new WaitForSeconds(4); //matches up with routine in freezing script
        freeze = false;
        randFruit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        updateLeaderboard();
    }

    public void setFreeze(bool f)
    {
        freeze = f;
    }

    public bool getFreeze()
    {
        return freeze;
    }

    public void addScore(int s)
    {
        score += s;
        if(score<0)
            score = 0;
        scoreText.SetText("Score: " + score);
    }

    public void increaseDifficulty()
    {
        if(started)
        {
            disableClocks = true;
            InvokeRepeating("spawnMine",1f,2f);
            InvokeRepeating("spawnMine",4f,5f);
            Debug.Log("Started Difficulty");
        }

    }

    /*public void disableCane()
    {
        cane.GetComponent<Collider>().enabled = false;
    }

    public void enableCane()
    {
        cane.GetComponent<Collider>().enabled = true;
    }*/
}
