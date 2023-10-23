

namespace Domain.Object
{
    public class Patient
    {
        public Guid Id { get;}
        public string Name { get; set; }
        //should be a list loaded from a DB
        public string AnimalType { get; set; } //dog cat etc..

        public Patient(string name, string animalType)
        {
            Id = Guid.NewGuid();
            this.Name = name;
            this.AnimalType = animalType;
        }
    }
}
