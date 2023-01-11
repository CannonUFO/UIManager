using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.CoreScripts
{
    public abstract class BaseUIRoot : MonoBehaviour
    {
        public BaseUIRoot Last { get; private set; }
        public BaseUIRoot Next { get; private set; }

        public UIData Data { get; private set; }

        public delegate bool TravelAction(BaseUIRoot uIRoot);

        public Canvas Canvas { get; private set; }

        protected IBaseUIAction baseUIAction;

        public BaseUIRoot TravelLast(TravelAction action)
        {
            if (action.Invoke(this))
                return this;
            else
                return Last == null ? null : Last.TravelLast(action);
        }
        public BaseUIRoot TravelNext(TravelAction action)
        {
            if (action.Invoke(this))
                return this;
            else
                return Next == null ? null : Next.TravelNext(action);
        }
        public BaseUIRoot TravelNext(UIName name)
        {
            if (name == Data.Name)
                return this;
            else
                return Next == null ? null : Next.TravelNext(name);
        }
        
        public void OnCreate()
        {
            baseUIAction?.DoOnCreate(this);
            Canvas = GetComponent<Canvas>();
        }
        public void InitData(BaseUIRoot headUI, UIData data)
        {
            Data = data;
            SetSortOrder();
            AddSelfLink(headUI);
            Show();
        }
        private void SetSortOrder()
        {
            if (Last != null)
            {
                Canvas.sortingOrder = Last.Canvas.sortingOrder + 1;
            }
        }
        private void AddSelfLink(BaseUIRoot headUI)
        {
            if (headUI != this)
                headUI.AddToLink(this);
        }
        private void AddToLink(BaseUIRoot uIRoot)
        {
            if (Next == null)
            {
                Next = uIRoot;
                uIRoot.Last = this;
            }
            else
                Next.AddToLink(uIRoot);
        }
        private void RemoveSelfFromLink()
        {
            if (Next == null)
                Last.Next = null;  
        }
        
        public void Show()
        {
            baseUIAction?.DoBeforeShow(this);
            OnShow();
        }
        public void Hide()
        {
            baseUIAction?.DoAfterHide(this);
            RemoveSelfFromLink();
            OnHide();
        }
        public void Release()
        {
            Addressables.ReleaseInstance(gameObject);
        }

        protected virtual void OnShow() 
        {
            gameObject.SetActive(true);
        }
        protected virtual void OnHide() 
        {
            gameObject.SetActive(false);
        }
    }
}
