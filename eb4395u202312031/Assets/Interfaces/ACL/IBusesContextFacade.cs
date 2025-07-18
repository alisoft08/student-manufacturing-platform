namespace eb4395u202312031.Assets.Interfaces.ACL;


public interface IBusesContextFacade
{
 
    // Task<int> FetchBusByBusNumberAsync(Guid BusNumber);
    
    Task<int> FetchBusByIdAsync(int busId);
    
    Task<int> FetchNumberOfSeatsByBusIdAsync(int busId);
}