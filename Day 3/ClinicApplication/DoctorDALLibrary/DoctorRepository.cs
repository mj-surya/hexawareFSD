using DoctorModelLibrary;
namespace DoctorDALLibrary
{
    public class DoctorRepository : IRepository
    {
        Dictionary<int, Doctor> doctors = new Dictionary<int, Doctor>();
        /// <summary>
        /// Adds doctors to dictionary
        /// </summary>
        /// <param name="doctor">object has to be added</param>
        /// <returns></returns>
        public Doctor Add(Doctor doctor)
        {
            int id = GetTheNextId();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                return doctor;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The doctor Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;

        }
        private int GetTheNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }
        /// <summary>
        /// Deletes the doctor
        /// </summary>
        /// <param name="id">Id of the doctor to delete</param>
        /// <returns></returns>
        public Doctor Delete(int id)
        {
            var doctor = doctors[id];
            doctors.Remove(id);
            return doctor;
        }
        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }
        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctors[doctor.Id];
        }

        public Doctor GetById(int id)
        {
            return doctors[id];
        }
    }
}