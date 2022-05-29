using GameStore.API.Models;
using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;

namespace GameStore.API.BLL
{
    public class GenresService : IService<GenreModel>
    {
        public IDefaultRepository<Game> _gameRepository { get; set; }
        public IDefaultRepository<Studio> _studioRepository { get; set; }
        public IDefaultRepository<Genre> _genreRepository { get; set; }

        public GenresService(IDefaultRepository<Game> gameRepository, IDefaultRepository<Studio> studioRepository, IDefaultRepository<Genre> genreRepository)
        {
            _gameRepository = gameRepository;
            _studioRepository = studioRepository;
            _genreRepository = genreRepository;

        }

        public bool Add(GenreModel item)
        {
            Genre genre = new Genre()
            {
                Id = item.Id,
                Name = item.Name,
            };
            return _genreRepository.Add(genre);
        }

        public bool Delete(int id)
        {
            return _genreRepository.Delete(id);
        }

        public bool Delete(GenreModel item)
        {
            return _genreRepository.Delete(item.Id);
        }

        public bool Edit(GenreModel item)
        {
            Genre genre = new Genre()
            {
                Id = item.Id,
                Name = item.Name,
            };
            return _genreRepository.Edit(genre);
        }
        public GenreModel Get(int id)
        {
            Genre genre = _genreRepository.Get(id);
            return new GenreModel()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public IQueryable<GenreModel> GetAll()
        {
            return _genreRepository.GetAll().Select(x => new GenreModel()
            {
                Id = x.Id,
                Name = x.Name,
            });
        }

        public bool IsExist(int id)
        {
            return _genreRepository.IsExist(id);
        }
    }
}
