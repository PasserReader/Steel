using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplication.Utility
{
    class DataManager
    {

        static DataManager dataManager;

        private DataManager() { }

        public DataManager GetInstance()
        {
            if (dataManager == null)
                dataManager = new DataManager();
            return dataManager;
        }



    }
}
