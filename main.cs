using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using Microsoft.VisualBasic;
using System.IO;
using System.Security.Cryptography;
using DiscordRpcDemo;


namespace HK4X
{
    public partial class main : Form
    {
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            username.Text = "Username : " + File.ReadAllText("C:\\username");
            expiry.Text = "Expiry date: " + File.ReadAllText("C:\\expiry");
            timer1.Start();

            this.handlers = new DiscordRpc.EventHandlers();
            DiscordRpc.Initialize("1016928250192211998", ref this.handlers, true, (string)null);
            this.handlers = new DiscordRpc.EventHandlers();
            DiscordRpc.Initialize("1016928250192211998", ref this.handlers, true, (string)null);
            this.presence.smallImageKey = "38b5250d-5145-46f8-acf8-274ffc516df5";
            this.presence.smallImageText = "HK4x PANELS";
            this.presence.startTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        const int WM_NCHITTEST = 0x84;
        const int HTCLIENT = 0x1;
        const int HTCAPTION = 0x2;


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        [DllImport("KERNEL32.DLL")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);


        private async Task PutTaskDelay(int Time)
        {
            await Task.Delay(Time);
        }
        private async Task<IntPtr> HK4X_HACKS_NICE(string type)
        {
            string Bluestacks = "HD-Plater";
            string Bluestack2 = "HD-Player.exe";
            string memu = "MEmuHeadless";
            string Gameloop = "aow_exe";
            string SmartGaGA = "AndroidProcess.exe";
            string ld = "LdVBoxHeadless.exe";
            IntPtr intPtr = IntPtr.Zero;
            uint num = 0u;
            IntPtr intPtr2 = CreateToolhelp32Snapshot(2u, 0u);
            if ((int)intPtr2 > 0)
            {
                ProcessEntry32 processEntry = default(ProcessEntry32);
                processEntry.dwSize = (uint)Marshal.SizeOf(processEntry);
                for (int num2 = Process32First(intPtr2, ref processEntry); num2 == 1; num2 = Process32Next(intPtr2, ref processEntry))
                {
                    IntPtr intPtr3 = Marshal.AllocHGlobal((int)processEntry.dwSize);
                    Marshal.StructureToPtr(processEntry, intPtr3, fDeleteOld: true);
                    ProcessEntry32 processEntry2 = (ProcessEntry32)Marshal.PtrToStructure(intPtr3, typeof(ProcessEntry32));
                    Marshal.FreeHGlobal(intPtr3);
                    if (processEntry2.szExeFile.Contains(Bluestacks) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)processEntry2.th32ProcessID;
                    }
                    if (processEntry2.szExeFile.Contains(memu) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)processEntry2.th32ProcessID;
                    }
                    if (processEntry2.szExeFile.Contains(Gameloop) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)processEntry2.th32ProcessID;
                    }
                    if (processEntry2.szExeFile.Contains(Bluestack2) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)processEntry2.th32ProcessID;
                    }
                    if (processEntry2.szExeFile.Contains(SmartGaGA) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)processEntry2.th32ProcessID;
                    }
                    if (processEntry2.szExeFile.Contains(ld) && processEntry2.cntThreads > num)
                    {
                        num = processEntry2.cntThreads;
                        intPtr = (IntPtr)processEntry2.th32ProcessID;
                    }
                }
                PID.Text = Convert.ToString(intPtr);
                await PutTaskDelay(1000);

                switch (type)
                {                           //▂▃▅▇█▓▒░H K 4 X ░▒▓█▇▅▃▂\\


                                           case "AIMBOT LOGIN": AIMBOTLOGIN(); break;   // HK4X GOD
                                           case "AIMBOT LOBBY": AIMBOTLOBBY(); break;   // HK4X GOD
                                           case "NO RECOIL": NORECOIL(); break;      // HK4X GOD
                                           case "BYPASS ANTIBAN": BYPASSANTIBAN(); break; // HK4X GOD
                                           case "BYPASS FULL": BYPASSFULL(); break;    // HK4X GOD
                                           case "ESP": ESP(); break;           // HK4X GOD
                                           case "AIMLOCK": AIMLOCK(); break;       // HK4X GOD
                                           case "AIMLOCK V2": AIMLOCKV2(); break;     // HK4X GOD
                                           case "AIMNECK LOBBY": AIMNECKLOBBY(); break;  // HK4X GOD
                                           case "SENSIPRO": SENSIPRO(); break;      // HK4X GOD
                                           case "AIMNECK": AIMNECK(); break;       // HK4X GOD
                                           case "MAGICBULLET": magic_bullet(); break;  // HK4X GOD
                                           case "ANTI": ANTIBAN(); break;       // HK4X GOD
                                           case "EXACTLY": EXACTLY(); break;       // HK4X GOD
                                           case "FAKEDAMAGE": FAKEST(); break;        // HK4X GOD
                }

            }                               //▁ ▂ ▄ ▅ ▆ ▇ █ HK4X █ ▇ ▆ ▅ ▄ ▂ ▁\\ 

            return intPtr;
        }
        private string sr;
        public async void AIMBOTLOGIN()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "5F 48 69 70 73 62", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "5F 48 65 61 64 62", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }

        public async void AIMBOTLOBBY()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "62 00 6F 00 6E 00 65 00 5F 00 48 00 69 00 70 00 73 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 09 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 ?? 00 65 00 ?? 00 ?? 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 79 00 74 00 65 00 73 00 ?? 00 6E 00 6B 00 6E 00 6F 00 77 00 6E", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void NORECOIL()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 0A 81 EE 10 0A 10 EE 10 8C BD E8 00 00 00 00 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("NORECOIL");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void BYPASSANTIBAN()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "0A 00 A0 E3 6E 00 54 E3 3F 00 00 13 10 8C BD E8", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 F0 20 E3", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("NORECOIL");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void BYPASSFULL()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "01 00 A0 E3 1E FF 2F E1", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("NORECOIL");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void ESP()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "69 00 6E 00 67 00 61 00 6D 00 65 00 2F 00 63 00 61 00 70 00 73 00 75 00 6C 00 65 00 68 00 75 00 6D 00 61 00 6E 00 73 00 6E 00 69 00 70 00 65 00 72 00 63 00 6F 00 6C 00 6C 00 69 00 64 00 65 00 72 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "65 00 66 00 66 00 65 00 63 00 74 00 73 00 2F 00 62 00 72 00 5F 00 61 00 69 00 72 00 64 00 72 00 6F 00 70 00 6C 00 69 00 67 00 68 00 74 00 6C 00 65 00 76 00 65 00 6C 00 31 00 00 00 00 00 00 00 00 00", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("NORECOIL");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void AIMLOCK()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "7F 45 4C 46 01 01 01 00", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "70 4C 2D E9 10 B0 8D E1", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("NORECOIL");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void AIMLOCKV2()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "30 19 8F 05", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "D0 64 C1 00", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("NORECOIL");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void AIMNECKLOBBY()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "62 00 6F 00 6E 00 65 00 5F 00 48 00 69 00 70 00 73 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 62 00 6F 00 6E 00 65 00 5F 00 48 00 65 00 61 00 64", true, true, string.Empty);
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "62 00 6F 00 6E 00 65 00 5F 00 4E 00 65 00 63 00 6B", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("NORECOIL");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void SENSIPRO()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "DB 0F 49 40 DB 0F 49 40", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 A0 40 00 00 A0 40", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void AIMNECK()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "62 6f 6e 65 5f 48 69 70 73", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "62 6f 6e 65 5f 4e 65 63 6b", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void magic_bullet()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "7F 45 4C 46 01 01 01 00", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 80 3F", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void ANTIBAN()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "0A 00 A0 E3 1E FF 2F E1 0D 00 A0 E3 1E FF 2F E1", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 F0 20 E3", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void EXACTLY()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "00 00 40 3F 00 00 80 3F 00 00 40 3F 33 33 33 40", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "00 00 00 00 00 00 80 3F 00 00 40 3F 33 33 33 40", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void FAKEST()
        {
            bool k = false;
            int counter = 1;
            if (Convert.ToInt32(PID.Text) == 0)
            {
                HK.ForeColor = Color.Red;
                HK.Text = "SRY";
            }
            else
            {
                HK.ForeColor = Color.Green;
                HK.Text = "LOL";
                MemLib.OpenProcess(Convert.ToInt32(PID.Text));

                Thread.Sleep(2000);

                HK.ForeColor = Color.Orange;
                HK.Text = "STARTING....";

                var enumerable = await MemLib.AoBScan(0x0000000000000000, 0x00007fffffffffff, "00 00 B0 40 00 00 80 3F 00 00 40 3F 00 00 80 3F", true, true, string.Empty); // 
                string_0 = "0x" + enumerable.FirstOrDefault().ToString("X");
                Mem.MemoryProtection memoryProtection;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadWrite, out memoryProtection, "");
                foreach (long num in enumerable)
                {
                    MemLib.WriteMemory(num.ToString("X"), "bytes", "23 C7 0A 5F 23 C7 0A 5F 00 00 40 3F 00 00 80 3F", string.Empty, null);
                    k = true;
                }

                if (k == true)
                {
                    HK.Text = "ON";
                    HK.ForeColor = Color.Green;
                    await PutTaskDelay(500);
                }
                else if (counter < 4)
                {
                    HK.ForeColor = Color.Red;
                    HK.Text = "SRY";
                    counter += 1;
                    await HK4X_HACKS_NICE("AIMBOT");
                }
                else
                {
                    HK.Text = "Not applied...";
                    HK.ForeColor = Color.Red;
                }

                Mem.MemoryProtection memoryProtection2;
                MemLib.ChangeProtection(string_0, Mem.MemoryProtection.ReadOnly, out memoryProtection2, "");
            }
        }
        public async void DRIERSSSS_LOAD_AUTO_IN_PROCESSS(string type)
        {
            x = 0;
            await HK4X_HACKS_NICE(type);
        }
        public long enumerable = new long();

        private int x;
        public Mem MemLib = new Mem();
        private static string string_0;
        private IContainer icontainer_0;
        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMBOT LOGIN");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMBOT LOBBY");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMLOCK");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMLOCK V2");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMNECK LOBBY");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("NO RECOIL");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("BYPASS FULL");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("BYPASS ANTIBAN");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("ESP");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch11_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("AIMNECK");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("SENSIPRO");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch12_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("MAGICBULLET");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch13_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("ANTI");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch14_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("EXACTLY");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }

        private void guna2ToggleSwitch15_CheckedChanged(object sender, EventArgs e)
        {
            this.DRIERSSSS_LOAD_AUTO_IN_PROCESSS("FAKEDAMAGE");
            HK.Text = "connect to HK4x";
            HK.ForeColor = Color.Red;
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/eT3ZxpH8Kx");
        }

        private void guna2PictureBox44_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://hk4x-help.hk4x321.repl.co/");
        }

        private void guna2PictureBox49_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://hk4x-official.mmgamer1.repl.co/");
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/eT3ZxpH8Kx");
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/EfzVDDTuNW");
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/wqb2nWZ36G");
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/gTspMG53CA");
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/TrCvgMJMpY");
        }

        private void time_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton7_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton7_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youtu.be/duey8gUPYME");
        }
    }
} //▂▃▅▇█▓▒░H K 4 X GOD ░▒▓█▇▅▃▂