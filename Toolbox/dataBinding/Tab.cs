using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Toolbox
{
    public class Tab
    {
        public string Name { get; set; }
        public UserControl Content { get; set; }
        public ObservableCollection<Tab> Data { get; } = new ObservableCollection<Tab>();
        public override string ToString()
        {
            return null;
        }
    }
}