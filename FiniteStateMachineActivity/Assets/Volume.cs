using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public float volumeCount = 100f;

    [SerializeField] Text volumeText;

    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeCount = 100f;
        volumeText.text = "Volume: " + volumeCount + "%";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VolumeSlide()
    {
        volumeCount = volumeSlider.value;
        volumeText.text = "Volume: " + volumeCount + "%";
    }

}
