using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Only one instance of EventManager should exists.");
        }
    }

    public delegate void LoseHealth(float _damage);
    public static LoseHealth losehealthEvent;

    public delegate void GainHealth(float _damage);
    public static GainHealth gainhealthEvent;

    public delegate void ChangeLight(int lightID, string lightName);
    public static ChangeLight changelightEvent;

    public delegate void IncreaseCarsWaiting(int amount, string lightName);
    public static IncreaseCarsWaiting increaseCarsWaitingEvent;

}
