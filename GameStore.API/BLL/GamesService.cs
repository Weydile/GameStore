using GameStore.API.Models;
using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;

namespace GameStore.API.BLL
{
    public class GamesService : IService<GameModel>
    {
        public IDefaultRepository<Game> _gameRepository { get; set; }
        public IDefaultRepository<Studio> _studioRepository { get; set; }
        public IDefaultRepository<Genre> _genreRepository { get; set; }

        public GamesService(IDefaultRepository<Game> gameRepository, IDefaultRepository<Studio> studioRepository, IDefaultRepository<Genre> genreRepository)
        {
            _gameRepository = gameRepository;
            _studioRepository = studioRepository;
            _genreRepository = genreRepository;

        }

        public bool Add(GameModel item)
        {
            Game game = new Game()
            {
                Id = item.Id,
                Name = item.Name,
                Studio = _studioRepository.Get(item.StudioId),
                Genres = _genreRepository.GetAll().Where(x => item.GenresIds.Contains(x.Id)).ToList(),
            };
            return _gameRepository.Add(game);
        }

        public bool Delete(int id)
        {
            return _gameRepository.Delete(id);
        }

        public bool Delete(GameModel item)
        {
            return _gameRepository.Delete(item.Id);
        }

        public bool Edit(GameModel item)
        {
            Game game = new Game()
            {
                Id = item.Id,
                Name = item.Name,
                Studio = _studioRepository.Get(item.StudioId),
                Genres = _genreRepository.GetAll().Where(x => item.GenresIds.Contains(x.Id)).ToList(),
            };
            return _gameRepository.Edit(game);
        }
        public GameModel Get(int id)
        {
            Game game = _gameRepository.Get(id);
            return new GameModel()
            {
                Id = game.Id,
                Name = game.Name,
                GenresIds = game.Genres.Select(x => x.Id).ToList(),
                StudioId = game.Studio.Id
            };
        }

        public IQueryable<GameModel> GetAll()
        {
            return _gameRepository.GetAll().Select(x => new GameModel()
            {
                Id = x.Id,
                Name = x.Name,
                GenresIds = x.Genres.Select(x => x.Id).ToList(),
                StudioId = x.Studio.Id
            });
        }

        public bool IsExist(int id)
        {
            return _gameRepository.IsExist(id);
        }
    }
}
