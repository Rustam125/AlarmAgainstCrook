using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlarmSwitcher : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == false)
        {
            return;
        }

        _alarm.TurnOn();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() == false)
        {
            return;
        }
        
        _alarm.TurnOff();
    }
}
