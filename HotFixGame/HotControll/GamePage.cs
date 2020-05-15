using HotFixGame.HotData;
using huqiang;
using huqiang.Data;
using huqiang.UIEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HotFixGame.HotControll
{
    public class GamePage:HotUIPage
    {
        class View
        {
            public UserEvent back;
        }
        View view;
        public override void Initial(Transform parent, object dat = null)
        {
            base.Initial(parent, dat);
            view = LoadUI<View>("baseUI", "GameRoom");
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
                //KcpDataControll.Instance.SendAesStream(db);
            };
        }
    }
}
