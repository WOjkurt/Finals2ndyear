namespace JwtAuthDemo.Models.Interfaces
{
    public class CrudBase
    {
        public interface ICrudBaseClass<T> where T : class
        {
            String Create(T model);
            T Update(T model, int id);
            bool Delete(int id);

            T Fetch(int id);

        }   
    }
}
