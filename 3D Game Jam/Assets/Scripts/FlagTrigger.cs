using UnityEngine;
using UnityEngine.PlayerLoop;

public class FlagTrigger : MonoBehaviour
{
    public Transform flag;
    private bool triggered;
    private Vector3 start;
    private Vector3 target;
    private float speed = 15f;
    private void OnTriggerEnter()
    {
        target = new Vector3(flag.position.x, flag.position.y - 30, flag.position.z);
        triggered = true;
    }

    void Update() 
    { 
        if(triggered)
            flag.position = Vector3.MoveTowards(flag.position, target, Time.deltaTime * speed);
    }

}