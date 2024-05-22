namespace Collibri.Repositories.ExtensionMethods
{
    public static class IntegerMethods
    {
        public static int GenerateNewId(this int integer, List<int> list)
        {
            int generatedId;

            do
            {
                generatedId = new Random().Next(1, int.MaxValue);
            } while (list.Any(x => x.Equals(generatedId)));
            
            return generatedId;
        }
    }   
}