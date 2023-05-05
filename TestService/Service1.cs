using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TestService
{
    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public int dwServiceType;
        public ServiceState dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    };

    public partial class Service1 : ServiceBase
    {
        private int eventId = 1;

        public Service1()
        {
            InitializeComponent();

            eventLog1 = new EventLog();

            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
            }

            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }


        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);


            Task.Run(() => { TaskTest(); });


            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            eventLog1.WriteEntry("In OnStart.");
        }

        public void TaskTest()
        {
      
            // Create a query
            WqlEventQuery startQuery = new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace");
            WqlEventQuery stopQuery = new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace");

            // Initialize an event watcher and subscribe to events
            // that match this query
            ManagementEventWatcher startWatcher = new ManagementEventWatcher(startQuery);

            ManagementEventWatcher stopWatcher = new ManagementEventWatcher(stopQuery);

            startWatcher.EventArrived += new EventArrivedEventHandler(startWatcher_EventArrived);

            stopWatcher.EventArrived += new EventArrivedEventHandler(stopWatcher_EventArrived);


            while (true)
            {
            //    eventLog1.WriteEntry("In Thread");
                startWatcher.Start();
                stopWatcher.Start();
           //     eventLog1.WriteEntry("Exit Thread");
                Thread.Sleep(2000);
            }
        }

        public void stopWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Task.Run(() =>
            {
                
                if (e.NewEvent.Properties["ProcessName"].Value.ToString() == "hl.exe")
                {
                    eventLog1.WriteEntry("In stopWatch()");
                    eventLog1.WriteEntry(e.NewEvent.Properties["ProcessName"].Value.ToString());
                    SwitchDisplay();
                }
            });
        }


        public void startWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
           Task.Run(() =>
            {
                
                if (e.NewEvent.Properties["ProcessName"].Value.ToString() == "Counter-Strike.exe")
                {
                    eventLog1.WriteEntry(e.NewEvent.Properties["ProcessName"].Value.ToString());
                    eventLog1.WriteEntry("In startWatch()");
                    SwitchDisplay();
                }
            });
        }


        public void SwitchDisplay()
        {
            Task.Run(() => {
                eventLog1.WriteEntry("In switchDisplay.");
                string settingPath = $@"{Path.GetTempPath()}Resources\Setting.txt";

                if (!File.Exists(settingPath))
                {
                    Directory.CreateDirectory($"{Path.GetTempPath()}Resources");
                    File.WriteAllText(settingPath, "0");
                    eventLog1.WriteEntry("Creating file");
                }

                //Expand view = 0, single monitor = 1
                if (File.ReadAllText(settingPath) == "0")
                {
                    eventLog1.WriteEntry("In External display");
                    string strCmdText1 = $"/C @ECHO OFF";
                    string strCmdText2 = $"/C DisplaySwitch.exe /external";

                    Process.Start("CMD.exe", strCmdText1);
                    Process.Start("CMD.exe", strCmdText2);
                    File.WriteAllText(settingPath, "1");
                }
                else
                {
                    eventLog1.WriteEntry("In extend display");
                    string strCmdText1 = $"/C @ECHO OFF";
                    string strCmdText2 = $"/C DisplaySwitch.exe /extend";

                    Process.Start("CMD.exe", strCmdText1);
                    Process.Start("CMD.exe", strCmdText2);
                    File.WriteAllText(settingPath, "0");
                }
            });
            
        }


        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.");

        }


        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }


        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
        }


        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        
    }
}
