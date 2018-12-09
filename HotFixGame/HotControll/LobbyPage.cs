using System;
using UnityEngine;
using huqiang.UIModel;
using huqiang.Data;
using huqiang;
using UnityEngine.UI;
using HotFixGame.HotData;

namespace HotFixGame.HotControll
{
    class LobbyView
    {
        public ScrollY roomlist;
        public EventCallBack creatroom;
        public GameObject pop;
        public TextInputEvent input;
        public EventCallBack ok;
        public EventCallBack cancel;
    }
    class RoomItem
    {
        public Text name;
        public Text Num;
        public EventCallBack joinroom;
    }
    public class LobbyPage : HotPage
    {
        LobbyView view;
        public override void Initial(Transform parent, object dat = null)
        {
            view = new LobbyView();
            var list = ReflectionEx.ClassToList(view);
            model = ModelManager.LoadToGameR("GameLobby",list, parent);
            ReflectionEx.ListToClass(list,view);
            base.Initial(parent, dat);
            InitialEvent();
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
                    TcpDataControll.Instance.SendAesStream(db);
                }
            };
        }
        public override void Cmd(DataBuffer dat)
        {
            
        }
    }
}
