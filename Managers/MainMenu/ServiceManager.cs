using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NonKipple.Core
{
    [DefaultExecutionOrder(-100_100)]
    public class ServiceManager : MonoBehaviour
    {
        public static ServiceManager i;
        private Dictionary<string, Service> managers;

        private void Awake()
        {
            i = this;
            managers = new Dictionary<string, Service>();
        }

        public void RegisterManager(Service service)
        {
            string key = service.GetType().Name;
            if(managers.ContainsKey(key))
            {
                Debug.LogError($"Already exist: {key}");
                return;
            }
            managers.Add(key, service);
        }

        public T GetManager<T>() where T : Service
        {
            string key = typeof(T).Name;
            if (managers.TryGetValue(key, out Service service))
                return (T)service;
            else
                Debug.LogError($"Can't find manager: {key}");
            return null;
        }
    }
}