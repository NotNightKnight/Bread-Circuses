using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace NonKipple.Core
{
    public class UIManager : Service
    {
        [SerializeField]
        private CinemachineVirtualCamera cam;

        [SerializeField]
        private List<UIPanel> panelList;

        public override IEnumerator Initialize()
        {
            InitializeUI();
            yield return waitForEndOfFrame;
        }
        private void InitializeUI()
        {
            foreach (var item in panelList)
                item.InitializePanels();
        }

        public T GetPanel<T>() where T : UIPanel
        {
            foreach (var item in panelList)
                if (item is T panel)
                    return panel;

            return null;
        }
        public K GetItem<T, K>() where T : UIPanel where K : UIItem
        {
            foreach (var item in panelList)
                if (item is T panel)
                    return panel.FindItem<K>();

            return null;
        }
        public void OpenPanel<T>() where T : UIPanel
        {
            GetPanel<T>().OpenPanel();
        }
        public void ClosePanel<T>() where T : UIPanel
        {
            GetPanel<T>().ClosePanel();
        }
        public void OpenUIItem<T, K>() where T : UIPanel where K : UIItem
        {
            GetItem<T, K>().OpenItem();
        }
        public void CloseUIItem<T, K>() where T : UIPanel where K : UIItem
        {
            GetItem<T, K>().CloseItem();
        }

        public CinemachineVirtualCamera GetCamera()
        {
            return cam;
        }
    }
}