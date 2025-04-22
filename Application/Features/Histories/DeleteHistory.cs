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

        public DeleteHistoryHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<History> Handle(DeleteHistoryRequest request, CancellationToken cancellationToken)
        {
            var history = await _unitOfWorks.Histories.GetByIdAsync(request.Id, cancellationToken);

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