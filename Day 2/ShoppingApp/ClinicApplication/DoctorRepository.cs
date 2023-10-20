using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class DoctorRepository
    {
        List<Doctor> doctors;

        public DoctorRepository()
        {
            doctors = new List<Doctor>();
        }
        int GetNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors[doctors.Count - 1].Id;
            return ++id;
        }
        void TakeRemainingDetails(Doctor doctor)
        {
            Console.WriteLine("Please enter the doctor name");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the doctor's specialisation");
            doctor.Specialisation= Console.ReadLine();
            Console.WriteLine("Please enter the doctor's experience");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the doctor's phone");
            doctor.Phone= Convert.ToDouble(Console.ReadLine());
        }
        public Doctor Add()
        {
            int id = GetNextId();
            Doctor doctor = new Doctor();
            doctor.Id = id;
            TakeRemainingDetails (doctor);
            doctors.Add(doctor);
            return doctor;
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }
        public Doctor GetDoctorById(int id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == id)
                    return doctors[i];
            }
            return null;
        }
        public Doctor Delete(int id)
        {
            Doctor myDoctor = GetDoctorById(id);
            if (myDoctor != null)
            {
                doctors.Remove(myDoctor);
                Console.WriteLine("Product deleted");
                return myDoctor;
            }
            return null;

        }
        public Doctor Update(int id, Doctor doctor, string choice)
        {
            Doctor myDoctor = GetDoctorById(id);
            if (myDoctor != null)
            {

                if (choice == "experience")
                {
                    if (doctor.Experience > 0)
                    {
                        myDoctor.Experience= doctor.Experience;
                        return myDoctor;
                    }
                }
                else if (choice == "phone")
                {
                    if (doctor.Phone != 0)
                    {
                        myDoctor.Phone = doctor.Phone;
                        return myDoctor;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            Console.WriteLine("Could not update");
            return null;
        }
    }
}
