using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hilam
{
    public interface IState 
    {
        public void OnStateStart();
        public void OnStateUpdate();
        public void OnStateFixedUpdate();
        public void OnStateExit();
        public void OnStateCollideEnter(Collision2D collision);
        public void OnStateTriggerEnter(Collider2D collision);
        public void OnStateTriggerExit(Collider2D collision);
    }
}
