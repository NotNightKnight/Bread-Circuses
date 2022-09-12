using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class FullScreenUIItem : UIItem
    {
        [SerializeField]
        private Button fullBtn;

        private UIItem windowedUI;
        private Button winBtn;

        private OptionsUIPanel optionsUI;

        private void Start()
        {
            optionsUI = ServiceManager.i.GetManager<UIManager>().GetPanel<OptionsUIPanel>();
            windowedUI = ServiceManager.i.GetManager<UIManager>().GetItem<OptionsUIPanel, WindowedUIItem>();
            winBtn = windowedUI.GetComponent<Button>();
        }

        public void BtnClick()
        {
            fullBtn.interactable = false;
            winBtn.interactable = true;
            optionsUI.SetFullScreen();
        }
    }
}