using HotFixGame.GameData;
using HotFixGame.LandLordControll;
using huqiang.Core.HGUI;
using huqiang.Data;
using huqiang.UIComposite;
using huqiang.UIEvent;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotFixGame.HotControll
{
    public class GameTypeWindow:HotPopWindow
    {
        class View
        {
            public ScrollX Games;
        }
        class GameItem
        {
            public HImage Image;
            public HText Text;
        }
        View view;
        public override void Initial(Transform parent, HotUIPage page, object dat = null)
        {
            base.Initial(parent, page, dat);
            view = LoadUI<View>("baseUI", "GameTypes");
            InitialEvent();
            LoadData();
        }
        void LoadData()
        {

        }
        void InitialEvent()
        {
            view.Games.scrollType = ScrollType.Loop;
            view.Games.BindingData = GameTypeItem.AllData;
            view.Games.SetItemUpdate(new HotConstructor<GameItem, GameTypeItem>(ItemUpdate).middle);
            view.Games.Refresh();
        }
        void ItemUpdate(GameItem item, GameTypeItem type, int index)
        {
            var tex = ElementAsset.FindTexture("base.unity3d", type.Image);
            item.Image.MainTexture = tex;
            item.Text.Text = type.Tip;
            var user = item.Image.userEvent;
            user.DataContext = type;
            user.Click = ItemClick;
        }
        void ItemClick(UserEvent user, UserAction action)
        {
            var type = user.DataContext as GameTypeItem;
            switch (type.Cmd)
            {
                case 0:
                    mainPage.PopUpWindow<LandlordLobby>();
                    break;
                case 1:
                    break;
            }
        }
    }
}
