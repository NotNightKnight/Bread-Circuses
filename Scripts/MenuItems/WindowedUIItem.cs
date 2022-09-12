using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class WindowedUIItem : UIItem
    {
        [SerializeField]
        private Button winBtn;

        
        private Button fullBtn;
        private UIItem fullUI;

        private OptionsUIPanel optionsUI;

        private void Start()
        {
            optionsUI = ServiceManager.i.GetManager<UIManager>().GetPanel<OptionsUIPanel>();
            fullUI = ServiceManager.i.GetManager<UIManager>().GetItem<OptionsUIPanel, FullScreenUIItem>();
            fullBtn = fullUI.GetComponent<Button>();
        }

        public void BtnClick()
        {
            winBtn.interactable = false;
            fullBtn.interactable = true;
            optionsUI.SetWindowed();
        }
    }
}