using DoctorDALLibrary;
using DoctorModelLibrary;
using System.Diagnostics;

namespace DoctorBLLibrary
{
    public class DoctorService : IDoctorService
    {
        IRepository repository;
        public DoctorService()
        {
            repository = new DoctorRepository();
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            var result = repository.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                repository.Delete(id);
                return doctor;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor GetDoctor(int id)
        {
            var result = repository.GetById(id);

            //null collasing operator
            return result ?? throw new NoSuchDoctorException();
        }

        public List<Doctor> GetDoctors()
        {
            var doctors = repository.GetAll();
            if (doctors.Count != 0)
                return doctors;
            throw new NoDoctorsAvailableException();
        }

        public Doctor UpdateDoctorExperience(int id, int experience)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Experience= experience;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor UpdateDoctorPhone(int id, double phone)
        {
            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Phone = phone;
                var result = repository.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }
    }
}