using huqiang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotFixGame.HotData
{
     public class HotDataControll
    {
        public static void Dispatch(DataBuffer buffer)
        {
            var type = buffer.fakeStruct[Req.Type];
            switch(type)
            {
                case MessageType.Def:
                    DefData.di
                    break;
                case MessageType.Rpc:
                    RpcData.Dispatch(buffer);
                    break;
            }
            var page = HotUIPage.CurrentPage;
            if (page != null)
                page.Cmd(buffer);
        }
    }
}
