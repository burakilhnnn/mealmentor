using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;
using Application.Common.IUnitOfWorks;
using Application.Services;

namespace Application.Features.Histories
{
    public class DeleteHistoryHandler : IRequestHandler<DeleteHistoryRequest, History>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly ICurrentUserService _currentUserService;

        public DeleteHistoryHandler(IUnitOfWorks unitOfWorks, ICurrentUserService currentUserService)
        {
            _unitOfWorks = unitOfWorks;
            _currentUserService = currentUserService;
        }

        public async Task<History> Handle(DeleteHistoryRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var history = await _unitOfWorks.Histories.GetByIdAsync(request.Id, cancellationToken);

            if (history == null || history.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this history");
            }

            await _unitOfWorks.Histories.Delete(history);
            await _unitOfWorks.SaveAsync();
            
            return history;
        }
    }

    public class DeleteHistoryRequest : IRequest<History>
    {
        public Guid Id { get; set; }
    }
}