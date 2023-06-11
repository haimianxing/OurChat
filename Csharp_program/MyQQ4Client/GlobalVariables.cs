using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ4Client
{
    public static class GlobalVariables
    {
        //在线检查标志
        //只有offline/online
        public static string isOnline = "offline";

        public static string myname = "";

        public static int id = -1;

        public static int destiny_id = -1;

        public static MainForm mainForm = null;
    }
}
