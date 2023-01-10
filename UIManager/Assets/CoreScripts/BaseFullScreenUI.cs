
using System;

public class BaseFullScreenUI : BaseUIRoot
{
    //private TravelAction _travelAction;
    public bool IsReOpen { get; private set; }
    public override void OnCreate()
    {
        
    }
    public override void Show()
    {
        var lastUI = Last.TravelLast(TravelBySameUIAndShow) as BaseFullScreenUI;
        if(lastUI != null)
        {
            lastUI.HideByAnother();
        }
        gameObject.SetActive(true);
    }

    private static bool TravelBySameUIAndShow(BaseUIRoot uIRoot)
    {
        if (uIRoot.gameObject.activeSelf && uIRoot as BaseFullScreenUI)
            return true;
        return false;
    }
    private static bool TravelBySameUIAndHide(BaseUIRoot uIRoot)
    {
        if (!uIRoot.gameObject.activeSelf && uIRoot as BaseFullScreenUI)
            return true;
        return false;
    }


    private void HideByAnother()
    {
        Hide();
        IsReOpen = true;
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
        var lastUI = Last.TravelLast(TravelBySameUIAndHide) as BaseFullScreenUI;
        if (lastUI != null)
        {
            lastUI.ReOpen();
        }
    }

    private void ReOpen()
    {
        IsReOpen = false;
        Show();
    }
}
