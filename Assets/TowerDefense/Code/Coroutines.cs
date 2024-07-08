using System.Collections;
using UnityEngine;

namespace TowerDefense
{
    public sealed class Coroutines : MonoBehaviour
    {
        private static Coroutines m_instance;

        private static Coroutines _instance
        {
            get 
            { 
                if(m_instance == null)
                {
                    var go = new GameObject("[Coroutines Manager]");
                    m_instance = go.AddComponent<Coroutines>();
                    DontDestroyOnLoad(go);
                }

                return m_instance; 
            }
        }

        public static Coroutine StartRountine(IEnumerator enumerator)
        {
            return _instance.StartCoroutine(enumerator);
        }

        public static void StopRountine(Coroutine rountine)
        {
            if(rountine == null)
            {
                return;
            }

            _instance.StopCoroutine(rountine);
        }
    }
}