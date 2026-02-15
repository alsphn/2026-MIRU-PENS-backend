using MIRU.API.Models;

namespace MIRU.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Pastikan database sudah dibuat
            context.Database.EnsureCreated();

            // Cek apakah sudah ada data peminjaman?
            if (context.Peminjamans.Any())
            {
                return;   // Data sudah ada, tidak perlu bikin lagi
            }

            // Kalau kosong, bikin data dummy
            var peminjamans = new Peminjaman[]
            {
                new Peminjaman
                {
                    NamaPeminjam = "Ali Mahasiswa",
                    NamaRuangan = "Lab RPL",
                    TanggalMulai = DateTime.Parse("2026-03-10 08:00:00"),
                    TanggalSelesai = DateTime.Parse("2026-03-10 10:00:00"),
                    Keperluan = "Mengerjakan Proyek PBL",
                    Status = "Menunggu"
                },
                new Peminjaman
                {
                    NamaPeminjam = "Budi Dosen",
                    NamaRuangan = "Ruang Sidang",
                    TanggalMulai = DateTime.Parse("2026-03-11 13:00:00"),
                    TanggalSelesai = DateTime.Parse("2026-03-11 15:00:00"),
                    Keperluan = "Rapat Jurusan",
                    Status = "Disetujui"
                }
            };

            // Masukkan ke database
            foreach (var p in peminjamans)
            {
                context.Peminjamans.Add(p);
            }
            
            // Simpan perubahan
            context.SaveChanges();
        }
    }
}