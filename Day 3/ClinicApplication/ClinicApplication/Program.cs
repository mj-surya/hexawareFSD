using DoctorModelLibrary;
using DoctorBLLibrary;
using DoctorDALLibrary;
using System.Numerics;

namespace ClinicApplication
{
    internal class Program
    {
        IDoctorService doctorService;
        public Program() { 
            doctorService =new DoctorService();
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
                        AddDoctor();
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
            var doctors = doctorService.GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        void AddDoctor()
        {
            try
            {
                Doctor doctor= TakeDoctorDetails();
                var result = doctorService.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        Doctor TakeDoctorDetails()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Please enter the doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the doctor's specialisation");
            doctor.Specialisation = Console.ReadLine();
            Console.WriteLine("Please enter the doctor's experience");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the doctor's phone");
            doctor.Phone = Convert.ToDouble(Console.ReadLine());
            return doctor;
        }
        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the doctor id");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        private void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (doctorService.Delete(id) != null)
                    Console.WriteLine("Doctor deleted");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdatePhone()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new phone");
            double phone = Convert.ToDouble(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Phone = phone;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateDoctorPhone(id, phone);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateExperience()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new experience");
            int experience = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Experience = experience;
            doctor.Id = id;
            try
            {
                var result = doctorService.UpdateDoctorExperience(id, experience);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartAdminActivities();
        }
    }
}