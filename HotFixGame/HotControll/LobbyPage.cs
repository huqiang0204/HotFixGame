using System;
using UnityEngine;
using huqiang.Data;
using huqiang;
using UnityEngine.UI;
using HotFixGame.HotData;
using huqiang.UIComposite;
using huqiang.UIEvent;

namespace HotFixGame.HotControll
{
    public class LobbyPage : HotUIPage
    {
        class View
        {
            public ScrollY roomlist;
            public UserEvent creatroom;
            public GameObject pop;
            public TextInput input;
            public UserEvent ok;
            public UserEvent cancel;
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
            //InitialEvent();
        }
        void InitialEvent()
        {
            view.pop.SetActive(false);
            view.creatroom.Click = (o, e) => { view.pop.SetActive(true); };
            view.cancel.Click = (o, e) => { view.pop.SetActive(false); };
            view.ok.Click = (o, e) => {
                string name =view.input.InputString;
                if(name!=null& name!="")
                {
                    DataBuffer db = new DataBuffer();
                    var fake = new FakeStruct(db,Req.Length);
                    fake[Req.Cmd] = RpcCmd.CreateRoom;
                    fake[Req.Type] = MessageType.Rpc;
                    fake.SetData(Req.Args,name);
                    db.fakeStruct = fake;
                    //KcpDataControll.Instance.SendAesStream(db);
                }
            };
        }
        public override void Cmd(DataBuffer dat)
        {
            
        }
    }
}
