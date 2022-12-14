using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToTree : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject tree;
    private Collider treeCollider;
    private Vector3 closestPoint;
    private int boolean = 0;
    
    // Start is called before the first frame update
    void Start()
    {
       // var boolean = false;
        rb = GetComponent<Rigidbody>();
        treeCollider = tree.GetComponent<Collider>();
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            boolean = 1;
            //rb.isKinematic = true;
            //rb.constraints = RigidbodyConstraints.FreezeAll;
            //rb.useGravity = false;
            //rb.isKinematic = true;
        } else {
            boolean = 0;
        }
        /*else if (other.gameObject.CompareTag("Hands"))  {
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.None;
            //rb.useGravity = true;
            //rb.isKinematic = false;
        }*/

    // Update is called once per frame
    void Update()
    {
        // float distance = Vector3.Distance (rb.transform.position, tree.transform.position);
        if (Application.platform == RuntimePlatform.Android) {
            //rb.useGravity = true;
            //rb.isKinematic = false;
            closestPoint = treeCollider.ClosestPointOnBounds(rb.transform.position);
            float distance = Vector3.Distance(closestPoint, rb.transform.position);
            
            //when dropped => kolla om distans < 0.1. om ja => stäng av gravitation och placera på closestPoint
            // om inte <0.1 ha kvar gravity
            if (distance < 0.0001) {
                rb.transform.position = closestPoint;
                //rb.useGravity = true;
                rb.isKinematic = true;
                //rb.constraints.FreezeRotation = true;
                //''rb.constraints.FreezePosition = true;
                rb.constraints = RigidbodyConstraints.FreezePosition;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            } else if (distance > 0.0001 && distance < 0.8) {
                rb.isKinematic = false;
                //rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
