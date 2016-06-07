using System.Net;

namespace Gallows
{
    /// <summary>
    /// This class is responsible for generating a random word 
    /// using the Random Word API: http://randomword.setgetgo.com/ 
    /// </summary>
    class WordGenerator
    {
        private static readonly string URL = "http://randomword.setgetgo.com/get.php";

        public WordGenerator()
        {

        }

        public string GenerateWord()
        {
            WebClient client = new WebClient();
            // Increase web request speed by skipping proxy setup
            client.Proxy = null;
            return client.DownloadString(URL);
        }
    }
}
