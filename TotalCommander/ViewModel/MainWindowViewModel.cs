using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using TotalCommander.Model;
using System.Windows;

namespace TotalCommander.ViewModel 
{
    public class MainWindowViewModel 
    {

        private readonly PanelTCViewModel leftPanel;
        private readonly PanelTCViewModel rightPanel;

        public PanelTCViewModel LeftPanel
        {
            get { return leftPanel; }
        }

        public PanelTCViewModel RightPanel
        {
            get { return rightPanel; }
        }

        public MainWindowViewModel()
        {
            leftPanel = new PanelTCViewModel();
            rightPanel = new PanelTCViewModel();
        }

        private ICommand copy;

        public ICommand Copy => copy ?? (copy = new RelayCommand(
            o =>
            {
                MessageBox.Show("xD");
                PanelTCModel.copyFile(LeftPanel, RightPanel);
            },
            o => (
                LeftPanel.CurrentPath != null &&
                RightPanel.CurrentPath != null &&
                !LeftPanel.CurrentPath.Equals(RightPanel.CurrentPath) &&
                LeftPanel.SelectedFile != null
            )
            ));

    }
}
