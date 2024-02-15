using System;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopCleaner
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
        public int pictureselection = 0;
        public int archiveselection = 0;
        public int documentselection = 0;
        public int videoselection = 0;
        public int torrentselection = 0;
        public int executableselection = 0;
        public int cinemaeffectselection = 0;
        public int musicselection = 0;
        public int shortcutselection = 0;
        public int printingselection = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PictureSelection(object sender, RoutedEventArgs e)
        {
            if (pictureselection == 0)
                pictureselection++;
            else
                pictureselection--;
        }

        private void ArchiveSelection(object sender, RoutedEventArgs e)
        {
            if (archiveselection == 0)
                archiveselection++;
            else
                archiveselection--;
        }

        private void DocumentSelection(object sender, RoutedEventArgs e)
        {
            if (documentselection == 0)
                documentselection++;
            else
                documentselection--;
        }

        private void VideoSelection(object sender, RoutedEventArgs e)
        {
            if (videoselection == 0)
                videoselection++;
            else
                videoselection--;
        }

        private void TorrentSelection(object sender, RoutedEventArgs e)
        {
            if (torrentselection == 0)
                torrentselection++;
            else
                torrentselection--;
        }

        private void ExecutableSelection(object sender, RoutedEventArgs e)
        {
            if (executableselection == 0)
                executableselection++;
            else
                executableselection--;
        }

        private void CinemaEffectSelection(object sender, RoutedEventArgs e)
        {
            if (cinemaeffectselection == 0)
                cinemaeffectselection++;
            else
                cinemaeffectselection--;
        }

        private void MusicSelection(object sender, RoutedEventArgs e)
        {
            if (musicselection == 0)
                musicselection++;
            else
                musicselection--;
        }

        private void ShortcutSelection(object sender, RoutedEventArgs e)
        {
            if (shortcutselection == 0)
                shortcutselection++;
            else
                shortcutselection--;
        }
        private void Printer(object sender, RoutedEventArgs e)
        {
            if (printingselection == 0)
                printingselection++;
            else
                printingselection--;
        }

        private void Clean(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string RootPath = System.IO.Path.Combine(desktopPath, @"DesktopCleaner\");
            if (Directory.Exists(RootPath))
            {
                VelkeText.Content = "Na ploše již existuje složka DesktopCleaner, prosím přejmenujte nebo přestuňte tuto složku";
                return;
            }
            Directory.CreateDirectory(RootPath);
            if (pictureselection == 1)
            {
                string PicPath = System.IO.Path.Combine(RootPath, @"Fotky\");
                Directory.CreateDirectory(PicPath);
                foreach (var item in pictures)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var photo in tmp)
                    {
                        string a = photo.Substring(photo.LastIndexOf('\\')+1);
                        string tmp2 = System.IO.Path.Combine(PicPath, a);
                        File.Move(photo, tmp2);
                    }
                }
            }
            if (archiveselection == 1)
            {
                string ArchPath = System.IO.Path.Combine(RootPath, @"Archivy\");
                Directory.CreateDirectory(ArchPath);
                foreach (var item in archives)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var arch in tmp)
                    {
                        string a = arch.Substring(arch.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(ArchPath, a);
                        File.Move(arch, tmp2);
                    }
                }
            }
            if (documentselection == 1)
            {
                string DocPath = System.IO.Path.Combine(RootPath, @"Dokumenty\");
                Directory.CreateDirectory(DocPath);
                foreach (var item in documents)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var document in tmp)
                    {
                        string a = document.Substring(document.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(DocPath, a);
                        File.Move(document, tmp2);
                    }
                }
            }
            if (videoselection == 1)
            {
                string VidPath = System.IO.Path.Combine(RootPath, @"Videa\");
                Directory.CreateDirectory(VidPath);
                foreach (var item in videos)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var video in tmp)
                    {
                        string a = video.Substring(video.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(VidPath, a);
                        File.Move(video, tmp2);
                    }
                }
            }
            if (torrentselection == 1)
            {
                string TorPath = System.IO.Path.Combine(RootPath, @"Torrenty\");
                Directory.CreateDirectory(TorPath);
                foreach (var item in torrents)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var torrent in tmp)
                    {
                        string a = torrent.Substring(torrent.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(TorPath, a);
                        File.Move(torrent, tmp2);
                    }
                }
            }
            if (executableselection == 1)
            {
                string ExePath = System.IO.Path.Combine(RootPath, @"Executables\");
                Directory.CreateDirectory(ExePath);
                foreach (var item in executable)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var executablez in tmp)
                    {
                        string a = executablez.Substring(executablez.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(ExePath, a);
                        File.Move(executablez, tmp2);
                    }
                }
            }
            if (cinemaeffectselection == 1)
            {
                string CinPath = System.IO.Path.Combine(RootPath, @"CinemaEfekty\");
                Directory.CreateDirectory(CinPath);
                foreach (var item in cinemaeffect)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var effect in tmp)
                    {
                        string a = effect.Substring(effect.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(CinPath, a);
                        File.Move(effect, tmp2);
                    }
                }
            }
            if (musicselection == 1)
            {
                string MusPath = System.IO.Path.Combine(RootPath, @"Hudba\");
                Directory.CreateDirectory(MusPath);
                foreach (var item in musics)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var music in tmp)
                    {
                        string a = music.Substring(music.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(MusPath, a);
                        File.Move(music, tmp2);
                    }
                }
            }
            if (shortcutselection == 1)
            {
                string ShoPath = System.IO.Path.Combine(RootPath, @"Zastupce\");
                Directory.CreateDirectory(ShoPath);
                foreach (var item in shortcuts)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var shortcut in tmp)
                    {
                        string a = shortcut.Substring(shortcut.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(ShoPath, a);
                        File.Move(shortcut, tmp2);
                    }
                }
            }
            if (printingselection == 1)
            {
                string PriPath = System.IO.Path.Combine(RootPath, @"3DPrinting\");
                Directory.CreateDirectory(PriPath);
                foreach (var item in printing)
                {
                    string[] tmp = Directory.GetFiles(desktopPath, item);
                    foreach (var print in tmp)
                    {
                        string a = print.Substring(print.LastIndexOf('\\') + 1);
                        string tmp2 = System.IO.Path.Combine(PriPath, a);
                        File.Move(print, tmp2);
                    }
                }
            }
        }
    }
}