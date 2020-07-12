using UnityEngine;
using UnityEngine.UIElements;

public class VelocityChanger : MonoBehaviour
{
    public ThirdPersonMovement movement;
    public GameObject panel;
    public GameObject velocityDisplay1;
    public GameObject velocityDisplay2;
    public GameObject velocityDisplay3;
    public float changetime = 10f;
    private int currentState = 2;
    private int nextState = 2;

    void Start()
    {
        InvokeRepeating("changeVelocity", changetime, changetime);
    }

    void changeVelocity()
    {
        while(currentState == nextState)
            nextState = Random.Range(1, 4);
        currentState = nextState;
        if (currentState == 1)
        {
            movement.velocityMultiplier = 0.5f;
            velocityDisplay1.SetActive(true);
            velocityDisplay2.SetActive(false);
            velocityDisplay3.SetActive(false);
        }
        else if (currentState == 2)
        {
            movement.velocityMultiplier = 1f;
            velocityDisplay1.SetActive(false);
            velocityDisplay2.SetActive(true);
            velocityDisplay3.SetActive(false);
        }
        else if (currentState == 3)
        {
            movement.velocityMultiplier = 2f;
            velocityDisplay1.SetActive(false);
            velocityDisplay2.SetActive(false);
            velocityDisplay3.SetActive(true);
        }
        panel.SetActive(true);
        Invoke("deactivatePanel", 1f);
    }

    void deactivatePanel() 
    {
        panel.SetActive(false);
    }
}
