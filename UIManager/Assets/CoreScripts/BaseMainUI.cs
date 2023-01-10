

public class BaseMainUI : BaseUIRoot
{
    private int hideCount = 0;
    public new void SetHeadUI(bool value)
    {
        if (value)
            hideCount -= 1;
        else
            hideCount += 1;

        if (hideCount == 0)
            Show();
        else
            Hide();
    }
    public override void OnCreate()
    {

    }
    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }
}
