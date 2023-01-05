

using WebAppMVC.Models;

namespace WebAppMVC.Service
{
    public interface IFilmeServiceInterface
    {
        List<Movie> GetFilmes();
        Movie GetFilme(int id);
        void AddFilme(Movie item);
        void UpdateFilme(Movie item);
        void DeleteFilme(int id);
        bool FilmeExists(int id);
    }
}
