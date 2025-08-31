namespace TestTask.Services
{
    public interface IAdvertisingPlatformsServices
    {
        Dictionary<string, List<string>> Download();
        Dictionary<string, List<string>> searchPlatforms(string input);
    }
}
