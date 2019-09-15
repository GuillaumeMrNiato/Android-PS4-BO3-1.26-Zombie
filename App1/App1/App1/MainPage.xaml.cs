using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PS4Lib;
using System.Collections.ObjectModel;

namespace App1
{
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        PS4API PS4 = new PS4API();
        public MainPage()
        {
            InitializeComponent();
          
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                PS4.ConnectTarget(PS4IP.Text);
                PS4.Notify(222, "Connected");
                ConnectLabel.Text = "PS4 Connected";
                ConnectLabel.TextColor = Color.ForestGreen;
                DisplayAlert("Information", "The PS4 is connected !", "OK");
            }
            catch
            {
                DisplayAlert("Information", "PS4 is not connected !", "OK");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                PS4.AttachProcess();
                PS4.Notify(222, "Process is attached");
                AttachLabel.Text = "Process attached";
                AttachLabel.TextColor = Color.ForestGreen;
                DisplayAlert("Information", "The process is attached !", "OK");
            }
            catch
            {
                DisplayAlert("Information", "Process can't be attached !", "OK");
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            PS4.Notify(222, "PS4 will be disconnected in 1 sec");
            PS4.DisconnectTarget();
            ConnectLabel.Text = "Connected ?";
            ConnectLabel.TextColor = Color.Red;
            AttachLabel.Text = "Process ?";
            AttachLabel.TextColor = Color.Red;
            DisplayAlert("Information", "PS4 has been disconnected !", "OK");
        }
        public string get_player_name(uint client)
        {
            string getnames = PS4.Extension.ReadString(0x21BED64 + client * 0x17010);
            return getnames;
        }     
        private void Button_Clicked_3(object sender, EventArgs e)
        {
            for (uint i = 0; i < 0x04; i++)
            {    
                client0.Text = PS4.Extension.ReadString(0x21BED64);
                client0label.Text = PS4.Extension.ReadString(0x21BED64);
                client1.Text = PS4.Extension.ReadString(0x21BED64 + 0x17010);
                client1label.Text = PS4.Extension.ReadString(0x21BED64 + 0x17010);
                client2.Text = PS4.Extension.ReadString(0x21BED64 + 0x17010 + 0x17010);
                client3.Text = PS4.Extension.ReadString(0x21BED64 + 0x17010 + 0x17010 + 0x17010);
            }
        }
        bool godmodeclient0 = false;
        bool ammoclient0 = false;
        bool pointsclient0 = false;
        bool hidehudclient0 = false;
        bool freezeclient0 = false;
        private void Button_Clicked_4(object sender, EventArgs e)
        {
            if (godmodeclient0 == false)
            {
                PS4.SetMemory(0x21A8180, new byte[] { 0x05 });
                DisplayAlert("Information", "God Mode Enabled for " + client0.Text, "Ok");
                godmodeclient0 = true;
            }
            else if (godmodeclient0 == true)
            {
                PS4.SetMemory(0x21A8180, new byte[] { 0x04 });
                DisplayAlert("Information", "God Mode Disabled for " + client0.Text, "Ok");
                godmodeclient0 = false;
            }
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            if (ammoclient0 == false)
            {
                PS4.SetMemory(0x21A87E8, new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory(0x21A87F0, new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory(0x21A87AC, new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory(0x21A87B4, new byte[] { 0xff, 0xff, 0xff });
                DisplayAlert("Information", "Unlimited Ammo given for " + client0.Text, "Ok");
                ammoclient0 = true;
            }
            else if (ammoclient0 == true)
            {
                PS4.SetMemory(0x21A87E8, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory(0x21A87F0, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory(0x21A87AC, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory(0x21A87B4, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                DisplayAlert("Information", "Unlimited Ammo removed for " + client0.Text, "Ok");
                ammoclient0 = false;
            }
        }

        private void Button_Clicked_6(object sender, EventArgs e)
        {
            if (pointsclient0 == false)
            {
                PS4.SetMemory(0x21BEE14, new byte[] { 0xff, 0xff, 0xff });
                DisplayAlert("Information", "Max Point given for " + client0.Text, "Ok");
                pointsclient0 = true;
            }
            else if (pointsclient0 == true)
            {
                PS4.SetMemory(0x21BEE14, new byte[] { 0x00, 0x00, 0x00 });
                DisplayAlert("Information", "Max Point reset for " + client0.Text, "Ok");
                pointsclient0 = false;
            }
        }

        private void Button_Clicked_7(object sender, EventArgs e)
        {
            if (hidehudclient0 == false)
            {
                PS4.SetMemory(0x21BEE5C, new byte[] { 0x01 });
                DisplayAlert("Information", "HUD is hidden for " + client0.Text, "Ok");
                hidehudclient0 = true;
            }
            else if (hidehudclient0 == true)
            {
                PS4.SetMemory(0x21BEE5C, new byte[] { 0x03 });
                DisplayAlert("Information", "HUD is visible for " + client0.Text, "Ok");
                hidehudclient0 = false;
            }
        }

        private void Button_Clicked_8(object sender, EventArgs e)
        {
            if (freezeclient0 == false)
            {
                PS4.SetMemory(0x21A8167, new byte[] { 0x01 });
                DisplayAlert("Information", "Freeze given to " + client0.Text, "Ok");
                freezeclient0 = true;
            }
            else if (freezeclient0 == true)
            {
                PS4.SetMemory(0x21A8167, new byte[] { 0x00 });
                DisplayAlert("Information", "Freeze removed for " + client0.Text, "Ok");
                freezeclient0 = false;
            }
        }

        private void Button_Clicked_9(object sender, EventArgs e)
        {
            PS4.SetMemory(0x21A8508, BitConverter.GetBytes((int)Convert.ToInt32(weaponsclients0.Text)));
            DisplayAlert("Information", "Weapon changed for " + client0label.Text, "Ok");
        }

        private void Button_Clicked_10(object sender, EventArgs e)
        {
            PS4.Extension.WriteString(0x21BED64, nameclient0.Text);
            DisplayAlert("Information", "Name changed to " + nameclient0.Text, "Ok");
        }

        bool godmodeclient1 = false;
        bool ammoclient1 = false;
        bool pointsclient1 = false;
        bool hidehudclient1 = false;
        bool freezeclient1 = false;
        private void Button_Clicked_11(object sender, EventArgs e)
        {
            if (godmodeclient1 == false)
            {
                PS4.SetMemory(0x21A8180 + 0x17010, new byte[] { 0x05 });
                DisplayAlert("Information", "God Mode Enabled for " + client1.Text, "Ok");
                godmodeclient1 = true;
            }
            else if (godmodeclient1 == true)
            {
                PS4.SetMemory(0x21A8180 + 0x17010, new byte[] { 0x04 });
                DisplayAlert("Information", "God Mode Disabled for " + client1.Text, "Ok");
                godmodeclient1 = false;
            }
        }

        private void Button_Clicked_12(object sender, EventArgs e)
        {
            if (ammoclient1 == false)
            {
                PS4.SetMemory(0x21A87E8 + 0x17010, new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory(0x21A87F0 + 0x17010, new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory(0x21A87AC + 0x17010, new byte[] { 0xff, 0xff, 0xff });
                PS4.SetMemory(0x21A87B4 + 0x17010, new byte[] { 0xff, 0xff, 0xff });
                DisplayAlert("Information", "Unlimited Ammo given for " + client1.Text, "Ok");
                ammoclient1 = true;
            }
            else if (ammoclient1 == true)
            {
                PS4.SetMemory(0x21A87E8 + 0x17010, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory(0x21A87F0 + 0x17010, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory(0x21A87AC + 0x17010, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                PS4.SetMemory(0x21A87B4 + 0x17010, new byte[] { 0x10, 0x00, 0x00, 0x00 });
                DisplayAlert("Information", "Unlimited Ammo removed for " + client1.Text, "Ok");
                ammoclient1 = false;
            }
        }

        private void Button_Clicked_13(object sender, EventArgs e)
        {
            if (pointsclient1 == false)
            {
                PS4.SetMemory(0x21BEE14 + 0x17010, new byte[] { 0xff, 0xff, 0xff });
                DisplayAlert("Information", "Max Point given for " + client1.Text, "Ok");
                pointsclient1 = true;
            }
            else if (pointsclient1 == true)
            {
                PS4.SetMemory(0x21BEE14 + 0x17010, new byte[] { 0x00, 0x00, 0x00 });
                DisplayAlert("Information", "Max Point reset for " + client1.Text, "Ok");
                pointsclient1 = false;
            }
        }

        private void Button_Clicked_14(object sender, EventArgs e)
        {
            if (hidehudclient1 == false)
            {
                PS4.SetMemory(0x21BEE5C + 0x17010, new byte[] { 0x01 });
                DisplayAlert("Information", "HUD is hidden for " + client1.Text, "Ok");
                hidehudclient1 = true;
            }
            else if (hidehudclient1 == true)
            {
                PS4.SetMemory(0x21BEE5C + 0x17010, new byte[] { 0x03 });
                DisplayAlert("Information", "HUD is visible for " + client1.Text, "Ok");
                hidehudclient1 = false;
            }
        }

        private void Button_Clicked_15(object sender, EventArgs e)
        {
            if (freezeclient1 == false)
            {
                PS4.SetMemory(0x21A8167 + 0x17010, new byte[] { 0x01 });
                DisplayAlert("Information", "Freeze given to " + client1.Text, "Ok");
                freezeclient1 = true;
            }
            else if (freezeclient1 == true)
            {
                PS4.SetMemory(0x21A8167 + 0x17010, new byte[] { 0x00 });
                DisplayAlert("Information", "Freeze removed for " + client1.Text, "Ok");
                freezeclient1 = false;
            }
        }

        private void Button_Clicked_16(object sender, EventArgs e)
        {
            PS4.SetMemory(0x21A8508 + 0x17010, BitConverter.GetBytes((int)Convert.ToInt32(weaponsclients1.Text)));
            DisplayAlert("Information", "Weapon changed for " + client1label.Text, "Ok");
        }

        private void Button_Clicked_17(object sender, EventArgs e)
        {
            PS4.Extension.WriteString(0x21BED64 + 0x17010, nameclient1.Text);
            DisplayAlert("Information", "Name changed to " + nameclient1.Text, "Ok");
        }
    }
}
