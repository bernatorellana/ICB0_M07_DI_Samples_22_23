using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esborram
{
    class Llibre
    {

        private static ObservableCollection<Llibre> llibres;

        public static ObservableCollection<Llibre> getLlibres()
        {
            if (llibres == null)
            {
                llibres = new ObservableCollection<Llibre>();
                llibres.add(new Llibre("asdasd"));
                llibres.add(new Llibre("asdasd"));
                llibres.add(new Llibre("asdasd"));
                llibres.add(new Llibre("asdasd"));
            }
            return llibres,
        }
    }
}
