﻿using HotFixGame.HotControll;
using huqiang.Data;
using UnityEngine;

namespace HotFixGame
{
    public class Main
    {
        public static void Start(AssetBundle asset, RectTransform uiRoot)
        {
            HotPage.Root = uiRoot;
            HotPage.LoadPage<LoginPage>();
        }
        public static void Cmd(DataBuffer buffer)
        {
            HotData.HotDataControll.Dispatch(buffer);
        }
        public static void Resize()
        {
            if(HotPage.CurrentPage!=null)
            HotPage.CurrentPage.ReSize();
        }
        public static void Update(float time)
        {
            HotPage.Refresh(time);
        }
    }
}