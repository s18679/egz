using System;
using System.Collections.Generic;

namespace egz.Models
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<PrescriptionMedicament> Prescription_Medicament { get; set; }

        public HospitalDbContext() 
        {

        }

        public HospitalDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PrescriptionMedicament>().HasKey(k => new { k.IdMedicament, k.IdPrescription });

            List<Prescription> listPrescriptions = new List<Prescription>();
            listPrescriptions.Add(new Prescription { IdPrescription = 1, Date = Convert.ToDateTime("1999-01-01"), DueDate = Convert.ToDateTime("1999-01-01"), IdPatient = 0, IdDoctor = 0 });
            listPrescriptions.Add(new Prescription { IdPrescription = 2, Date = Convert.ToDateTime("2000-01-01"), DueDate = Convert.ToDateTime("2000-01-01"), IdPatient = 1, IdDoctor = 1 });
            listPrescriptions.Add(new Prescription { IdPrescription = 3, Date = Convert.ToDateTime("2001-01-01"), DueDate = Convert.ToDateTime("2001-01-01"), IdPatient = 2, IdDoctor = 2 });
            modelBuilder.Entity<Prescription>().HasData(listPrescriptions);

            List<PrescriptionMedicament> listPrescriptionMedicament = new List<PrescriptionMedicament>();
            listPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 50, Details = "details" });
            listPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 40, Details = "details" });
            listPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 3, Dose = 10, Details = "details" });
            modelBuilder.Entity<PrescriptionMedicament>().HasData(listPrescriptionMedicament);

            List<Doctor> listDoctors = new List<Doctor>();
            listDoctors.Add(new Doctor { Id = 1, IdDoctor = 1, FirstName = "Olgierd", LastName = "Bogusz", Email = "abc@gmail.com" });
            listDoctors.Add(new Doctor { Id = 2, IdDoctor = 2, FirstName = "Kuba", LastName = "Kowalski", Email = "def@gmail.com" });
            listDoctors.Add(new Doctor { Id = 3, IdDoctor = 3, FirstName = "Mateusz", LastName = "Bakun", Email = "ghi@g.com" });
            modelBuilder.Entity<Doctor>().HasData(listDoctors);

            List<Medicament> listMedicaments = new List<Medicament>();
            listMedicaments.Add(new Medicament { IdMedicament = 1, Name = "Morphine", Description = "details", Type = "stim" });
            listMedicaments.Add(new Medicament { IdMedicament = 2, Name = "Propital", Description = "details", Type = "stim" });
            listMedicaments.Add(new Medicament { IdMedicament = 3, Name = "Meldonin", Description = "details", Type = "stim" });
            modelBuilder.Entity<Medicament>().HasData(listMedicaments);

            List<Patient> listPatients = new List<Patient>();
            listPatients.Add(new Patient { IdPatient = 1, FirstName = "Michal", LastName = "Tomaszewski", Birthdate = Convert.ToDateTime("1999-01-01") });
            listPatients.Add(new Patient { IdPatient = 2, FirstName = "Piotr", LastName = "Gago", Birthdate = Convert.ToDateTime("1999-01-01") });
            listPatients.Add(new Patient { IdPatient = 3, FirstName = "Piotr", LastName = "Gnys", Birthdate = Convert.ToDateTime("1999-01-01") });
            modelBuilder.Entity<Patient>().HasData(listPatients);


        }
    }
}
