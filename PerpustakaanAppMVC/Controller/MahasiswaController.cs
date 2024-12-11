using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Repository;
using PerpustakaanAppMVC.Model.Context;

namespace PerpustakaanAppMVC.Controller
{
    public class MahasiswaController
    {
        private MahasiswaRepository _mhsRepository;

        public int Create(Mahasiswa mhs)
        {
            int result = 0;
            //cek field mhs agar tidak kosong

            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("Npm harus Di isi !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus Di isi !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                MessageBox.Show("Angkatan harus Di isi !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //membuat object context pakai using

            using(DbContext context = new DbContext())
            {
                _mhsRepository = new MahasiswaRepository(context);
                result = _mhsRepository.Create(mhs);

            }

            if (result > 0) {
                MessageBox.Show("Data Mahasiswa berhsil tersimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Mahasiswa gagal tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //kirim hasil 
            return result;
        }
        public int Update(Mahasiswa mhs)
        {
            int result = 0;
            //cek field mhs agar tidak kosong

            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("Npm harus Di isi !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus Di isi !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                MessageBox.Show("Angkatan harus Di isi !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //membuat object context pakai using

            using (DbContext context = new DbContext())
            {
                _mhsRepository = new MahasiswaRepository(context);
                // pakai method update repo
                result = _mhsRepository.Update(mhs);

            }

            if (result > 0)
            {
                MessageBox.Show("Data Mahasiswa berhsil tersimpan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Mahasiswa gagal tersimpan !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //kirim hasil 
            return result;
        }
        public int Delete(Mahasiswa mhs)
        {
            int result = 0;
            //cek field mhs agar tidak kosong

            //sepertinya kalau hapus cukup dengan validasi npm saja, heheehe
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("Npm harus Di isi !!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //membuat object context pakai using

            using (DbContext context = new DbContext())
            {
                _mhsRepository = new MahasiswaRepository(context);
                //pakai method delete
                result = _mhsRepository.Delete(mhs);

            }

            if (result > 0)
            {
                MessageBox.Show("Data Mahasiswa berhsil terhapus !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Mahasiswa gagal terhapus !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //kirim hasil 
            return result;
        }

        public List<Mahasiswa> ReadByNama(string nama)
        {
            List<Mahasiswa> listMhs = new List<Mahasiswa>();
            //buat object dengan using
            using(DbContext context = new DbContext())
            {
                //buat object dari repo
                _mhsRepository = new MahasiswaRepository(context);

                //panggil readByNama dari class repo dan kasi parameter
                listMhs = _mhsRepository.ReadByName(nama);
            }
            return listMhs;
        }

        public List<Mahasiswa> ReadAll()
        {
            List<Mahasiswa> listMhs = new List<Mahasiswa>();
            //buat object dengan using
            using (DbContext context = new DbContext())
            {
                //buat object dari repo
                _mhsRepository = new MahasiswaRepository(context);

                //panggil readByNama dari class repo dan kasi parameter
                listMhs = _mhsRepository.ReadAll();
            }
            return listMhs;
        }
    }
}
