using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    public GameEvent gameEvent;

    private void OnEnable()
    {
        gameEvent.OnEventTriggered.AddListener(OnEventRaised);
    }

    private void OnDisable()
    {
        gameEvent.OnEventTriggered.RemoveListener(OnEventRaised);
    }

    private void OnEventRaised()
    {
        Debug.Log("Event triggered!");
        // Handle the event here
    }
}
