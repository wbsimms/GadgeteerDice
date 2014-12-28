using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;
using Gadgeteer.SocketInterfaces;

namespace GadgeteerDice
{
    public partial class Program
    {
        Random rnd = new Random(DateTime.UtcNow.Millisecond);
        private DigitalOutput d1_1;
        private DigitalOutput d1_2;
        private DigitalOutput d1_3;
        private DigitalOutput d1_4;
        private DigitalOutput d1_5;
        private DigitalOutput d1_6;
        ArrayList d1list;

        private DigitalOutput d2_1;
        private DigitalOutput d2_2;
        private DigitalOutput d2_3;
        private DigitalOutput d2_4;
        private DigitalOutput d2_5;
        private DigitalOutput d2_6;
        ArrayList d2list;

        void ProgramStarted()
        {
            Debug.Print("Program Started");
            button.ButtonPressed += button_ButtonPressed;
            d1_1 = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Nine, true);
            d1_2 = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Eight, true);
            d1_3 = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Seven, true);
            d1_4 = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Six, true);
            d1_5 = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Five, true);
            d1_6 = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Four, true);
            d1list = new ArrayList() { d1_1, d1_2, d1_3, d1_4, d1_5, d1_6 };

            d2_1 = extender.CreateDigitalOutput(GT.Socket.Pin.Nine, true);
            d2_2 = extender.CreateDigitalOutput(GT.Socket.Pin.Eight, true);
            d2_3 = extender.CreateDigitalOutput(GT.Socket.Pin.Seven, true);
            d2_4 = extender.CreateDigitalOutput(GT.Socket.Pin.Six, true);
            d2_5 = extender.CreateDigitalOutput(GT.Socket.Pin.Five, true);
            d2_6 = extender.CreateDigitalOutput(GT.Socket.Pin.Four, true);
            d2list = new ArrayList() { d2_1, d2_2, d2_3, d2_4, d2_5, d2_6};

        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            RollDice();
            int value1 = rnd.Next(6);
            int value2 = rnd.Next(6);
            for (int i = 0; i <= value1; i++)
            {
                ((DigitalOutput)d1list[i]).Write(true);
            }

            for (int i = 0; i <= value2; i++)
            {
                ((DigitalOutput)d2list[i]).Write(true);
            }
        }

        public void RollDice()
        {
            for (int i = 0; i <= 5; i++)
            {
                ((DigitalOutput)d1list[i]).Write(false);
                ((DigitalOutput)d2list[i]).Write(false);
                Thread.Sleep(50);
            }

            for (int i = 0; i <= 5; i++)
            {
                ((DigitalOutput)d1list[i]).Write(true);
                ((DigitalOutput)d2list[i]).Write(true);
                Thread.Sleep(50);
            }

            for (int i = 0; i <= 5; i++)
            {
                ((DigitalOutput)d1list[i]).Write(false);
                ((DigitalOutput)d2list[i]).Write(false);
                Thread.Sleep(50);
            }
        }
    }
}
