using BulletinReader.DataClasses;

namespace BulletinReader
{
    public static class Statics
    {
        public static DbContextMainDataContext GetDataContext()
        {
            // string connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=\"|DataDirectory|\\DbMain.mdf\";Integrated Security=True";
            // return new DbContextMainDataContext(connectionString);
            return new DbContextMainDataContext();
        }
    }
}