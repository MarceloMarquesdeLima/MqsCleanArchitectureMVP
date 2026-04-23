namespace MqsCleanArchitectureMVP.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }

        public Customer(string name, string document, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Document = document;
            Email = email;
        }
    }
}
