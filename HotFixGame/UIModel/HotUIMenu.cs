using huqiang.Core.HGUI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HotUIMenu: HotUIBase
{
    public static Transform Root { get; set; }
    public static HotUIMenu Instance { get; set; }
    public static void UpdateData(string cmd, object obj)
    {
        if (Instance != null)
            Instance.Cmd(cmd, obj);
    }
    public static void Refresh(float time)
    {
        if (Instance != null)
            Instance.Update(time);
    }
    List<HotMenuWindow> pops;
    public HotMenuWindow currentPop { get; private set; }
    public HotUIMenu()
    {
        pops = new List<HotMenuWindow>();
        Instance = this;
    }
    public override void ReSize()
    {
        for (int i = 0; i < pops.Count; i++)
        {
            var p = pops[i];
            if (p.model != null)
                p.ReSize();
        }
    }
    public override void Dispose()
    {
        if (pops != null)
            for (int i = 0; i < pops.Count; i++)
                pops[i].Dispose();
        pops.Clear();
        HGUIManager.GameBuffer.RecycleGameObject(Main);
        ClearUI();
    }
    public void HideMenu()
    {
        for (int i = 0; i < pops.Count; i++)
            pops[i].Hide();
    }
    /// <summary>
    /// 释放掉当前未激活的弹窗
    /// </summary>
    public void ReleaseMune()
    {
        int c = pops.Count - 1;
        for (; c >= 0; c--)
        {
            var p = pops[c];
            if (p.model != null)
            {
                p.Dispose(); pops.RemoveAt(c);
            }
            else
            if (!p.Main.gameObject.activeSelf)
            {
                p.Dispose(); pops.RemoveAt(c);
            }
        }
    }
    public T ShowMenu<T>(HotUIBase context, Vector2 pos, object obj = null) where T : HotMenuWindow, new()
    {
        if (currentPop != null)
        { currentPop.Hide(); currentPop = null; }
        for (int i = 0; i < pops.Count; i++)
            if (pops[i] is T)
            {
                currentPop = pops[i];
                pops[i].Show(context, pos,obj);
                return pops[i] as T;
            }
        var t = new T();
        pops.Add(t);
        currentPop = t;
        t.Initial(Root, context, obj);
        t.Show(context,pos,obj);
        t.ReSize();
        return t;
    }
    public T GetMenu<T>() where T : HotPopWindow
    {
        for (int i = 0; i < pops.Count; i++)
            if (pops[i] is T)
                return pops[i] as T;
        return null;
    }
    public override void Update(float time)
    {
        for (int i = 0; i < pops.Count; i++)
        {
            var p = pops[i];
            if (p.model != null)
                if (p.Main.gameObject.activeSelf)
                    p.Update(time);
        }
    }
}
