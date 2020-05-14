using huqiang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFixGame.HotData
{
    public class DefCmd
    {
        public const Int32 Login = 0;
    }
    public class DefData
    {
        public static void Dispatch(DataBuffer data)
        {
            int cmd = data.fakeStruct[Req.Cmd];
            switch(cmd)
            {
                case DefCmd.Login:
                    Login(data);
                    break;
            }
        }
        static void Login(DataBuffer data)
        {

        }
    }
}
