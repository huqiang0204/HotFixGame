using DataControll;
using HotFixGame.HotData;
using huqiang.UIEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HotFixGame.HotControll
{
    public class LoginPage : HotUIPage
    {
        class View
        {
            public UserEvent Tourists;
            public UserEvent Account;
            public UserEvent Enroll;
        }
        class Login
        {
            public string type;
            public string key;
            public string pass;
            public string extand;
        }
        View view;
        public override void Initial(Transform parent, object dat = null)
        {
            base.Initial(parent, dat);
            view = LoadUI<View>("baseUI","Login");
            InitialEvent();
            KcpDataControll.Instance.Redirect("192.168.0.134",8899);
        }
        void InitialEvent()
        {
            view.Tourists.Click = (o, e) => {
                Login login = new Login();
                login.type = "Tourists";
                login.key = SystemInfo.deviceUniqueIdentifier;
                KcpDataControll.Instance.SendString(DefCmd.Login,MessageType.Def,TinyJson.JSONWriter.ToJson(login));
            };
        }
        
    }
}
