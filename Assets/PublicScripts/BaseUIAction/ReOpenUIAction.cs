using Assets.CoreScripts;
using Assets.PublicScripts.BaseUI;

namespace Assets.PublicScripts.BaseUIAction
{
    public class ReOpenUIAction : IBaseUIAction
    {
        private BaseUIRoot _reOpenUIRoot;
        public void DoOnCreate(BaseUIRoot uIRoot)
        {
            
        }
        public void DoBeforeShow(BaseUIRoot uIRoot)
        {
            _reOpenUIRoot = null;
            _reOpenUIRoot = uIRoot.Last.TravelLast(TravelBySameUIAndShow) as BaseFullScreenUI;
            if (_reOpenUIRoot != null)
            {
                _reOpenUIRoot.Hide();
            }
        }
        public void DoAfterHide(BaseUIRoot uIRoot)
        {
            if (_reOpenUIRoot != null)
            {
                _reOpenUIRoot.Show();
            }
        }

        private static bool TravelBySameUIAndShow(BaseUIRoot uIRoot)
        {
            if (uIRoot.gameObject.activeSelf && uIRoot as BaseFullScreenUI)
                return true;
            return false;
        }
    }
}