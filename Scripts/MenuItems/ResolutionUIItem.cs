using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class ResolutionUIItem : UIItem
    {
        [SerializeField]
        private TMP_Dropdown resDrop;

        private OptionsUIPanel optionsUI;

        private void Start()
        {
            optionsUI = ServiceManager.i.GetManager<UIManager>().GetPanel<OptionsUIPanel>();

            resDrop.onValueChanged.AddListener(delegate
            {
                ResChanged(resDrop);
            });
        }

        private void ResChanged(TMP_Dropdown dropdown)
        {
            string newRes;
            switch(dropdown.value)
            {
                case 0:
                    newRes = "1920x1080";
                    break;
                case 1:
                    newRes = "1366x768";
                    break;
                case 2:
                    newRes = "1280x800";
                    break;
                case 3:
                    newRes = "1040x640";
                    break;
                default:
                    newRes = "1366x768";
                    break;
            }

            optionsUI.SetRes(newRes);
        }
    }
}