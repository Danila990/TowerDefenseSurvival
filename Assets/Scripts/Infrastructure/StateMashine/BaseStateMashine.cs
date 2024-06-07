using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD
{
    public class BaseStateMashine : MonoBehaviour
    {
        private readonly List<IState> _states = new List<IState>();

        public void Enter()
        {
            if(_states.Count != 0)
            {
                _states[0].Enter();
                StartUpdate(_states[0]);
                return;
            }
        }

        public void AddState(IState state)
        {
            _states.Add(state);
        }

        public void RemoveState(Type type)
        {
            _states.Remove(type as IState);
        }

        private void StartUpdate(IState state)
        {
            StopAllCoroutines();
            state.Enter();
            StartCoroutine(UpdateState(state));
        }

        private void NextState(IState nextState)
        {
            bool nextStateFind = false;
            foreach(IState state in _states)
            {
                if (nextStateFind)
                {
                    StartUpdate(state);
                    return;
                }

                if (state.Equals(nextState))
                {
                    nextStateFind = true;
                }
            }

            StopAllCoroutines();
        }

        private IEnumerator UpdateState(IState state)
        {
            while (!state.IsComplete)
            {
                state.UpdateState();
                yield return null;
            }

            NextState(state);
        }
    }
}