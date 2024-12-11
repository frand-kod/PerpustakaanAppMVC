using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Context;

namespace PerpustakaanAppMVC.Model.Repository
{
    public class MahasiswaRepository
    {
        private SQLiteConnection _connection;
        //construktor

        public MahasiswaRepository(DbContext context)
        {
            //inisialisasi object koneksi dari context database

            _connection = context.Connection;

        }

        //inisialisasi method crud

        public int Create(Mahasiswa mhs)
        {
            int result = 0;

            //query Create Mahasiswa
            string sqlCreate = @"Insert into mahasiswa (npm, nama, angkatan) values (@npm,@nama,@angkatan)";

            using (SQLiteCommand command = new SQLiteCommand(sqlCreate, _connection))
            {
                //daftarkan parameter

                command.Parameters.AddWithValue(@"npm",mhs.Npm);
                command.Parameters.AddWithValue(@"nama", mhs.Nama);
                command.Parameters.AddWithValue(@"angkatan", mhs.Angkatan);

                //ujicoba koneksikan

                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create Error",ex.Message);
                }
            }
            return result;
        }

        public int Update(Mahasiswa mhs)
        {
            int result = 0;

            //query Update Mahasiswa

            //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
            string sqlUpdate = @"UPDATE mahasiswa SET npm = @npm, nama = @nama, angkatan = @angkatan WHERE npm = @npm";

            using (SQLiteCommand command = new SQLiteCommand(sqlUpdate, _connection))
            {
                //daftarkan parameter
                command.Parameters.AddWithValue(@"npm", mhs.Npm);
                command.Parameters.AddWithValue(@"nama", mhs.Nama);
                command.Parameters.AddWithValue(@"angkatan", mhs.Angkatan);

                //ujicoba koneksikan
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update Error", ex.Message);
                }
            }
            return result;
        }
        public int Delete(Mahasiswa mhs)
        {
            int result = 0;

            //query Update Mahasiswa

            //UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
            string sqlDelete = @"DELETE FROM mahasiswa WHERE npm = @npm";

            using (SQLiteCommand command = new SQLiteCommand(sqlDelete, _connection))
            {
                //daftarkan parameter
                command.Parameters.AddWithValue(@"npm", mhs.Npm);
                command.Parameters.AddWithValue(@"nama", mhs.Nama);
                command.Parameters.AddWithValue(@"angkatan", mhs.Angkatan);

                //ujicoba koneksikan
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete Error", ex.Message);
                }
            }
            return result;
        }

        public List<Mahasiswa> ReadAll()
        {
            //collection penampung dataread sebelum di kirim ke view
            List<Mahasiswa> listMhs=new List<Mahasiswa>();

            try
            {
                //query select
                string sqlSelect= @"Select npm, nama, angkatan from mahasiswa order by nama";
                
                //command dengan using

                using (SQLiteCommand command = new SQLiteCommand(sqlSelect, _connection))
                {
                    //data reader dengan using

                    using(SQLiteDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.Nama = dataReader["nama"].ToString();
                            mhs.Npm = dataReader["nim"].ToString();
                            mhs.Angkatan = dataReader["Angkatan"].ToString();

                            //masukkan ke collection setelah di baca data reader
                            listMhs.Add(mhs);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Read all from Data Error", ex.Message);
            }
            return listMhs;

        }
        public List<Mahasiswa> ReadByName(string nama)
        {
            //collection penampung dataread sebelum di kirim ke view
            List<Mahasiswa> listMhs = new List<Mahasiswa>();

            try
            {
                //query select for someone
                string sqlSelect = @"Select npm, nama, angkatan from mahasiswa where nama like @nama order by nama";

                //command dengan using

                using (SQLiteCommand command = new SQLiteCommand(sqlSelect, _connection))
                {
                    //data reader dengan using

                    using (SQLiteDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Mahasiswa mhs = new Mahasiswa();
                            mhs.Nama = dataReader["nama"].ToString();
                            mhs.Npm = dataReader["nim"].ToString();
                            mhs.Angkatan = dataReader["Angkatan"].ToString();

                            //masukkan ke collection setelah di baca data reader
                            listMhs.Add(mhs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Read all from Data Error", ex.Message);
            }
            return listMhs;

        }
    }

}
