using PostService.DataAccess;
using PostService.Models;

namespace PostService.BusinessLogic;

public class PostingService : IPostingService
{
    private readonly IPostingRepository _repository;

    public PostingService(IPostingRepository repository)
    {
        _repository = repository;
    }

    public List<Posting> GetAll()
    {
        return _repository.GetList();
    }

    public Posting? Find(int id)
    {
        return _repository.GetById(id);
    }

    public Posting Create(Posting posting)
    {
        _repository.Create(posting);
        return posting;
    }

    public Posting? Update(Posting posting)
    {
        var existing = _repository.GetById(posting.Id);
        if (existing is null)
            return null;

        _repository.Update(posting);
        return posting;
    }

    public int Delete(int id)
    {
        return _repository.Delete(id);
    }
}