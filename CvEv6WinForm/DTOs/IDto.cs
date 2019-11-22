using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvEv6WinForm.DTOs
{
    public interface IDto
    {
        [Browsable(false)]
        int Id { get; set; }
        string Name { get; set; }

    }
}
