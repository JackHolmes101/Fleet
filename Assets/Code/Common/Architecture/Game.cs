using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Common.Architecture
{
    /// <summary>
    /// The engine is initialized by this component.
    /// </summary>
    public class Game:MonoBehaviour
    {
        //private Engine engine = Engine.Singleton;

        /// <summary> Initialise the engine, and call LoadLevel. </summary>
        private void Start()
        {
            //engine.LoadLevel();

        }

        private void Update()
        {
            //engine.Update();
        }


    }
}