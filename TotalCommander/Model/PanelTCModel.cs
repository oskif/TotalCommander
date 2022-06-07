using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;

namespace TotalCommander.Model
{
    using ViewModel;
    public class PanelTCModel
    {
        public static string [] getDrives ()
        {
            return Directory.GetLogicalDrives();
        }

        public static List<FileModel> updateSubfolders(string path)
        {
            List<FileModel> subfolders = new List<FileModel>();
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            if (path.IndexOf(":") != path.Length - 2)
                subfolders.Add(new FileModel("back", Types.types.BACK));

            foreach (string d in directories)
            {
                subfolders.Add(new FileModel(d, Types.types.DIR));
            }
            foreach (string f in files)
            {
                subfolders.Add(new FileModel(f, Types.types.FILE));
            }
            return subfolders;
        }

        public static string getLastPath(string path)
        {
            if (Directory.GetParent(path) == null)
            {
                return path;
            }
            return Directory.GetParent(path).FullName;
        }
        public static void copyFile(PanelTCViewModel source, PanelTCViewModel destination)
        {
            string file = source.SelectedFile;
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destination.CurrentPath, fileName);
            File.Copy(file, destFile, true);

            MessageBox.Show($"File {file} coppied to {destFile} successfully.");

        }
    }
}
