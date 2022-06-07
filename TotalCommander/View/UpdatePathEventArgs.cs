using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TotalCommander.View
{
    internal class UpdatePathEventArgs : RoutedEventArgs
    {
        public UpdatePathEventArgs(RoutedEvent r_event, string drive) : base(r_event) { Drive = @"C:\"; }
        public string Drive { get; set; }
    }
}
