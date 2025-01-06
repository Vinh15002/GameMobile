using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Event
{
    public class ChooseButtonEvent
    {
        public delegate void ChangeOutline(int index);
        public static ChangeOutline changeOutLine;
    }
}
