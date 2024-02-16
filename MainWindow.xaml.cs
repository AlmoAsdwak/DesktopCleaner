using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace DesktopCleaner
{
    public partial class MainWindow : Window
    {
        public string[] pictures = { "*.jpg", "*.jpeg", "*.gif", "*.psd", "*.tiff", "*.tif", "*.png", "*.bmp", "*.raw", "*.nef", "*.ai" };
        public string[] archives = { "*.zip", "*.rar", "*.7z", "*.iso", "*.s7z", "*.apk", "*.cab", "*.pak", "*.zipx" };
        public string[] documents = { "*.doc", "*.docx", "*.pdf", "*.txt", "*.rtf", "*.xlsx", "*.csv" };
        public string[] videos = { "*.mov", "*.mp4", "*.avi", "*.mkv", "*.flv", "*.m2t", "*.mpeg", "*.wmv" };
        public string[] torrents = { "*.torrent" };
        public string[] executable = { "*.exe" };
        public string[] cinemaeffect = { "*.c4d" };
        public string[] musics = { "*.mp3", "*.wav", "*.flac", "*.midi" };
        public string[] shortcuts = { "*.lnk" };
        public string[] printing = { "*.stl", "*.gcode", "*.obj", "*.3ds", "*.blend", "*.skp", "*.max", "*.3dmf", "*.3mf" };
        public bool pictureselection = false;
        public bool archiveselection = false;
        public bool documentselection = false;
        public bool videoselection = false;
        public bool torrentselection = false;
        public bool executableselection = false;
        public bool cinemaeffectselection = false;
        public bool musicselection = false;
        public bool shortcutselection = false;
        public bool printingselection = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
#pragma warning disable
            CheckBox checkBox = sender as CheckBox;
            string content = checkBox.Content.ToString();
#pragma warning enable

            switch (content)
            {
                case "Obrázky":
                    pictureselection = !pictureselection;
                    break;
                case "Archívy":
                    archiveselection = !archiveselection;
                    break;
                case "Dokumenty":
                    documentselection = !documentselection;
                    break;
                case "Videa":
                    videoselection = !videoselection;
                    break;
                case "Torrenty":
                    torrentselection = !torrentselection;
                    break;
                case "Executable":
                    executableselection = !executableselection;
                    break;
                case "Cinema Efekty":
                    cinemaeffectselection = !cinemaeffectselection;
                    break;
                case "Hudba":
                    musicselection = !musicselection;
                    break;
                case "Zástupce":
                    shortcutselection = !shortcutselection;
                    break;
                case "3D Tisk":
                    printingselection = !printingselection;
                    break;
                default:
                    break;
            }
        }

        private void Clean(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string RootPath = Path.Combine(desktopPath, @"DesktopCleaner\");

            if (!Directory.Exists(RootPath))
                Directory.CreateDirectory(RootPath);

            

            Dictionary<string, (bool selection, string[] items)> categories = new Dictionary<string, (bool, string[])>()
            {
                { "Fotky", (pictureselection, pictures) },
                { "Archivy", (archiveselection, archives) },
                { "Dokumenty", (documentselection, documents) },
                { "Videa", (videoselection, videos) },
                { "Torrenty", (torrentselection, torrents) },
                { "Executables", (executableselection, executable) },
                { "CinemaEfekty", (cinemaeffectselection, cinemaeffect) },
                { "Hudba", (musicselection, musics) },
                { "Zastupce", (shortcutselection, shortcuts) },
                { "3DPrinting", (printingselection, printing) }
            };

            foreach (var category in categories)
            {
                if (!category.Value.selection)
                    continue;

                string categoryPath = Path.Combine(RootPath, category.Key);
                if(!Directory.Exists(categoryPath))
                    Directory.CreateDirectory(categoryPath);

                foreach (var item in category.Value.items)
                {
                    string[] files = Directory.GetFiles(desktopPath, item);
                    foreach (var file in files)
                    {
                        var tmp = file;
                        string[] filesindestination = Directory.GetFiles(categoryPath);
                        foreach (var filez in filesindestination)
                            if (file.Substring(file.LastIndexOf('\\')) == filez.Substring(file.LastIndexOf('\\')))
                            {
                                tmp = Check(file, filesindestination,0);
                            }
                        string fileName = Path.GetFileName(tmp);
                        string destination = Path.Combine(categoryPath, fileName);

                        File.Move(tmp, destination);
                    }
                }
            }
        }
        private string Check(string a, string[] b, int tries)
        {
            string tmp = a;
            a += tries.ToString();
            foreach(var file in b)
                if (a.Substring(a.LastIndexOf('\\')) == file.Substring(file.LastIndexOf('\\')))
                    a = Check(tmp, b, tries + 1);
            return a;
        }
    }
}