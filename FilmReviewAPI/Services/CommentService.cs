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
                var film = await _filmRepository.GetFilmByIdAsync((int)request.FilmId);
                if (film == null)
                {
                    throw new ArgumentException("Film not found");
                }
            }

            if (request.DirectorId != null)
            {
                var director = await _directorRepository.GetDirectorByIdAsync((int)request.DirectorId);
                if (director == null)
                {
                    throw new ArgumentException("Director not found");
                }
            }

            if (request.ParentCommentId != null)
            {
                var parentComment = await _commentRepository.GetCommentByIdAsync((int)request.ParentCommentId);
                if (parentComment == null)
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
