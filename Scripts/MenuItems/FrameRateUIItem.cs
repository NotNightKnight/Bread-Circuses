using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class FrameRateUIItem : UIItem
    {
        [SerializeField]
        private TMP_Dropdown frameDrop;

        private OptionsUIPanel optionsUI;

        private void Start()
        {
            optionsUI = ServiceManager.i.GetManager<UIManager>().GetPanel<OptionsUIPanel>();

            frameDrop.onValueChanged.AddListener(delegate
            {
                FrameChanged(frameDrop);
            });
        }
        
        private void FrameChanged(TMP_Dropdown dropdown)
        {
            int newFrame;
            switch(dropdown.value)
            {
                case 0:
                    newFrame = 30;
                    break;
                case 1:
                    newFrame = 60;
                    break;
                case 2:
                    newFrame = 75;
                    break;
                case 3:
                    newFrame = 120;
                    break;
                case 4:
                    newFrame = -1;
                    break;
                default:
                    newFrame = 30;
                    break;
            }

            optionsUI.SetFrame(newFrame);
        }
    }
}