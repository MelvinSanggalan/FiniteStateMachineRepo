using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    private int ammoCount;

    [SerializeField] Text ammoText;

    [SerializeField] InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = 100;
        ammoText.text = "Current Ammo: " + ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceAmmo()
    {
        if (ammoCount >= 10)
        {
            ammoCount -= 10;
            ammoText.text = "Current Ammo: " + ammoCount;
        }

    }

    public void IncreaseAmmo()
    {
        
        ammoCount += int.Parse(inputField.text);
        ammoText.text = "Current Ammo: " + ammoCount;
    }

}
