namespace PhoneBookApp.Abstractions
{
    public interface IContactItem
    {
        string FirstName { get; }

        string LastName { get; }

        string Email { get; }

        string PhoneNumber { get; }
    }
}
