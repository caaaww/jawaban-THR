using System;
namespace ManajemenKaryawan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
            string jenis = Console.ReadLine().ToLower();

            Console.Write("Masukkan Nama karyawan: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan ID Karyawan: ");
            string id = Console.ReadLine();

            Console.Write("Masukkan Gaji Pokok: ");
            double gajipokok = Convert.ToDouble(Console.ReadLine());

            Karyawan karyawan = null;

            if (jenis == "tetap")
            {
                karyawan = new Karyawantetap();
            }
            else if (jenis == "kontrak")
            {
                karyawan = new Karyawankontrak();
            }
            else if (jenis == "magang")
            {
                karyawan = new Karyawanmagang();
            }

            if (karyawan != null)
            {
                karyawan.Nama = nama;
                karyawan.ID = id;
                karyawan.Gajipokok = gajipokok;

                Console.WriteLine($"\nData Karyawan:");
                Console.WriteLine($"Nama: {karyawan.Nama}");
                Console.WriteLine($"ID: {karyawan.ID}");
                Console.WriteLine($"Gaji Akhir: {karyawan.HitungGaji()}");
            }
            else
            {
                Console.WriteLine("Jenis karyawan tidak valid.");
            }
        }
    }
    class Karyawan
    {
        private string namakaryawan;
        private string id_karyawan;
        private double gajipokok;

        public string Nama
        {
            get { return namakaryawan; }
            set { namakaryawan = value; }
        }

        public string ID
        {
            get { return id_karyawan; }
            set { id_karyawan = value; }
        }

        public double Gajipokok
        {
            get { return gajipokok; }
            set { gajipokok = value; }
        }

        public virtual double HitungGaji()
        {
            return Gajipokok;
        }
    }
    class Karyawantetap : Karyawan
    {
        private double bonustetap = 500000;

        public override double HitungGaji()
        {
            return Gajipokok + bonustetap;
        }
    }
    class Karyawankontrak : Karyawan
    {
        private double potongan_kontrak = 200000;

        public override double HitungGaji()
        {
            return Gajipokok - potongan_kontrak;
        }
    }
    class Karyawanmagang : Karyawan
    {
        public override double HitungGaji()
        {
            return Gajipokok;
        }
    }
}
