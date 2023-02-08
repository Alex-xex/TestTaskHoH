namespace TestTaskHoH.Context
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
        }
    }
}
