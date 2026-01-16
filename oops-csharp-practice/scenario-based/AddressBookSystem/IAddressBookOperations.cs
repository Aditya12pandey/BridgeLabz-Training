namespace AddressBookSystem
{
    public interface IAddressBookOperations
    {
        void AddContact();
        void AddMultipleContacts();
        void EditContact();
        void DeleteContact();
        void DisplayAllContacts();
        void SearchPersonByCityOrState();
        void ViewPersonsByCityOrState(); 
    }
}
