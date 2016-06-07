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
        public string Word { get; set; }

        public WordGenerator()
        {

        }

        public void GenerateWord()
        {
            WebClient client = new WebClient();
            Word = client.DownloadString(URL);
        }
    }
}
