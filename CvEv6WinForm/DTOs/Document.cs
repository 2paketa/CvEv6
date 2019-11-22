
using CvEv6WinForm.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvEv6WinForm
{
    public class Document: IDto
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Browsable(false)]
        public int DomainId { get; set; }
    }
}
