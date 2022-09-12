using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NonKipple.Core
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanel : MonoBehaviour
    {
        [SerializeField]
        private List<UIItem> uiItemList;

        [SerializeField]
        private CanvasGroup canvasGroup;

        public virtual void InitializePanels()
        {
            foreach (var item in uiItemList)
                item.InitializeUIItems();

            ClosePanel();
        }

        public T FindItem<T>() where T : UIItem
        {
            foreach (var item in uiItemList)
                if (item is T uiItem)
                    return uiItem;

            return null;
        }

        public void OpenPanel()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        public void ClosePanel()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}