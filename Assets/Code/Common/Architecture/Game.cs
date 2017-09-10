using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Common.Architecture
{
    /// <summary>
    /// The engine is initialized by this component.
    /// </summary>
    public class Game
    {
        private Engine engine;

        /// <summary> Initialise the engine, and call LoadLevel. </summary>
        Game()
        {
            engine = new Engine();
            engine.LoadLevel();
        }
    }
}