using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace podbor_odejdi
{

    public partial class tipi_dannih : Component
    {
        public tipi_dannih()
        {
            InitializeComponent();
        }

        public tipi_dannih(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
