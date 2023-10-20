

namespace Domain.Object
{
    public class Patient
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string AnimalType { get; set; } //dog cat etc..

        public Patient(Guid id, string name, string animalType)
        {
            this.Id = id;
            this.Name = name;
            this.AnimalType = animalType;
        }
    }
}
