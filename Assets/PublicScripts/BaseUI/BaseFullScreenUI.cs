
using Assets.CoreScripts;
using Assets.PublicScripts.BaseUIAction;
using System;

namespace Assets.PublicScripts.BaseUI 
{ 
    public class BaseFullScreenUI : BaseUIRoot
    {
        private void Awake()
        {
            baseUIAction = new ReOpenUIAction();
        }
    }
}
