using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class ClinicHome
    {
        DoctorRepository doctorrepository;
        public ClinicHome() { 
            doctorrepository = new DoctorRepository();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Modify Phone");
            Console.WriteLine("3. Modify Experience");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Show All Doctors");
            Console.WriteLine("0. Exit");
        }

        void StartAdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        doctorrepository.Add();
                        break;
                    case 2:
                        UpdatePhone();
                        break;
                    case 3:
                        UpdateExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        ShowDoctor();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        private void ShowDoctor()
        {
            Console.WriteLine("***********************************");
            var doctors = doctorrepository.GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }

        int GetDoctorId()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            int id = GetDoctorId();
            if (doctorrepository.Delete(id) != null)
                Console.WriteLine("Doctor deleted");
        }
        private void UpdateExperience()
        {
            var id = GetDoctorId();
            Console.WriteLine("Please enter the new experience");
            int experience = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Experience = experience;
            doctor.Id = id;
            var result = doctorrepository.Update(id, doctor, "experience");
            if (result != null)
                Console.WriteLine("Update success");
        }
        private void UpdatePhone()
        {
            var id = GetDoctorId();
            Console.WriteLine("Please enter the new phone");
            double phone = Convert.ToDouble(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Phone = phone;
            doctor.Id = id;
            var result = doctorrepository.Update(id, doctor, "phone");
            if (result != null)
                Console.WriteLine("Update success");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Clinic App");
            ClinicHome Home = new ClinicHome();
            Home.StartAdminActivities();
        }
    }
}
