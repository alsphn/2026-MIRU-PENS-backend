using System;

namespace MIRU.API.Models
{
    public class Peminjaman
    {
        // Ini adalah Primary Key (ID unik untuk setiap data)
        public int Id { get; set; }

        // Siapa yang meminjam?
        public string NamaPeminjam { get; set; } = string.Empty;

        // Ruangan apa yang dipinjam?
        public string NamaRuangan { get; set; } = string.Empty;

        // Kapan mulai?
        public DateTime TanggalMulai { get; set; }

        // Kapan selesai?
        public DateTime TanggalSelesai { get; set; }

        // Buat acara apa?
        public string Keperluan { get; set; } = string.Empty;

        // Statusnya gimana? (Menunggu, Disetujui, Ditolak)
        public string Status { get; set; } = "Menunggu";
    }
}