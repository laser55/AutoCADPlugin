using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AutoCADPlugin
{
    /// <summary>
    /// Interaction logic for DrawingSelection.xaml
    /// </summary>
    public partial class DrawingSelection : Window
    {
        public DrawingSelection()
        {
            InitializeComponent();


        }

        private void Extract_Click(object sender, RoutedEventArgs e)
        {
            List<BlockInfo> blockInfo = Extraction.Extract();
            if (blockInfo != null)
            {
                BlockInfoListViewModel viewModel = this.DataContext as BlockInfoListViewModel;
                viewModel = new BlockInfoListViewModel(blockInfo);
            }
        }
    }
}
