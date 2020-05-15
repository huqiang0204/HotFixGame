using System;
using UnityEngine;
using huqiang.Data;
using huqiang;
using UnityEngine.UI;
using HotFixGame.HotData;
using huqiang.UIComposite;
using huqiang.UIEvent;
using huqiang.Core.HGUI;
using System.Collections.Generic;
using HotFixGame.GameData;

namespace HotFixGame.HotControll
{
    public class LobbyPage : HotUIPage
    {
        class View
        {
            public HImage Head;
            public HText Level;
            public HText CNum;
            public UserEvent Diamond;
            public HText DNum;
            public UserEvent Mail;
            public UserEvent Bag;
            public UserEvent Setting;
        }
        class GameItem
        {
            public UserEvent Item;
            public HImage Image;
            public HText Text;
        }
        class RoomItem
        {
            public Text name;
            public Text Num;
            public UserEvent joinroom;
        }
        View view;
        public override void Initial(Transform parent, object dat = null)
        {
            base.Initial(parent, dat);
            view = LoadUI<View>("baseUI", "GameLobby");
            InitialEvent();
            LoadData();
            PopUpWindow<GameTypeWindow>();
        }
        void InitialEvent()
        { 
        }
        void LoadData()
        {
            var info = UserData.userInfo;
            view.Level.Text = "lv:" + info.level;
            view.CNum.Text = GetCount(info.coins);
            view.DNum.Text = info.diamond.ToString();
        }
        string GetCount(long num)
        {
            if (num >= 10000000000000)
            {
                return (num / 1000000000000).ToString() + "T";
            }
            else if (num >= 10000000000)
            {
                return (num / 1000000000).ToString() + "B";
            }
            else if (num >= 10000000)
            {
                return (num / 1000000).ToString() + "M";
            }
            else if (num >= 10000)
            {
                return (num / 1000).ToString() + "K";
            }
            return num.ToString();
        }
        public override void Cmd(DataBuffer dat)
        {
            
        }
    }
}
