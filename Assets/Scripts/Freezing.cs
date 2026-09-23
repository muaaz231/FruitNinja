using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Freezing : MonoBehaviour
{
    private Main m;
    private Rigidbody rb;
    private bool isFreezing = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m = GameObject.Find("Manager").GetComponent<Main>();
    }

    public void freezetime()
    {
        StartCoroutine(FreezeCoroutine());
    }

    private IEnumerator FreezeCoroutine()
    {
        isFreezing = true;
        rb.constraints = RigidbodyConstraints.FreezePosition; //freezes candy by making it kinematic for 5 seconds
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(4);
        rb.constraints = RigidbodyConstraints.None; //freezes candy by making it kinematic for 5 seconds
        rb.useGravity = true;
        isFreezing = false;
    }





    // Update is called once per frame
    void Update()
    {
        if (m.getFreeze() && !isFreezing && transform.position.y >= 1.5f)
        {
            freezetime();
        }
    }
}
