using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFixGame.HotData
{
    public class UserInfo
    {
        public long id;//id
        public string deviceId;//设备id
        public string key;
        public string pass;
        public string name;
        public int sex;
        public string roleid;//图片名称
        public int RoomId;//房间id
        public long LastLogin;//最后登录时间
        public long LastExit;//最后退出时间
        public long coins;
        public long diamond;
    }
}
