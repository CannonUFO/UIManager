using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class BaseUIRoot : MonoBehaviour
{
    public BaseUIRoot Last { get; private set; }
    public BaseUIRoot Next { get; private set; }

    public UIData Data { get; private set; }

    public delegate bool TravelAction(BaseUIRoot uIRoot);

    public void InitData(UIData data)
    {
        Data = data;
    }

    public void Add(BaseUIRoot uIRoot)
    {
        if (Next == null)
        {
            Next = uIRoot;
            uIRoot.Last = this;
        }
        else
            Next.Add(uIRoot);
    }

    public void SetHeadUI(bool value)
    {
        if (Last == null)
            Hide();
        else
            SetHeadUI(value);
    }
    
    public BaseUIRoot TravelLast(TravelAction action)
    {
        if (action.Invoke(this))
            return this;
        else
            return Last == null?null:Last.TravelLast(action);
    }
    public BaseUIRoot TravelNext(TravelAction action)
    {
        if (action.Invoke(this))
            return this;
        else
            return Next == null?null: Next.TravelNext(action);
    }
    public BaseUIRoot TravelNext(UIName name)
    {
        if (name == Data.Name)
            return this;
        else
            return Next == null ? null : Next.TravelNext(name);
    }

    public void Release()
    {
        Addressables.ReleaseInstance(gameObject);
    }

    private void OnDestroy()
    {
        Last.Next = Next;
    }

    

    public abstract void OnCreate();
    public abstract void Show();
    public abstract void Hide();

    
}
