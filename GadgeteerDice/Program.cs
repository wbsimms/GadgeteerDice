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
        private DigitalOutput d1_7;
        ArrayList d1list;

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
            d1_7 = breadBoardX1.CreateDigitalOutput(GT.Socket.Pin.Three, true);
            d1list = new ArrayList() { d1_1, d1_2, d1_3, d1_4, d1_5, d1_6, d1_7};
        }

        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            RollDice();
            int value = rnd.Next(7);
            for (int i = 0; i <= value; i++)
            {
                ((DigitalOutput)d1list[i]).Write(true);
            }

        }

        public void RollDice()
        {
            for (int i = 0; i <= 6; i++)
            {
                ((DigitalOutput)d1list[i]).Write(false);
                Thread.Sleep(50);
            }

            for (int i = 0; i <= 6; i++)
            {
                ((DigitalOutput)d1list[i]).Write(true);
                Thread.Sleep(50);
            }

            for (int i = 0; i <= 6; i++)
            {
                ((DigitalOutput)d1list[i]).Write(false);
                Thread.Sleep(50);
            }
        }
    }
}
