using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NonKipple.Core
{
    [DefaultExecutionOrder(-100_099)]
    public abstract class Service : MonoBehaviour
    {
        protected WaitForEndOfFrame waitForEndOfFrame;
        protected Dictionary<string, Service> managers;
        protected ServiceManager serviceManager;

        public abstract IEnumerator Initialize();

        public virtual void Awake()
        {
            waitForEndOfFrame = new WaitForEndOfFrame();
            managers = new Dictionary<string, Service>();
            serviceManager = ServiceManager.i;
            serviceManager.RegisterManager(this);
        }
    }
}