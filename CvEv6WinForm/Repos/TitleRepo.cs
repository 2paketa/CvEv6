using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CvEv6WinForm
{
    class TitleRepo
    {
        public List<Title> titles;
        DataFromApi dataFromApi;
        private static TitleRepo instance;

        private TitleRepo()
        {
            Task.Run(() => getData());
        }

        public static TitleRepo GetInstance(bool reload = false)
        {
            if (instance == null)
            {
                instance = new TitleRepo();
            }
            if (reload == true)
            {
                Task.Run(() => instance.refreshData());
            }
            return instance;
        }
        public async Task Set()
        {
            dataFromApi = new DataFromApi();
            titles = await dataFromApi.getTitles();
        }

        public List<Title> GetTitles()
        {
            while (titles == null) { }
            return titles;
        }

        public async Task getData()
        {
            dataFromApi = new DataFromApi();
            titles = await dataFromApi.getTitles();
        }


        private async Task refreshData()
        {
            titles = await dataFromApi.getTitles();
        }
    }
}
