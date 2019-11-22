
using CvEv6WinForm.DTOs;
using System;
using System.ComponentModel;

namespace CvEv6WinForm
{
    public class Title: IDto
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}