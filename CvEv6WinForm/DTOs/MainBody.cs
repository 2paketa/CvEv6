using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvEv6WinForm.DTOs
{
    [Serializable]
    public class MainBody : IDto
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
