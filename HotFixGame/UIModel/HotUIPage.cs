﻿using huqiang;
using huqiang.Core.HGUI;
using huqiang.UIComposite;
using huqiang.UIEvent;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HotUIPage : HotUIBase
{
    class PageInfo
    {
        public Type Pagetype;
        public object DataContext;
        public Type PopType;
        public object PopData;
    }
    static Stack<PageInfo> pages = new Stack<PageInfo>();
    public static Type typePop = typeof(HotPopWindow);
    public static void ClearStack()
    {
        pages.Clear();
    }
    public static Transform Root { get; set; }
    public static HotUIPage CurrentPage { get; private set; }
    public static void LoadPage<T>(object dat = null) where T : HotUIPage, new()
    {
        if (CurrentPage is T)
        {
            CurrentPage.Show(dat);
            return;
        }
        if (HCanvas.MainCanvas != null)//释放当前页面所有事件
            HCanvas.MainCanvas.ClearAllAction();
        TextInput.Clear();
        if (CurrentPage != null)
        {
            CurrentPage.Save();
            CurrentPage.Dispose();
        }
        var t = new T();
        t.Initial(Root, dat);
        t.ReSize();
        CurrentPage = t;
    }
    public static void LoadPage(Type type, object dat = null)
    {
        if (typeof(HotUIPage).IsAssignableFrom(type))
        {
            if (CurrentPage != null)
                if (CurrentPage.GetType() == type)
                {
                    CurrentPage.Show(dat);
                    return;
                }
            if (HCanvas.MainCanvas != null)//释放当前页面所有事件
                HCanvas.MainCanvas.ClearAllAction();
            TextInput.Clear();
            if (CurrentPage != null)
                CurrentPage.Dispose();
            var t = Activator.CreateInstance(type) as HotUIPage;
            CurrentPage = t;
            t.Initial(Root, dat);
            t.ReSize();
            t.Recovery();
        }
    }
    public static void Back()
    {
        if (pages.Count > 0)
        {
            var page = pages.Pop();
            if (page != null)
            {
                LoadPage(page.Pagetype, page.DataContext);
                if (page.PopType != null)
                {
                    CurrentPage.PopUpWindow(page.PopType, page.PopData);
                }
            }
        }
    }
    public static void UpdateData(string cmd, object obj)
    {
        if (CurrentPage != null)
            CurrentPage.Cmd(cmd, obj);
    }
    public static void Refresh(float time)
    {
        if (CurrentPage != null)
            CurrentPage.Update(time);
    }
    public static void MainRefresh(float time)
    {
        if (CurrentPage != null)
            CurrentPage.MainUpdate(time);
    }
    public HotUIPage()
    {
        pops = new List<HotPopWindow>();
    }
    protected Type BackPage;
    protected Type BackPop;
    protected object BackData;
    public HotPopWindow currentPop { get; private set; }
    public virtual void Initial(Transform parent, object dat = null)
    {
        Parent = parent;
        DataContext = dat;
    }
    public virtual void Initial(Transform parent, object dat = null, Type back = null, Type pop = null, object backData = null)
    {
        Initial(parent, dat);
        BackPage = back;
        BackPop = pop;
        BackData = backData;
    }
    public virtual void Show(object dat = null)
    {
    }
    public override void ReSize() { base.ReSize(); if (currentPop != null) currentPop.ReSize(); }
    public override void Dispose()
    {
        if (pops != null)
            for (int i = 0; i < pops.Count; i++)
                pops[i].Dispose();
        pops.Clear();
        currentPop = null;
        if (Main != null)
        {
            Main.transform.SetParent(null);
            HGUIManager.GameBuffer.RecycleGameObject(Main);
        }
        ClearUI();
    }
    public void HidePopWindow()
    {
        if (currentPop != null)
        {
            currentPop.Hide();
        }
        currentPop = null;
    }
    List<HotPopWindow> pops;
    protected T ShowPopWindow<T>(object obj = null, Transform parent = null) where T : HotPopWindow, new()
    {
        if (currentPop != null)
        {
            currentPop.Hide();
            currentPop = null;
        }
        for (int i = 0; i < pops.Count; i++)
            if (pops[i] is T)
            {
                currentPop = pops[i];
                pops[i].Show(obj);
                return pops[i] as T;
            }
        var t = new T();
        pops.Add(t);
        currentPop = t;
        if (parent == null)
            t.Initial(Parent, this, obj);
        else t.Initial(parent, this, obj);
        t.ReSize();
        return t;
    }
    protected object ShowPopWindow(Type type, object obj = null, Transform parent = null)
    {
        if (currentPop != null)
        { currentPop.Hide(); currentPop = null; }
        for (int i = 0; i < pops.Count; i++)
            if (pops[i].GetType() == type)
            {
                currentPop = pops[i];
                pops[i].Show(obj);
                return pops[i];
            }
        var t = Activator.CreateInstance(type) as HotPopWindow;
        pops.Add(t);
        currentPop = t;
        if (parent == null)
            t.Initial(Parent, this, obj);
        else t.Initial(parent, this, obj);
        t.ReSize();
        return t;
    }
    public virtual T PopUpWindow<T>(object obj = null) where T : HotPopWindow, new()
    {
        return ShowPopWindow<T>(obj, null);
    }
    object PopUpWindow(Type type, object obj = null)
    {
        var pop = ShowPopWindow(type, obj, null) as HotPopWindow;
        pop.Recovery();
        return pop;
    }
    /// <summary>
    /// 释放掉当前未激活的弹窗
    /// </summary>
    public void ReleasePopWindow()
    {
        if (pops != null)
            for (int i = 0; i < pops.Count; i++)
                if (pops[i] != currentPop)
                    pops[i].Dispose();
        pops.Clear();
        if (currentPop != null)
            pops.Add(currentPop);
    }
    public void ReleasePopWindow(HotPopWindow window)
    {
        pops.Remove(window);
        if (currentPop == window)
        {
            currentPop = null;
        }
        window.Dispose();
    }
    public void ReleasePopWindow<T>()
    {
        for (int i = 0; i < pops.Count; i++)
            if (pops[i] is T)
            {
                pops[i].Dispose();
                pops.RemoveAt(i);
                break;
            }
        if (currentPop is T)
        {
            currentPop = null;
        }
    }
    public T GetPopWindow<T>() where T : HotPopWindow
    {
        for (int i = 0; i < pops.Count; i++)
            if (pops[i] is T)
            {
                return pops[i] as T;
            }
        return null;
    }
    public override void Save()
    {
        if (pops != null)
            for (int i = 0; i < pops.Count; i++)
                if (pops[i] != currentPop)
                    pops[i].Save();
        PageInfo page = new PageInfo();
        page.Pagetype = GetType();
        if (currentPop != null)
            if (currentPop.Main.gameObject.activeSelf)
            {
                page.PopType = currentPop.GetType();
                page.PopData = currentPop.DataContext;
            }
        page.DataContext = DataContext;
        pages.Push(page);
    }
    public override void Update(float time)
    {
        if (currentPop != null)
            currentPop.Update(time);
    }
    /// <summary>
    /// 主线程更新
    /// </summary>
    /// <param name="time"></param>
    public virtual void MainUpdate(float time)
    {
    }
}