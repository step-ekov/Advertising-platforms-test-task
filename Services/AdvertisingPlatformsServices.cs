namespace TestTask.Services
{
    public class AdvertisingPlatformsServices : IAdvertisingPlatformsServices
    {
        public Dictionary<string, List<string>> Download()
        {
            string file = "C:\\Users\\Степан\\Desktop\\Рекламные площадки.txt";

            var allPlatforms = new Dictionary<string, List<string>>();
            var lines = File.ReadAllLines(file);

            foreach (var platforms in lines)
            {
                var separatePlatform = platforms.Split(':');

                var platform = separatePlatform[0];
                var location = separatePlatform[1]
                    .Split(',')
                    .Select(loc => loc.Trim())
                    .ToList();

                allPlatforms[platform] = location;
            }
            return allPlatforms;
        }

        public Dictionary<string, List<string>> searchPlatforms(string input)
        {
            try
            {
                var allPlatforms = Download();

                var resultPlatform = allPlatforms
                .Where(platforms => platforms.Value.Any(platform => input.StartsWith(platform)))
                .ToDictionary(p => p.Key, p => p.Value);

                if (resultPlatform.Any())
                    return resultPlatform;
                else
                    throw new Exception("Платформы не найдены");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
