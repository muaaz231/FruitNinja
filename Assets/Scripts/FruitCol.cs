using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FruitCol : MonoBehaviour
{
    public GameObject candyType;
    public GameObject particle;
    public GameObject explode;
    private int score = 0;
    private Main m;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       m = GameObject.Find("Manager").GetComponent<Main>();
       rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cane"))
        {

            if (gameObject.tag == "Mine")
            {
                candyType.SetActive(false); //sets false in case it doesnt destroy fast enough
                Destroy(candyType);
                GameObject expl = Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(expl, 1);
                m.addScore(-5);
                return;
            }
          

            GameObject fruit1 = Instantiate(candyType, new Vector3(transform.position.x-0.25f, transform.position.y, transform.position.z), transform.rotation);
            GameObject fruit2 = Instantiate(candyType, new Vector3(transform.position.x+0.25f,transform.position.y,transform.position.z), transform.rotation);

            Vector3 hitPos = collision.contacts[0].point;
            GameObject particleSpawn = Instantiate(particle, hitPos, Quaternion.identity);

            fruit1.transform.localScale = transform.localScale * 0.5f;
            fruit2.transform.localScale = transform.localScale * 0.5f;


            Destroy(gameObject);
            Destroy(particleSpawn, 1); 
            Destroy(fruit1, 1);
            Destroy(fruit2, 1);

            if (gameObject.tag != "Clock")
            {
                m.addScore(1);
            }
            else
            { 
               m.setFreeze(true);
               m.startFreeze();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
