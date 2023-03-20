using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClass : MonoBehaviour
{
    [SerializeField] private Text classText;
    [SerializeField] private List<string> classes = new List<string> ();
    [SerializeField] private Dropdown classDrop;


    // Start is called before the first frame update
    void Start()
    {
        /*
        classes.Add("Damage");
        classes.Add("Tank");
        classes.Add("Support");
        */

        classText.text = "Class: " + classDrop.options[classDrop.value].text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateClass()
    {
        classText.text = "Class: " + classDrop.options[classDrop.value].text;
    }
}
