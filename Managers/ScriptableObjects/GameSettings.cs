using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NonKipple.Core
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        //Graphics

        [SerializeField]
        public int frameRate;

        [SerializeField]
        public bool fullScreen;

        [SerializeField]
        public bool windowed;

        [SerializeField]
        public int resWidth;

        [SerializeField]
        public int resHeight;

        //Sound

        [SerializeField]
        public int masterVolume;

        [SerializeField]
        public int UIVolume;
    }
}