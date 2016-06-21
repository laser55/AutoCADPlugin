using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AutoCADPlugin
{
    public class BlockInfoListViewModel
    {
        /// <summary>
        /// Test WPF for proper loading
        /// </summary>
        public BlockInfoListViewModel()
        {
            BlockInfoViewModels = new List<BlockInfoViewModel>();

            Dictionary<string, string> testDictionary = new Dictionary<string, string>();
            testDictionary.Add("Key1", "Value1");
            testDictionary.Add("Key2", "Value2");
            testDictionary.Add("Key3", "Value3");
            BlockInfo block = new BlockInfo();
            block.BlockAttributes = testDictionary;
            block.Name = "Block1";

            BlockInfoViewModel testVM = new BlockInfoViewModel(block);
            BlockInfoViewModels.Add(testVM);
            RaisePropertyChanged("BlockInfoViewModels");
        }

        /// <summary>
        /// Construct listviewmodel from list of blockinfo
        /// </summary>
        /// <param name="blockInfoList"></param>
        public BlockInfoListViewModel(List<BlockInfo> blockInfoList)
        {
            BlockInfoViewModels = new List<BlockInfoViewModel>();
            foreach(BlockInfo blockinfo in blockInfoList)
            {
                BlockInfoViewModel viewmodel = new BlockInfoViewModel(blockinfo);
                BlockInfoViewModels.Add(viewmodel);
            }
            RaisePropertyChanged("BlockInfoViewModels");
        }

        private List<BlockInfoViewModel> blockInfoViewModels;
        public List<BlockInfoViewModel> BlockInfoViewModels
        {
            get
            {
                return blockInfoViewModels;
            }
            set
            {
                blockInfoViewModels = value;
                RaisePropertyChanged("BlockInfoViewModels");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
