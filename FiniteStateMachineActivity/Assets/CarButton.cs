using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/* Scripted created by 
 * Last updated 20/03/2023
 * Script attached to a custom UI object (button) and controls
 * the acceleration of a car object in the scene
 * 
 */

public class CarButton : MonoBehaviour
{
    //variable for event system
    [SerializeField] private EventSystem eventSystems;

    //variable for graphic raycaster
    [SerializeField] private GraphicRaycaster gRaycaster;

    [SerializeField] private float accelRate;

    //variable for pointer data
    private PointerEventData pData;

    //event for changing car acceleration
    public delegate void ChangeAccel(float accel);
    public static ChangeAccel changeAccelEvent;

    private Image buttonSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MouseInteract();
        }
        
    }

    private void MouseInteract()
    {
        //perform a graphic raycast from pointer positiono the UI
        pData = new PointerEventData(eventSystems);

        //assign the current posistion of the mouse
        pData.position = Input.mousePosition;

        //initialize a list of racast results
        List<RaycastResult> results = new List<RaycastResult>();

        //performa  graphic raycast from the printer position to the UI
        gRaycaster.Raycast(pData, results);

        foreach (RaycastResult result in results)
        {
            //if button is detected, check if it is the accelerate button
            //increase accel value
            if (result.gameObject.tag == "ForwardButt")
            {
                changeAccelEvent(accelRate);
            }
            else if (result.gameObject.tag == "ReverseButt")
            {
                //if its deccelerate button
                //invoke change accel event with a negative value
                changeAccelEvent(-accelRate);

            }
        }





    }

}
