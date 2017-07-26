using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AccountAssistant
{
    public class AppBase
    {
        public static System.Windows.Media.Color GetRandomColor(int index)
        {
            Color[] items = new Color[] { Colors.Green, Colors.Red, Colors.Blue, Colors.Brown, Colors.Aqua, Colors.DarkRed };

            if (index >= 0 || index < items.Length)
            {
                return items[index];
            }

            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            //  对于C#的随机数，没什么好说的
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);

            //  为了在白色背景上显示，尽量生成深色
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;

            return System.Windows.Media.Color.FromRgb((byte)int_Red, (byte)int_Green, (byte)int_Blue);
        }
    }
}
