using HotFixGame.HotControll;
using HotFixGame.HotData;
using huqiang.Data;
using UnityEngine;

public class Main
{
    public static void Start(RectTransform uiRoot, string Cmd, object dat)
    {
        HotUIPage.Root = uiRoot;
        HotUIPage.LoadPage<LobbyPage>();
    }
    public static void Cmd(string cmd, object obj)
    {

    }
    public static void FullCmd(DataBuffer req)
    {
        HotDataControll.Dispatch(req);
    }
    public static void Resize()
    {
        if (HotUIPage.CurrentPage != null)
            HotUIPage.CurrentPage.ReSize();
    }
    public static void Update(float time)
    {
        HotUIPage.Refresh(time);
    }
}
