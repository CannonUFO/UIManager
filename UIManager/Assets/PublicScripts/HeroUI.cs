using Assets.CoreScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroUI : BaseFullScreenUI
{
    // Start is called before the first frame update
    public void ShowClan()
    {
        UIManager.Instance.Show(UIName.ClanUI);
    }
}
