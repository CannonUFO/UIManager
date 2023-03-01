using Assets.CoreScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.Show(UIName.MainUI);
    }
}
