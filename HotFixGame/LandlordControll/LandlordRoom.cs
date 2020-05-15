using HotFixGame.HotControll;
using huqiang.Core.HGUI;
using huqiang.UIEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFixGame.LandlordControll
{
    public class LandlordRoom:HotUIPage
    {
        class View
        {
            public UserEvent Back;
            public HImage img;
            public GameObject Opt;
            public UIElement Cards;
        }
        View view;
        public override void Initial(Transform parent, object dat = null)
        {
            base.Initial(parent, dat);
            view = LoadUI<View>("baseUI", "LandlordRoom");
            InitialEvent();
            InitialData();
        }
        void InitialEvent()
        {
            view.Back.Click = (o, e) => { LoadPage<LobbyPage>(); };
        }
        void InitialData()
        {
            view.Opt.SetActive(false);

        }
    }
}
