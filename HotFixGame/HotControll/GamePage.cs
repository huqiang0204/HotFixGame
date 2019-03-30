using HotFixGame.HotData;
using huqiang;
using huqiang.Data;
using huqiang.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace HotFixGame.HotControll
{
    class GameView
    {
        public EventCallBack back;
        public Image img;
    }
    public class GamePage:HotPage
    {
        GameView view;
        public override void Initial(Transform parent, object dat = null)
        {
            view = new GameView();
            var list = ReflectionEx.ClassToList(view);
            model = ModelManager.LoadToGameR("GameRoom", list, parent);
            ReflectionEx.ListToClass(list, view);
            base.Initial(parent, dat);
            InitialEvent();
        }
        void InitialEvent()
        {
            view.back.Click = (o, e )=> {
                DataBuffer db = new DataBuffer();
                var fake = new FakeStruct(db, Req.Length);
                fake[Req.Cmd] = RpcCmd.ExitRoom;
                fake[Req.Type] = MessageType.Rpc;
                db.fakeStruct = fake;
                KcpDataControll.Instance.SendAesStream(db);
            };
        }
    }
}
