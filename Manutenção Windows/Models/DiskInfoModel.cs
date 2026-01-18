using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manutenção_Windows.Models
{
    internal class DiskInfoModel
    {

        public string Nome { get; set; }          // C:\
        public string Letra { get; set; }       // "C:"
        public string Label { get; set; }         // Windows, Dados, etc
        public string FileSystem { get; set; }    // NTFS, FAT32
        public long TotalSizeGb { get; set; }     // Tamanho total
        public bool IsSystem { get; set; }         // É disco do sistema?

        public override string ToString()
        {
            string sistema = IsSystem ? "Sistema" : "Dados";
            return $"{Nome} ({sistema}) - {FileSystem} - {TotalSizeGb} GB";

        }

    }

}