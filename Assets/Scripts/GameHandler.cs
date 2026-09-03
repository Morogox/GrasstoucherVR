using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public int pressCount = 0;
    public bool droneActive = false;
    public bool droneArrived = false;
    public bool deathSentence = false;

    public bool CanTouchGrass = true;
    public Animator droneAnimator;
    public Animator grassAnimator;
    public GameObject helpText;
    public Drone drone;

    public GameObject counterPopup;
    public Transform grass;


    public DeathEffect deathEffect;
    void Start()
    {
        drone.gameObject.SetActive(false);
    }
    public void ButtonPressed()
    {
        if (!CanTouchGrass)
        {
            return;
        }
        pressCount++;
        grassAnimator.Play("GrassSquish",0, 0f);

        Debug.Log("Button pressed: " + pressCount);
        helpText.SetActive(false);
        GameObject popup = Instantiate(counterPopup, grass.position, Quaternion.identity);
        popup.GetComponent<CounterPopup>().text.text = pressCount.ToString();

        if (pressCount >= 10 && !droneArrived)
        {
            DroneArrives();
            droneArrived = true;
        }
        if (droneActive && !deathSentence)
        {
            deathSentence = true;
            DroneExecute();
        }
    }

    void DroneArrives()

    {
        drone.gameObject.SetActive(true);
        Debug.Log("DRONE ARRIVES");
        droneAnimator.Play("DroneEntrance");
    }

    void DroneExecute()
    {   
        drone.ExecutionInProgress(); 
        Debug.Log("EXECUTION IN PROGRESS");
    }
   
    public void PlayerDies()
    {
        Debug.Log("YOU DIED");
        CanTouchGrass = false;
        deathEffect.StartDeath();
    }


}


