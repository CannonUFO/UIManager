

using Assets.CoreScripts;
namespace Assets.PublicScripts.BaseUI
{
    public class BaseMainUI : BaseUIRoot
    {
        private int hideCount = 0;
        public void SetHeadUI(bool value)
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
    }
}
