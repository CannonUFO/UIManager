using System.Collections.Generic;

namespace Assets.CoreScripts
{
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
                _uiRootDict[(int)name]?.InitData(_headUI, uIData);
            }
        }

        public void Hide(UIName name)
        {
            var uiRoot = _headUI.TravelNext(name);
            if (uiRoot != null)
                uiRoot.Hide();
        }

        public void HideAll()
        {
            HideAll(_headUI);
        }

        private BaseUIRoot HideAll(BaseUIRoot uiRoot)
        {
            if (uiRoot.Next != null)
            {
                var target = HideAll(uiRoot.Next);
                target.Hide();
                return target.Last;    
            }
            else
            {
                return uiRoot;
            }
        }

        private void OnLoadCompleted(BaseUIRoot uIRoot, UIData uIData)
        {
            _uiRootDict[(int)uIData.Name] = uIRoot;
            uIRoot.OnCreate();
            if (_headUI == null)
                _headUI = uIRoot;

            uIRoot?.InitData(_headUI, uIData);
        }
    }
}
