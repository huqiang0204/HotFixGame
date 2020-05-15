using HotFixGame.HotControll;
using huqiang.UIEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HotFixGame.LandLordControll
{
    public class LandlordLobby:HotPopWindow
    {
        class View
        {
            public UserEvent Back;
            public UserEvent Single;
            public UserEvent Multi;
            public UserEvent Create;
        }
        View view;
        public override void Initial(Transform parent, HotUIPage page, object dat = null)
        {
            base.Initial(parent,page, dat);
            view = LoadUI<View>("baseUI", "LandlordLobby");
            InitialEvent();
            LoadData();
        }
        void InitialEvent()
        {
            view.Back.Click = (o, e) => { mainPage.PopUpWindow<GameTypeWindow>(); };
        }
        void LoadData()
        {

        }
    }
}
