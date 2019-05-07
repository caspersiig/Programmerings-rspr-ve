using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Casper_A_S_Sortering
{



    /// <summary>
    ///
    /// </summary>
    public partial class MainWindow : Window
    {
        bool clicked = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void MainSorter_Click(object sender, RoutedEventArgs e)
        {

            Sortering.SorterFiler();
            if(clicked == true)
            {
                Sortering.rengør();
            }
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            RodTilIgen.SorterFiler();
        }

        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(rengøringsknap.IsChecked == true)
            {
                clicked = true;
            }
            else
            {
                clicked = false;
            }
            
        }
    }
    public class Sortering
    {

        // kopiereet kode xd
        //https://www.pinvoke.net/default.aspx/shell32/SHEmptyRecycleBin.html
        #region Skrrt
        [DllImport("shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hWnd, string pszRootPath, uint dwFlags);

        //     No dialog box confirming the deletion of the objects will be displayed.
        const int SHERB_NOCONFIRMATION = 0x00000001;
        //     No dialog box indicating the progress will be displayed. 
        const int SHERB_NOPROGRESSUI = 0x00000002;
        //     No sound will be played when the operation is complete. 
        const int SHERB_NOSOUND = 0x00000004;

        public static void EmptyRecycleBin()
        {
            Sortering.EmptyRecycleBin(string.Empty);
        }

        public static void EmptyRecycleBin(string rootPath)
        {
            int hresult = SHEmptyRecycleBin(IntPtr.Zero, rootPath,
                    SHERB_NOCONFIRMATION | SHERB_NOPROGRESSUI | SHERB_NOSOUND);
            System.Diagnostics.Debug.Write(hresult);
        }

        #endregion
        //https://www.pinvoke.net/default.aspx/shell32/SHEmptyRecycleBin.html
        // slut med kopiret kode
        /// <summary>
        /// de kalder mig støv suger af en grund 8====> O:
        /// </summary>
        public static void SorterFiler()
        {

            string DesktopVej = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + '\\';
            string TxTMappe = DesktopVej + "Txtmappe\\";
            string docsMappe = DesktopVej + "Dokumentmappe\\";
            string pdfMappe = DesktopVej + "Pdfmappe\\";
            string pptxMappe = DesktopVej + "Pptxmappe\\";
            string xlsxMappe = DesktopVej + "xlsxmappe\\";
            string gifMappe = DesktopVej + "gifmappe\\";
            string jpgMappe = DesktopVej + "jpgmappe\\";
            string csvMappe = DesktopVej + "csvmappe\\";
            string pngMappe = DesktopVej + "pngmappe\\";
            string exeMappe = DesktopVej + "exemappe\\";
            string wavMappe = DesktopVej + "wavmappe\\";
            string mp4Mappe = DesktopVej + "mp4mappe\\";
            string mp3Mappe = DesktopVej + "mp3mappe\\";
            string matematikMappe = DesktopVej + "matematikmappe\\";
            string danskMappe = DesktopVej + "danskmappe\\";
            string engelskMappe = DesktopVej + "engelskmappe\\";
            string kemiMappe = DesktopVej + "kemimappe\\";
            string fysikMappe = DesktopVej + "fysikmappe\\";
            string biologiMappe = DesktopVej + "biologimappe\\";
            string idehistorieMappe = DesktopVej + "idehistoriemappe\\";
            string komitMappe = DesktopVej + "komitmappe\\";
            string programmeringMappe = DesktopVej + "programmeringsmappe\\";
            string samfundsfag = DesktopVej + "samfundsfagmappe\\";
            string teknologiMappe = DesktopVej + "teknologimappe\\";
            string teknikMappe = DesktopVej + "teknikmappe\\";

            

            //laver en string der har alle fulde genveje til alle filer på skrivebordet
            string[] skrivebordfiler = System.IO.Directory.GetFiles(DesktopVej);

            //laver en tom liste der hedder alletekstdoku der snart vil blive fuldt med navnede på alle txt filerne
            List<string> alletekstdoku = new List<string>();
            List<string> docsdoku = new List<string>();
            List<string> pdfdoku = new List<string>();
            List<string> pptxdoku = new List<string>();
            List<string> xlsxdoku = new List<string>();
            List<string> gifdoku = new List<string>();
            List<string> jpgdoku = new List<string>();
            List<string> csvdoku = new List<string>();
            List<string> pngdoku = new List<string>();
            List<string> exedoku = new List<string>();
            List<string> wavdoku = new List<string>();
            List<string> mp4doku = new List<string>();
            List<string> mp3doku = new List<string>();

            List<string> matematikdoku = new List<string>();
            List<string> danskdoku = new List<string>();

            List<string> engelskdoku = new List<string>();
            List<string> kemidoku = new List<string>();
            List<string> fysikdoku = new List<string>();
            List<string> biologidoku = new List<string>();
            List<string> idehistoriedoku = new List<string>();
            List<string> komitdoku = new List<string>();
            List<string> programmeringdoku = new List<string>();
            List<string> samfundsfagdoku = new List<string>();
            List<string> teknologidoku = new List<string>();
            List<string> teknikdoku = new List<string>();

            

            //laver et for loop der kører det antal gange som skrivebordfiler arrayet er langt
            for (int i = 0; i < skrivebordfiler.Length; i++)
            {
                //fjerner den del af fil vejen som vi godt kender altså C:/Users/casper/Desktop/
                skrivebordfiler[i] = skrivebordfiler[i].Split('\\').Last();
                //finder documenter med matematik i navnet for at føre dem hen til et specielt matematik mappe
                if (skrivebordfiler[i].Contains("matematik"))
                {
                    matematikdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("dansk"))
                {
                    danskdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("teknik"))
                {
                    teknikdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("teknologi"))
                {
                    teknologidoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("samfundsfag"))
                {
                    samfundsfagdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("programmering"))
                {
                    programmeringdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("komit"))
                {
                    komitdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("idehistorie"))
                {
                    idehistoriedoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("biologi"))
                {
                    biologidoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("fysik"))
                {
                    fysikdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("kemi"))
                {
                    kemidoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }
                if (skrivebordfiler[i].Contains("engelsk"))
                {
                    engelskdoku.Add(skrivebordfiler[i]);
                    skrivebordfiler[i] = "0";
                }

                //tager alle de navne som vi har fra linjen over og sætter dem ind på vores liste
                if (skrivebordfiler[i].Split('.').Last() == "txt")
                    alletekstdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "docx")
                    docsdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "pdf")
                    pdfdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "pptx")
                    pptxdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "xlsx")
                    xlsxdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "gif")
                    gifdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "jpg")
                    jpgdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "csv")
                    csvdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "PNG")
                    pngdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "exe")
                    exedoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "wav")
                    wavdoku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "mp4")
                    mp4doku.Add(skrivebordfiler[i]);
                if (skrivebordfiler[i].Split('.').Last() == "mp3")
                    mp3doku.Add(skrivebordfiler[i]);
            }

            //laver array med 4 lister der indholder de forskellige dokument navne og slutninger
            List<string>[] alledoku = new List<string>[25] { alletekstdoku, docsdoku, pdfdoku, pptxdoku , xlsxdoku , gifdoku , jpgdoku , csvdoku , pngdoku , exedoku , wavdoku , mp4doku , mp3doku , matematikdoku , danskdoku, engelskdoku, kemidoku, fysikdoku, biologidoku, idehistoriedoku, komitdoku, programmeringdoku, samfundsfagdoku, teknologidoku, teknikdoku };
            // laver vi for loop der laver et foreach for de forskellige arrays vi laver ^^^^^^^^^^^^ og med switch casen siger vi hvad der ændres vær gang
            for (int i = 0; i < alledoku.Length; i++)
            {
                string destMappe = "";
                switch (i)
                {
                    case 0:destMappe = TxTMappe;break;
                    case 1:destMappe = docsMappe;break;
                    case 2:destMappe = pdfMappe;break;
                    case 3:destMappe = pptxMappe;break;
                    case 4: destMappe = xlsxMappe; break;
                    case 5: destMappe = gifMappe; break;
                    case 6: destMappe = jpgMappe; break;
                    case 7: destMappe = csvMappe; break;
                    case 8: destMappe = pngMappe; break;
                    case 9: destMappe = exeMappe; break;
                    case 10: destMappe = wavMappe; break;
                    case 11: destMappe = mp4Mappe; break;
                    case 12: destMappe = mp3Mappe; break;
                    case 13: destMappe = matematikMappe; break;
                    case 14: destMappe = danskMappe; break;
                    case 15: destMappe = engelskMappe; break;
                    case 16: destMappe = kemiMappe; break;
                    case 17: destMappe = fysikMappe; break;
                    case 18: destMappe = biologiMappe; break;
                    case 19: destMappe = idehistorieMappe; break;
                    case 20: destMappe = komitMappe; break;
                    case 21: destMappe = programmeringMappe; break;
                    case 22: destMappe = samfundsfag; break;
                    case 23: destMappe = teknologiMappe; break;
                    case 24: destMappe = teknikMappe; break;
                    
                }
                //for each statement der tager den korrekte liste med filnavn.filtype og vi bruger switchcasen til at vælge hvilken liste vi er i gang med
                foreach (string d in alledoku[i])
                {
                    //kontroller om mappen til txt filerne eksister hvis ikke så laver den den
                    if (!System.IO.Directory.Exists(destMappe))
                    {
                        System.IO.Directory.CreateDirectory(destMappe);
                    }

                    if (!System.IO.File.Exists(destMappe + d))
                    {






















                        System.IO.File.Move(DesktopVej + d, destMappe + d);
                    }
                    else
                    {
                        System.IO.File.Move(DesktopVej + d, destMappe + new Random().Next(1, 999999999) + d);
                        MessageBox.Show("du har ellerede en fil med dette navn og der er nu blevet sat et tal på det");
                    }

                }
            }
        }

        public static void rengør()
        {
            EmptyRecycleBin();
            string downloadspath = @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string[] downloadefiler = System.IO.Directory.GetFiles(downloadspath);
            for (int i = 0; i < downloadefiler.Length; i++)
            {
                System.IO.File.Delete(downloadefiler[i]);
            }


            string[] tempfill = System.IO.Directory.GetFiles(@Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+ "\\Temp");
            for (int i = 0; i < tempfill.Length; i++)
            {
                if (!tempfill[i].Contains("AssemblyDataCache"))
                    System.IO.File.Delete(tempfill[i]);
            }

            MessageBox.Show("så fik din computer vasked");
        }
    }

    public class RodTilIgen
    {
        public static void SorterFiler()
        {



        }
    }
}