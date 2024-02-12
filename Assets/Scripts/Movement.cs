using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float handSpeed;
    public float rightHandPos = 0.0f;
    bool rightHandGrabbed = false;
    bool leftHandGrabbed = false;
    public float leftHandPos = 0.0f;
    float maxHandPos = 0.5f;
    public float forwardForce = 10f;
    public float turnTorque = 5f;

    public Transform rightHandTransform;
    public Transform leftHandTransform;


    public
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        move_2();
    }

    void move_1()
    {
        this.rightHandGrabbed = Input.GetKey("l");
        this.leftHandGrabbed = Input.GetKey("a");
        if (Input.GetKey("i") && this.rightHandPos < this.maxHandPos)
        {
            this.rightHandPos += this.handSpeed;
            if (rightHandGrabbed)
            {
                rb.AddForce(transform.forward * forwardForce);
                rb.AddRelativeTorque(transform.up * -turnTorque);
            }
        }
        else if (Input.GetKey("k") && this.rightHandPos > (0 - this.maxHandPos))
        {
            this.rightHandPos -= this.handSpeed;
            if (this.rightHandGrabbed)
            {
                rb.AddForce(transform.forward * -forwardForce);
                rb.AddRelativeTorque(transform.up * turnTorque);
            }
        }



        if (Input.GetKey("w") && this.leftHandPos < this.maxHandPos)
        {
            this.leftHandPos += this.handSpeed;
            if (this.leftHandGrabbed)
            {
                rb.AddForce(transform.forward * forwardForce);
                rb.AddRelativeTorque(transform.up * turnTorque);
            }
        }
        else if (Input.GetKey("s") && this.leftHandPos > (0 - this.maxHandPos))
        {
            this.leftHandPos -= this.handSpeed;
            if (this.leftHandGrabbed)
            {
                rb.AddForce(transform.forward * -forwardForce);
                rb.AddRelativeTorque(transform.up * -turnTorque);
            }
        }
    }

    void move_2()
    {
        this.rightHandGrabbed = Input.GetKey("l");
        this.leftHandGrabbed = Input.GetKey("a");
        bool rightF =false, rightB =false, leftF = false, leftB = false;
        if (Input.GetKey("i") && this.rightHandPos < this.maxHandPos)
        {
            this.rightHandPos += this.handSpeed;
            if (rightHandGrabbed)
            {
                rightF = true;
            }
        }
        else if (Input.GetKey("k") && this.rightHandPos > (0 - this.maxHandPos))
        {
            this.rightHandPos -= this.handSpeed;
            if (this.rightHandGrabbed)
            {
                rightB = true;
            }
        }



        if (Input.GetKey("w") && this.leftHandPos < this.maxHandPos)
        {
            this.leftHandPos += this.handSpeed;
            if (this.leftHandGrabbed)
            {
                leftF = true;
            }
        }
        else if (Input.GetKey("s") && this.leftHandPos > (0 - this.maxHandPos))
        {
            this.leftHandPos -= this.handSpeed;
            if (this.leftHandGrabbed)
            {
                leftB = true;
            }
        }
        if (rightF){
            if (leftF) {
                rb.AddForce(transform.forward * forwardForce);
                rb.AddForce(transform.forward * forwardForce);
            }
            else if (leftB){
                rb.AddRelativeTorque(transform.up * -turnTorque);
                rb.AddRelativeTorque(transform.up * -turnTorque);
            }
            else {
                rb.AddForce(transform.forward * forwardForce);
                rb.AddRelativeTorque(transform.up * -turnTorque);
            }
        }
        else if (rightB){
            if (leftF) {
                rb.AddRelativeTorque(transform.up * turnTorque);                
                rb.AddRelativeTorque(transform.up * turnTorque);
            }
            else if (leftB){
                rb.AddForce(transform.forward * -forwardForce);
                rb.AddForce(transform.forward * -forwardForce);
            }
            else {
                rb.AddForce(transform.forward * -forwardForce);
                rb.AddRelativeTorque(transform.up * turnTorque);
            }
        }
        else {
            if (leftF) {
                rb.AddForce(transform.forward * forwardForce);
                rb.AddRelativeTorque(transform.up * turnTorque);
            }
            else if (leftB){
                rb.AddForce(transform.forward * -forwardForce);
                rb.AddRelativeTorque(transform.up * -turnTorque);
            }
        }
        leftHandTransform.localPosition = new Vector3 (leftHandTransform.localPosition.x, leftHandTransform.localPosition.y, leftHandPos);
        rightHandTransform.localPosition = new Vector3 (rightHandTransform.localPosition.x, rightHandTransform.localPosition.y, rightHandPos);
    }
}


