using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NonKipple.Core
{
    public class InputManager : Service
    {
        public override IEnumerator Initialize()
        {
            yield return waitForEndOfFrame;
        }
    }
}