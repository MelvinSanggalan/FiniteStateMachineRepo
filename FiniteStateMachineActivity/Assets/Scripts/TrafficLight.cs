using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;

public class TrafficLight : MonoBehaviour
{

    [Range(0, 10)] //slider in unity
    public int waitingCars = 0;

    public MeshRenderer Renderer { get; private set; }

    public StateMachine StateMachine { get; private set; }

    [SerializeField] string lightName;

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        StateMachine = new StateMachine();
    }

    // Start is called before the first frame update
    void Start()
    {
        StateMachine.SetState(new RedLight(this));

        EventManager.increaseCarsWaitingEvent += CarWaiting;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingCars == 0)
        {
            if(StateMachine.GetCurrentStateAsType<TrafficLightState>().ID == TrafficLightID.green)
            {
                StateMachine.SetState(new OrangeLight(this));
            }
        }
        else if(waitingCars >= 5)
        {
            if(StateMachine.GetCurrentStateAsType<TrafficLightState>().ID != TrafficLightID.green)
            {
                StateMachine.SetState(new GreenLight(this));
            }
        }

        StateMachine.OnUpdate();
    }

    
    public void ChangeLight(int lightID)
    {
        if(lightID == 0)
        {
            StateMachine.SetState(new GreenLight(this));
        }
        else if(lightID == 1)
        {
            StateMachine.SetState(new OrangeLight(this));
        }
        else if (lightID == 2)
        {
            StateMachine.SetState(new RedLight(this));
        }
    }

    

    public void CarWaiting(int carAmount, string _lightname)
    {
        if (_lightname == lightName)
        {
            waitingCars += carAmount;
        }
    }


    public enum TrafficLightID { green = 0, orange = 1, red = 2 }

    public abstract class TrafficLightState : IState
    {
        public TrafficLightID ID { get; protected set; }

        protected TrafficLight instance;

        public TrafficLightState(TrafficLight _instance)
        {
            instance = _instance;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnExit()
        {
        }
    }

    public class GreenLight : TrafficLightState
    {
        public GreenLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightID.green;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.green;
            //Debug.Log("The lights have turned green.");
        }

        public override void OnUpdate()
        {
            //Debug.Log("The light is currenty green.");
        }

        public override void OnExit()
        {
            //Debug.Log("The light is no longer green.");
        }
    }


    public class OrangeLight : TrafficLightState
    {
        public float time = 3;

        public float timer = 0;

        public OrangeLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightID.orange;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.yellow;
            //Debug.Log("The lights have turned orange.");
        }

        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            if(timer > time)
            {
                //set state to red light
                instance.StateMachine.SetState(new RedLight(instance));
            }

            //Debug.Log("The light is currenty orange.");
        }

        public override void OnExit()
        {
            //Debug.Log("The light is no longer orange.");
        }
    }

    public class RedLight : TrafficLightState
    {
        public RedLight(TrafficLight _instance) : base(_instance)
        {
            ID = TrafficLightID.red;
        }

        public override void OnEnter()
        {
            instance.Renderer.material.color = Color.red;
            //Debug.Log("The lights have turned red.");
        }

        public override void OnUpdate()
        {
            //Debug.Log("The light is currenty red.");
        }

        public override void OnExit()
        {
            //Debug.Log("The light is no longer red.");
        }
    }

}
