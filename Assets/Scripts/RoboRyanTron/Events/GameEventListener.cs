// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;

namespace RoboRyanTron.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")] 
        [SerializeField] public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] public UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised()
        {
            Debug.Log("shovelCollected event raised");
            Response.Invoke();
        }
    }
}