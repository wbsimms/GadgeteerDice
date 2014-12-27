//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GadgeteerDice {
    using Gadgeteer;
    using GTM = Gadgeteer.Modules;
    
    
    public partial class Program : Gadgeteer.Program {
        
        /// <summary>The USB Client DP module using socket 8 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.USBClientDP usbClientDP;
        
        /// <summary>The Multicolor LED module using socket 2 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.MulticolorLED multicolorLED;
        
        /// <summary>The Button module using socket 1 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.Button button;
        
        /// <summary>The BreadBoard X1 module using socket 18 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.BreadBoardX1 breadBoardX1;
        
        /// <summary>The Extender module using socket 14 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.Extender extender;
        
        /// <summary>This property provides access to the Mainboard API. This is normally not necessary for an end user program.</summary>
        protected new static GHIElectronics.Gadgeteer.FEZRaptor Mainboard {
            get {
                return ((GHIElectronics.Gadgeteer.FEZRaptor)(Gadgeteer.Program.Mainboard));
            }
            set {
                Gadgeteer.Program.Mainboard = value;
            }
        }
        
        /// <summary>This method runs automatically when the device is powered, and calls ProgramStarted.</summary>
        public static void Main() {
            // Important to initialize the Mainboard first
            Program.Mainboard = new GHIElectronics.Gadgeteer.FEZRaptor();
            Program p = new Program();
            p.InitializeModules();
            p.ProgramStarted();
            // Starts Dispatcher
            p.Run();
        }
        
        private void InitializeModules() {
            this.usbClientDP = new GTM.GHIElectronics.USBClientDP(8);
            this.multicolorLED = new GTM.GHIElectronics.MulticolorLED(2);
            this.button = new GTM.GHIElectronics.Button(1);
            this.breadBoardX1 = new GTM.GHIElectronics.BreadBoardX1(18);
            this.extender = new GTM.GHIElectronics.Extender(14);
        }
    }
}
