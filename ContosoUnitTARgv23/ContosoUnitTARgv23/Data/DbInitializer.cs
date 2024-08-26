namespace ContosoUnitTARgv23.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }


        }
    }
}
