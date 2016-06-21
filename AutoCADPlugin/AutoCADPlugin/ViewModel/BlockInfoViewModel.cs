using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AutoCADPlugin
{
    public class BlockInfoViewModel : INotifyPropertyChanged
    {
        public BlockInfoViewModel(BlockInfo input)
        {
            BlockInfo = input;
        }

        private BlockInfo blockInfo;
        public BlockInfo BlockInfo
        {
            get
            {
                return blockInfo;
            }
            set
            {
                blockInfo = value;
                RaisePropertyChanged("BlockInfo");
            }
        }
        
        public Dictionary<string, string> BlockAttributes
        {
            get
            {
                return BlockInfo.BlockAttributes;
            }
            set
            {
                BlockInfo.BlockAttributes = value;
                RaisePropertyChanged("BlockAttributes");
            }
        }

        public string Name
        {
            get
            {
                return BlockInfo.Name;
            }
            set
            {
                BlockInfo.Name = value;
                RaisePropertyChanged("Name");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
