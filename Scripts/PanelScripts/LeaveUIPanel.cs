using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NonKipple.Core;

namespace NonKipple.Menu
{
    public class LeaveUIPanel : UIPanel
    {
        public void YesClick()
        {
            Application.Quit();
        }
    }
}