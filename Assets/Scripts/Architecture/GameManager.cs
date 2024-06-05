using System;
using System.Collections.Generic;

namespace TD
{
    public class GameManager
    {
        private readonly Dictionary<GameStateType, Action> gameStates = new Dictionary<GameStateType, Action>();
        private event Action OnStart;
        private event Action OnPause;
        private event Action OnPlay;
        private event Action OnEnd;
        private event Action OnRestart;

        public GameManager()
        {
            gameStates = new Dictionary<GameStateType, Action>() 
            {
               {GameStateType.Start , OnStart},
               {GameStateType.Pause , OnPause},
               {GameStateType.Play , OnPlay},
               {GameStateType.End , OnEnd},
               {GameStateType.Restart , OnRestart},
            };
        }

        public void InvokeGameState(GameStateType gameStateType)
        {
            if (gameStates.TryGetValue(gameStateType, out Action events))
            {
                events?.Invoke();
            }
        }

        public void SubGameState(GameStateType gameStateType, Action action)
        {
            if(gameStates.TryGetValue(gameStateType, out Action gameState))
            {
                gameState += action;
            }
        }

        public void UnsubGameState(GameStateType gameStateType, Action action)
        {
            if (gameStates.TryGetValue(gameStateType, out Action gameState))
            {
                gameState -= action;
            }
        }
    }
}