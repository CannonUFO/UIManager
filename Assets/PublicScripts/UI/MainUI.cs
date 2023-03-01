using Assets.CoreScripts;
using Assets.PublicScripts.BaseUI;

namespace Assets.PublicScripts.UI
{
    public class MainUI : BaseMainUI
    {
        
        public void ShowHero()
        {
            UIManager.Instance.Show(UIName.HeroUI);
        }
    }
}
