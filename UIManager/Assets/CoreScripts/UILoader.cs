using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.CoreScripts
{
    public class UILoader
    {
        private UIData _data;
        private Action<BaseUIRoot, UIData> _onLoadCallBack;
        private string _definePath = "{0}.prefab";
        

        public void Load(UIName name, UIData data, Action<BaseUIRoot, UIData> OnLoadComplete)
        {
            _data = data;
            _onLoadCallBack = OnLoadComplete;
            var path = string.Format(_definePath, name.ToString());
            Addressables.InstantiateAsync(path, Vector3.zero, Quaternion.identity).Completed += OnLoadInstantiateComplete;
        }

        private void OnLoadInstantiateComplete(AsyncOperationHandle<GameObject> obj)
        {
            if(obj.Result != null)
            {
                var uiRoot = obj.Result.GetComponent<BaseUIRoot>();
                uiRoot.OnCreate();
                _onLoadCallBack.Invoke(uiRoot, _data);
            }
        }
    }
}