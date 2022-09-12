using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class UISlider : UIItem
    {
        [SerializeField]
        private Slider UIVol;

        private OptionsUIPanel optionsUI;

        private void Start()
        {
            optionsUI = ServiceManager.i.GetManager<UIManager>().GetPanel<OptionsUIPanel>();

            UIVol.onValueChanged.AddListener(delegate
            {
                UIVolChanged(UIVol);
            });
        }

        private void UIVolChanged(Slider slider)
        {
            optionsUI.SetUIVol((int)slider.value);
        }
    }
}