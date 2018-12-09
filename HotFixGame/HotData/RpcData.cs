using huqiang.Data;
using System;

namespace HotFixGame.HotData
{
    public class RpcCmd
    {
        public const Int32 Login = 0;
        public const Int32 CreateRoom = 1;
        public const Int32 JoinRoom = 2;
        public const Int32 ExitRoom = 3;
        public const Int32 RoomDetail = 4;
        public const Int32 GamerReady = 5;
        public const Int32 HairCards = 6;
        public const Int32 CountDown = 7;
    }
    public class RpcData
    {
        public static void Dispatch(DataBuffer data)
        {
            int cmd = data.fakeStruct[Req.Cmd];
            switch (cmd)
            {
                case RpcCmd.Login:
                    Login(data);
                    break;
                case RpcCmd.CreateRoom:
                    CreateRoom(data);
                    break;
            }
        }
        static void Login(DataBuffer data)
        {

        }
        static void CreateRoom(DataBuffer data)
        {

        }
    }
}
