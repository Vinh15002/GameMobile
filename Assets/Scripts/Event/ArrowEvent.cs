using UnityEngine;

namespace Assets.Scripts.Event
{
    public class ArrowEvent
    {
        public delegate void Arrowevent(Transform game);

        public static Arrowevent Arrow;
    }
}
