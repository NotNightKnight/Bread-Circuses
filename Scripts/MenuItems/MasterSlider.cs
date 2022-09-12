using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class MasterSlider : UIItem
    {
        [SerializeField]
        private Slider masterSlider;

        private OptionsUIPanel optionsUI;

        private void Start()
        {
            optionsUI = ServiceManager.i.GetManager<UIManager>().GetPanel<OptionsUIPanel>();

            masterSlider.onValueChanged.AddListener(delegate
            {
                masterChanged(masterSlider);
            });
        }
        
        private void masterChanged(Slider slider)
        {
            optionsUI.SetMasterVol((int)slider.value);
        }
    }
}