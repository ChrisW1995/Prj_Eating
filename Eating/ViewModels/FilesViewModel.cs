
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eating.Service;
namespace Eating.ViewModels
{
    public class FilesViewModel
    {
        public ViewDataUploadFilesResult[] Files { get; set; }
    }
}