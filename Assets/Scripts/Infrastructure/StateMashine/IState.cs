using System;

namespace TD
{
    public interface IState
    {
        public bool IsComplete { get; }

        public void Enter();

        public void UpdateState();
    }
}