using GameStore.API.Models;
using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;

namespace GameStore.API.BLL
{
    public class StudioService : IService<StudioModel>
    {
        public IDefaultRepository<Game> _gameRepository { get; set; }
        public IDefaultRepository<Studio> _studioRepository { get; set; }
        public IDefaultRepository<Genre> _genreRepository { get; set; }

        public StudioService(IDefaultRepository<Game> gameRepository, IDefaultRepository<Studio> studioRepository, IDefaultRepository<Genre> genreRepository)
        {
            _gameRepository = gameRepository;
            _studioRepository = studioRepository;
            _genreRepository = genreRepository;

        }

        public bool Add(StudioModel item)
        {
            Studio studio = new Studio()
            {
                Id = item.Id,
                Name = item.Name,
            };
            return _studioRepository.Add(studio);
        }

        public bool Delete(int id)
        {
            return _studioRepository.Delete(id);
        }

        public bool Delete(StudioModel item)
        {
            return _studioRepository.Delete(item.Id);
        }

        public bool Edit(StudioModel item)
        {
            Studio studio = new Studio()
            {
                Id = item.Id,
                Name = item.Name,
            };
            return _studioRepository.Edit(studio);
        }
        public StudioModel Get(int id)
        {
            Studio studio = _studioRepository.Get(id);
            return new StudioModel()
            {
                Id = studio.Id,
                Name = studio.Name
            };
        }

        public IQueryable<StudioModel> GetAll()
        {
            return _studioRepository.GetAll().Select(x => new StudioModel()
            {
                Id = x.Id,
                Name = x.Name,
            });
        }

        public bool IsExist(int id)
        {
            return _studioRepository.IsExist(id);
        }
    }
}
