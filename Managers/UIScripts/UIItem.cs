using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NonKipple.Core
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIItem : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        public virtual void InitializeUIItems() { }

        public void OpenItem()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }

        public void CloseItem()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }
    }
}