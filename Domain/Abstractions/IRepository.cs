
namespace Domain.Abstractions
{
    public interface IRepository
    {
         Task GetDataFromApi(string pair, int intervalMinutes, bool stopGet);
         Task StopData();
    }
}
