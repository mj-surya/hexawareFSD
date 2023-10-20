using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApplication
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public string Specialisation { get; set; }
        public double Phone { get; set; }
        public Doctor() { 
            Experience = 0;
        }
        public Doctor(int id, string name, int experience, string specialisation, double phone) {
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
