
using UnityEngine;

namespace MyCode
{
    public abstract class Ability : ScriptableObject
    {
        protected int _count;

        public abstract void Add();
        public abstract void Upgrade();
    }
}