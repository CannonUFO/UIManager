using Assets.CoreScripts;
using Assets.PublicScripts.BaseUI;

namespace Assets.PublicScripts.UI
{
    public class HeroUI : BaseFullScreenUI
    {
        
        public void ShowClan()
        {
            UIManager.Instance.Show(UIName.ClanUI);
        }
    }
}
