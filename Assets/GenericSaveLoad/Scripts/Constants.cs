namespace SaveLoadSystem
{
    public static class Constants
    {
        public static readonly string SAVE_LOAD_PREFERENCES_FILENAME = "INTERNAL_SaveLoadPreferences";
        public static readonly char[] READABLE_FILE_INVALID = { '"', '<', '>', '|', ':', '*', '?', '/', '\\' };
        // the perfect windows only solution. Mostly because I assume that `Path.GetInvalidFileNameChars()` actually checks your OS since C# is platform independent
    }
}
