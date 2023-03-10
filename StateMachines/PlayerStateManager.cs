using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hilam.Player.State;

namespace Hilam.Player
{
    public class PlayerStateManager
    {
        Player player;
        PlayerIdleState playerIdleState;

        IState currentState;

        #region Properties
        public PlayerState CurrentState => currentState;
        public PlayerIdleState IdleState => playerIdleState;
        #endregion

        public PlayerStateManager()
        {
            player = Player.Instance;

            playerIdleState = new PlayerIdleState();

            currentState = playerIdleState;
            
        }

        public void OnStateUpdate() 
        {
            currentState.OnStateUpdate();
        }
        public void OnStateFixedUpdate()
        {
            currentState.OnStateFixedUpdate();
        }

        public void OnStateCollideEnter(Collision2D collision)
        {
            currentState.OnStateCollideEnter(collision);
        }
        public void OnStateTriggerEnter(Collider2D other) 
        {
            currentState.OnStateTriggerEnter(other);
        }
        public void OnStateTriggerExit(Collider2D other)
        {
            currentState.OnStateTriggerExit(other);
        }

        /// <summary>
        /// Changes the player's state
        /// </summary>
        /// <param name="wantedState"> You must use this format: player.PlayerState.IState</param>
        public void ChangeState(PlayerState wantedState)
        {
            if (currentState != wantedState)
            {
                currentState.OnStateExit();
                currentState = wantedState;
                currentState.OnStateStart();

            }
        }

        /// <summary>
        /// Is the wanted state equal player's state
        /// </summary>
        /// <param name="wantedState">You must use this format: player.PlayerState.IState</param>
        public bool IsPlayerStateEqual(PlayerState wantedState)
        {
            if (currentState == wantedState) return true;
            else return false;
        } 

    }
}
