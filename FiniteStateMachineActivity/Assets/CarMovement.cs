using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    //variable for controlling speed
    [SerializeField] private float speed;
    //variable for controlling current acceleration
    [SerializeField] private float acceleration;

    [SerializeField] private float maxAcceleration;
    [SerializeField] private float maxReverse;


    //variable for the direction of acceleration
    private bool forwardGear = true;

    //variable for controlling steering force
    private Vector3 steering;

    //reference to attached rigidbody
    private Rigidbody rbody;

    [SerializeField] CarButton carButton;


    private void Awake()
    {
            if(!TryGetComponent<Rigidbody>(out rbody))
            {
                Debug.Log("You need a Rigidbody");
            }
    

        acceleration = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        //subscribe to acceleration and decelleration events
        CarButton.changeAccelEvent += Accelerate;
        //subscribe to steering events
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 move = transform.forward * speed * acceleration * Time.deltaTime;
            move = move.normalized;
            rbody.velocity = move;
    }

    private void Accelerate(float _accel)
    {
        //change value of accel depending on current direction.
        //value of acceleration
        //Debug.Log("Accelerating");
        acceleration += _accel;
        acceleration = Mathf.Clamp(acceleration, maxReverse, maxAcceleration);
    }
}
