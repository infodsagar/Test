using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using Word = Microsoft.Office.Interop.Word;

public class Test
{
    public delegate void FirstDel();
    static void Main(string[] args)
    {
        Test test = new Test();
        try
        {
            test.CreateDoc();
        }catch (Exception ex) { Debug.WriteLine(ex.Message); }        
    }

    public void SwitchDisplay()
    {
        string Path = ".\\Resources\\Setting.txt";
                       //Expand view = 0, single monitor = 1
        if(File.ReadAllText(Path) == "0")
        {
            string strCmdText1 = $"/C @ECHO OFF";
            string strCmdText2 = $"/C DisplaySwitch.exe /external";

            System.Diagnostics.Process.Start("CMD.exe", strCmdText1);
            System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
            File.WriteAllText(Path, "1");
        }
        else
        {
            string strCmdText1 = $"/C @ECHO OFF";
            string strCmdText2 = $"/C DisplaySwitch.exe /extend";

            System.Diagnostics.Process.Start("CMD.exe", strCmdText1);
            System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
            File.WriteAllText(Path, "0");
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