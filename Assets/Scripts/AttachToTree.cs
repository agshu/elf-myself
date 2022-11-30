using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToTree : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject tree;
    private Collider treeCollider;
    private Vector3 closestPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        treeCollider = tree.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // float distance = Vector3.Distance (rb.transform.position, tree.transform.position);
        if (Application.platform == RuntimePlatform.Android) {

            closestPoint = treeCollider.ClosestPointOnBounds(rb.transform.position);
            float distance = Vector3.Distance(closestPoint, rb.transform.position);
            
            //when dropped => kolla om distans < 0.1. om ja => stäng av gravitation och placera på closestPoint
            // om inte <0.1 ha kvar gravity
            if (distance < 0.01) {
                rb.transform.position = closestPoint;
                //rb.useGravity = false;
                rb.isKinematic = true;
                //rb.constraints.FreezeRotation = true;
                //rb.constraints.FreezePosition = true;
                //rb.constraints = RigidbodyConstraints.FreezePosition;
            } else {
                    //rb.useGravity = true;
                    rb.isKinematic = false;
                    //rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
