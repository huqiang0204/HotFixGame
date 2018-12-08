using HotFixGame.HotControll;
using huqiang.Data;
using UnityEngine;

public class Main
{
    public static void Start(RectTransform uiRoot)
    {
        HotPage.Root = uiRoot;
        HotPage.LoadPage<LobbyPage>();
    }
    public static void Cmd(DataBuffer buffer)
    {
        HotFixGame.HotData.HotDataControll.Dispatch(buffer);
    }
    public static void Resize()
    {
        if (HotPage.CurrentPage != null)
            HotPage.CurrentPage.ReSize();
    }
    public static void Update(float time)
    {
        HotPage.Refresh(time);
    }
}
