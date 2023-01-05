using WebAppMVC.Models;


namespace WebAppMVC.Service
{
    public class FilmeService : IFilmeServiceInterface
    {
        public List<Movie> movies;

        public FilmeService()
        {
            this.movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Moscou contra 007", Year = 1983, Resume = "um agente a serviço da SPECTRE, evela um plano de roubar o criptógrafo Lektor dos soviéticos e vendê-lo novamente aos mesmos, e simultaneamente se vingar de James pelo assassinato de Dr. No." },
                new Movie { Id = 2, Name = "Os diamentes são eternos", Year = 1971, Resume = "Bond é encarregado de investigar um misterioso fluxo de diamantes envolvendo África, Estados Unidos e Holanda. Disfarçado como  um contrabandista profissional de nome Peter Franks, Bond viaja a Amsterdão para contactar Tiffany Case." },
                new Movie { Id = 3, Name = "Só se vive duas vezes", Year = 1967, Resume = "O Agente 007 é enviado ao Japão para investigar o sequestro de uma nave espacial americana por forças desconhecidas. Logo ao chegar, Bond é contactado por Aki, assistente de Tiger Tanaka, do Serviço Secreto Japonês." }};
        }

        public void AddFilme(Movie item)
        {
            movies.Add(item);
        }

        public void DeleteFilme(int id)
        {
            
            var model = movies.Where(m => m.Id == id).FirstOrDefault();
            if(model != null)
                movies.Remove(model);
        }

        public bool FilmeExists(int id)
        {
            return this.movies.Any(m => m.Id == id);
        }

        public Movie GetFilme(int id)
        {
           return movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Movie> GetFilmes()
        {
            return this.movies.ToList();
        }

        public void UpdateFilme(Movie item)
        {
            var model = this.movies.Where(m => m.Id == item.Id).FirstOrDefault();

            model.Name = item.Name;
            model.Year = item.Year;
            model.Resume = item.Resume;
        }
    }
}
