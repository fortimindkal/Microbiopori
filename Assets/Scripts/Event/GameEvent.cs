using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
    public UnityEvent OnEventTriggered;

    public void TriggerEvent()
    {
        OnEventTriggered.Invoke();
    }
}
