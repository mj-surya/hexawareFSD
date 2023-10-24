namespace DoctorModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public string Specialisation { get; set; }
        public double Phone { get; set; }
        public Doctor()
        {
            Experience = 0;
        }
        /// <summary>
        /// Constructs the doctor object with properties
        /// </summary>
        /// <param name="id">Doctor id</param>
        /// <param name="name">Doctor's name</param>
        /// <param name="experience">Doctor's experience</param>
        /// <param name="specialisation">Doctor's specialisation</param>
        /// <param name="phone">Doctor's phone</param>
        public Doctor(int id, string name, int experience, string specialisation, double phone)
        {
            Id = id;
            Name = name;
            Experience = experience;
            Specialisation = specialisation;
            Phone = phone;

        }
        public override string ToString()
        {
            return $"Doctor ID : {Id}\nName : {Name}\nSpecialisation : {Specialisation}\nExperience : {Experience} years\nPhone : {Phone}";
        }

    }
}