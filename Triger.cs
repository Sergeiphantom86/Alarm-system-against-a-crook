using UnityEngine;

[RequireComponent(typeof(Alarm))]

public class Triger : MonoBehaviour
{
    private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter(Collider criminal)
    {
        if (criminal.TryGetComponent(out Rogue _))
        {
            _alarm.Turn();
        }
    }

    private void OnTriggerExit(Collider criminal)
    {
        if (criminal.TryGetComponent(out Rogue _))
        {
            _alarm.ChangeTarget();
        }
    }
}
