using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotFixGame.GameData
{
    public class GameTypeItem
    {
        public string Image;
        public int Cmd;
        public string Tip;
        public static GameTypeItem[] AllData = new GameTypeItem[] {
         new GameTypeItem(){ Image="",Cmd=0,Tip="斗地主" },
         new GameTypeItem(){ Image="",Cmd=1,Tip="跑的快" },
         new GameTypeItem(){ Image="",Cmd=2,Tip="炸金花" },
         new GameTypeItem(){ Image="",Cmd=3,Tip="德州扑克" },
         new GameTypeItem(){ Image="",Cmd=3,Tip="升级" },
         new GameTypeItem(){ Image="",Cmd=3,Tip="牛牛" }
        };
    }
}
