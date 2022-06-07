using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace TotalCommander.ViewModel
{
    using Model;
    using View;
    using System.Windows;

    public class PanelTCViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string currentPath;

        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPath)));
            }
        }

        private string selectedDrive;

        public string SelectedDrive
        {
            get => selectedDrive;  
            set
            {
                selectedDrive = value;
            }
        }

        #region combobox

        private List<string> currentDrives = new List<string>();

        public List<string> CurrentDrives
        {
            get { return currentDrives; }
            set 
            { 
                currentDrives = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentDrives)));
            }
        }

        private ICommand getDrivesEvent;

        public ICommand GetDrivesEvent => getDrivesEvent ?? (getDrivesEvent = new RelayCommand(
                o =>
                {
                    List <string> Drives = new List<string>();
                    foreach (string drive in PanelTCModel.getDrives())
                    {
                        Drives.Add(drive);
                    }
                    if (CurrentDrives != null)
                    {
                        CurrentDrives = Drives;
                    }
                },null));
        #endregion
        private List<FileModel> fileList = new List<FileModel>();
        public List<FileModel> FileList
        {
            get => fileList;
            set
            {
                fileList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileList)));
            }
        }

        private ICommand updateDriveEvent;

        public ICommand UpdateDriveEvent => updateDriveEvent ?? (updateDriveEvent = new RelayCommand(
            o=>
            {
                
                CurrentPath = SelectedDrive;
                List<FileModel> Files = new List<FileModel>();
                foreach(FileModel f in PanelTCModel.updateSubfolders(CurrentPath))
                {
                    Files.Add(f);
                }
                if (FileList != null)
                {
                    FileList = Files;
                }

            },null));

        private string selectedFile;

        public string SelectedFile
        {
            get => selectedFile;
            set
            {
                selectedFile = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFile)));
            }
        }

        private ICommand updateFIleList;

        public ICommand UpdateFileList => updateFIleList ?? (updateFIleList = new RelayCommand(
            o =>
            {
                if(SelectedDrive != null)
                {
                    if(SelectedFile == null)
                    {
                        SelectedFile = CurrentPath;
                    }
                    if(SelectedFile.Contains("<DIR>"))
                    {
                        string temp = string.Empty;
                        for(int i = 5; i < SelectedFile.Length; i++)
                        {
                            temp += SelectedFile[i];
                        }
                        CurrentPath = temp;
                        FileList = PanelTCModel.updateSubfolders(CurrentPath);
                    }
                    else if (SelectedFile == "...")
                    {
                        FileList = PanelTCModel.updateSubfolders(PanelTCModel.getLastPath(CurrentPath));
                        CurrentPath = PanelTCModel.getLastPath(CurrentPath);
                        SelectedFile = CurrentPath;
                        
                    }  
                }
            }, null));

    }
}
