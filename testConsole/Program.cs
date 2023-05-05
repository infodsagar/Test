using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using Threading = System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;


public class Test
{

    public delegate void FirstDel();
    

    static void Main(string[] args)
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        var handle = GetConsoleWindow();

        
        ShowWindow(handle, SW_SHOW);


        Test test = new Test();


        
    }

    public void TaskTest()
    {
          Debug.WriteLine("In thread");
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
            Debug.WriteLine("Waiting");
            startWatcher.Start();
            stopWatcher.Start();
            Debug.WriteLine("Detected");
            Thread.Sleep(2000);
        }
    }

    static void stopWatcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        Threading.Task.Run(() =>
        {
            if (e.NewEvent.Properties["ProcessName"].Value.ToString() == "hl.exe")
            {
                Test.SwitchDisplay();
            }
        });
    }


    static void startWatcher_EventArrived(object sender, EventArrivedEventArgs e)
    {
        Threading.Task.Run(() =>
        {
            Debug.WriteLine("In start");
            if (e.NewEvent.Properties["ProcessName"].Value.ToString() == "Counter-Strike.exe")
            {
                SwitchDisplay();
            }
        });
    }


    public void counterWatch()
    {

        Process[] counterStrike = Process.GetProcessesByName("counter-strike");
        Process[] hl = Process.GetProcessesByName("hl");

        if(counterStrike.Length > 0)
        {
            Debug.WriteLine($"counter-strike is running, process ID: {counterStrike[0].Id}");
        }

        if(hl.Length > 0)
        {
            Debug.WriteLine("hl is running");
        }
    }


    public static void SwitchDisplay()
    {
        string settingPath = $@"{Path.GetTempPath()}Resources\Setting.txt";

        if (!File.Exists(settingPath))
        {
            Directory.CreateDirectory($"{Path.GetTempPath()}Resources");
            File.WriteAllText(settingPath, "0");
        }


        //Expand view = 0, single monitor = 1
        if (File.ReadAllText(settingPath) == "0")
        {
            string strCmdText1 = $"/C @ECHO OFF";
            string strCmdText2 = $"/C DisplaySwitch.exe /external";

            System.Diagnostics.Process.Start("CMD.exe", strCmdText1);
            System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
            File.WriteAllText(settingPath, "1");
        }
        else
        {
            string strCmdText1 = $"/C @ECHO OFF";
            string strCmdText2 = $"/C DisplaySwitch.exe /extend";

            System.Diagnostics.Process.Start("CMD.exe", strCmdText1);
            System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
            File.WriteAllText(settingPath, "0");
        }
    }


    public void Print()
    {
        Console.WriteLine("Hi");
    }


    public void Print2()
    {
        Console.WriteLine("Hi2");
    }


    public void CreateDoc()
    {
        try
        {
            Word.Application winword = new Word.Application();

            //Set animation status for word application  
            winword.ShowAnimation = false;

            //Set status for word application is to be visible or not.  
            winword.Visible = false;

            //Create a missing variable for missing value  
            object missing = System.Reflection.Missing.Value;

            //Create a new document  
            Word.Document oDoc = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            oDoc.Paragraphs.SpaceAfter = 8;

            object oMissing = System.Reflection.Missing.Value;
            var para1 = oDoc.Paragraphs.Add();
            para1.set_Style("Heading 2");
            para1.Range.Text = String.Format($"This is line #");
        //    para1.Range.ParagraphFormat.SpaceAfter = 0;
            para1.Range.InsertParagraphAfter();


            var para2 = oDoc.Paragraphs.Add();
            para2.Range.Text = String.Format("This is line # 2");
         //   para2.Range.ParagraphFormat.SpaceAfter = 8;
            para2.Range.InsertParagraphAfter();

            
            // Insert table
            var pTable = oDoc.Paragraphs.Add();
            pTable.Format.SpaceAfter = 10f;
            var table = oDoc.Tables.Add(pTable.Range, 2, 3, WdDefaultTableBehavior.wdWord9TableBehavior);

            /*
            var p2Text = oDoc.Paragraphs.Add();
            p2Text.Format.SpaceAfter = 10f;
            p2Text.Range.Text = String.Format("This is line #");
            p2Text.Range.InsertParagraphAfter();

            // Insert table
            var p2Table = oDoc.Paragraphs.Add();
            
            var table2 = oDoc.Tables.Add(p2Table.Range, 2, 3, WdDefaultTableBehavior.wdWord9TableBehavior);
            */

            //Save the document
            string path = $@"C:\Users\Windows 10 Pro\Downloads\{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.docx";
            object filename = path;
            oDoc.SaveAs2(ref filename);
            
            oDoc.Close(ref missing, ref missing, ref missing);
            oDoc = null;

            winword.Documents.Open(path);

            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;


            Debug.WriteLine("Document created successfully !");
        }
        catch(Exception e)
        {
            Debug.WriteLine(e.ToString());
        }
    }

}
