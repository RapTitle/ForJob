using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;


namespace Itch.Interactive
{
    [Serializable]
    public class BoolEvent:UnityEvent<bool,GameObject>{}
    public class ZoneTriggerController : MonoBehaviour
    {
    
        [SerializeField] private BoolEvent eventZone;
    
    
        [SerializeField] private LayerMask mask;
        private void OnTriggerEnter(Collider other)
        {
            if ((1 << other.gameObject.layer) != 0)
            {
               eventZone.Invoke(true,other.gameObject);
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (1 << other.gameObject.layer != 0)
            {
                eventZone.Invoke(false,other.gameObject);
            }
        }
    }

}


