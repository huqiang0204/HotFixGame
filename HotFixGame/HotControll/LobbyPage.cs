using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using huqiang.UIModel;

namespace HotFixGame.HotControll
{
    public class LobbyPage : HotPage
    {
        public override void Initial(Transform parent, object dat = null)
        {
            base.Initial(parent, dat);
            ModelManager.LoadToGameR("GameLobby", null, parent);
        }
    }
}
