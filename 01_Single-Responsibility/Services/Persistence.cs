//using System.Security.Cryptography.X509Certificates;
using models;

namespace Services
{
    #region
    //
    #endregion



    public class Persistence
    {
        //Save File To Desktop...
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, filename);
                File.WriteAllText(filePath, journal.ToString());
            }

        }
    }
}