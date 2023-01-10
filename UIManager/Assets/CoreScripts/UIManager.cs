using System.Collections.Generic;

namespace Assets.CoreScripts
{
    /// <summary>
    /// 
    /// </summary>
    public class UIManager
    {
        private static UIManager s_Instance;

        public static UIManager Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new UIManager();
                return s_Instance;
            }
        }

        private BaseUIRoot _headUI;

        private Dictionary<int, BaseUIRoot> _uiRootDict = new Dictionary<int, BaseUIRoot>();

        public void Show(UIName name)
        {
            DoShow(name, new UIData() { Name = name });
        }

        public void Show(UIName name, UIData uIData)
        {
            DoShow(name, uIData);
        }

        private void DoShow(UIName name, UIData uIData)
        {
            if (!_uiRootDict.ContainsKey((int)name))
            {
                _uiRootDict.Add((int)name, null);
                var loader = new UILoader();
                loader.Load(name, uIData, OnLoadCompleted);
            }
            else
            {
                DoShow(_uiRootDict[(int)name], uIData);
            }
        }

        public void Hide(UIName name)
        {
            var uiRoot = _headUI.TravelNext(name);
            if (uiRoot != null)
                uiRoot.Hide();
        }

        private void OnLoadCompleted(BaseUIRoot uIRoot, UIData uIData)
        {
            _uiRootDict[(int)uIData.Name] = uIRoot;

            if (_headUI == null)
                _headUI = uIRoot;
            else
                _headUI.Add(uIRoot);

            DoShow(uIRoot, uIData);
        }

        private void DoShow(BaseUIRoot uIRoot, UIData uIData)
        {
            if (uIRoot == null)
                return;
            uIRoot.InitData(uIData);
            uIRoot.Show();
        }
    }
}
