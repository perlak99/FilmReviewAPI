using AutoMapper;
using FilmReviewAPI.DTOs.Comment;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IFilmRepository filmRepository, IDirectorRepository directorRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _filmRepository = filmRepository;
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task AddCommentAsync(AddCommentDto request, int userId)
        {
            if (request.FilmId != null)
            { 
                if (!await _filmRepository.CheckIfExistsById((int)request.FilmId))
                {
                    throw new ArgumentException("Film not found");
                }
            }

            if (request.DirectorId != null)
            {
                if (!await _directorRepository.CheckIfExistsById((int)request.DirectorId))
                {
                    throw new ArgumentException("Director not found");
                }
            }

            if (request.ParentCommentId != null)
            {
                if (!await _commentRepository.CheckIfExistsById((int)request.ParentCommentId))
                {
                    throw new ArgumentException("Parent comment not found");
                }
            }

            var comment = _mapper.Map<Comment>(request);
            comment.UserId = userId;
            await _commentRepository.AddAsync(comment);
        }
    }
}
