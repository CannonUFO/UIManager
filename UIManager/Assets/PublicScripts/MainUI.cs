using Assets.CoreScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : BaseMainUI
{
    // Start is called before the first frame update
    public void ShowHero()
    {
        UIManager.Instance.Show(UIName.HeroUI);
    }
}
