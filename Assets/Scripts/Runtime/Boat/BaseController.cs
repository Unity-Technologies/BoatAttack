using System;
using UnityEngine;

namespace BoatAttack
{
    public class BaseController : MonoBehaviour
    {
        [NonSerialized] protected Boat controller; // the boat controller
        [NonSerialized] protected Engine engine; // the engine script

        public virtual void OnEnable()
        {
            if(TryGetComponent(out controller)) // get the controller script
                engine = controller.engine;
        }
    }
}