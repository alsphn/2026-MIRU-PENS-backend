using System;
using System.ComponentModel.DataAnnotations; 

namespace MIRU.API.Models
{
    public class Peminjaman
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama Peminjam wajib diisi")]
        [StringLength(100, ErrorMessage = "Nama Peminjam maksimal 100 karakter")]
        public string NamaPeminjam { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama Ruangan wajib diisi")]
        [StringLength(50, ErrorMessage = "Nama Ruangan maksimal 50 karakter")]
        public string NamaRuangan { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tanggal Mulai wajib diisi")]
        public DateTime TanggalMulai { get; set; }

        [Required(ErrorMessage = "Tanggal Selesai wajib diisi")]
        public DateTime TanggalSelesai { get; set; }

        [Required(ErrorMessage = "Keperluan wajib diisi")]
        public string Keperluan { get; set; } = string.Empty;

        // Status tidak perlu Required karena default-nya "Menunggu"
        public string Status { get; set; } = "Menunggu";
    }
}