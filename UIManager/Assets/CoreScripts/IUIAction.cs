using System.Collections;
using UnityEngine;

namespace Assets.CoreScripts
{
    public interface IUIAction
    {
       void OnCreate();
       void Show();
       void Hide();
    }
}