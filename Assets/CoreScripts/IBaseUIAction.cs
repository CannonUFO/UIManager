using System.Collections;
using UnityEngine;

namespace Assets.CoreScripts
{
    public interface IBaseUIAction
    {
        void DoOnCreate(BaseUIRoot baseUIRoot);
        void DoBeforeShow(BaseUIRoot baseUIRoot);
        void DoAfterHide(BaseUIRoot baseUIRoot);
    }
}