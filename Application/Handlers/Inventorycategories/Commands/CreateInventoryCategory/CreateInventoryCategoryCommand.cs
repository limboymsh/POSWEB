using Application.Common.Interfaces;
using Application.Repositories;
using Application.Repositories.Response;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Inventorycategories.Commands.CreateInventoryCategory
{
    public class CreateInventoryCategoryCommand: IRequest<SaveCategoryResponse>
    {
        public InventoryCategory Category { get; set; }

        class Handler : IRequestHandler<CreateInventoryCategoryCommand, SaveCategoryResponse>
        {
            private readonly IPOSDbContext context;

            public Handler(IPOSDbContext context)
            {
                this.context = context;
            }

            public async Task<SaveCategoryResponse> Handle(CreateInventoryCategoryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await context.InventoryCategory.AddAsync(request.Category);

                    
                    return new SaveCategoryResponse(true, "Berhasil Menyimpan.", request.Category);
                }
                catch (Exception ex)
                {
                    return new SaveCategoryResponse($"An error occured when saveing the category: {ex.Message}");
                }
            }
        }
    }


}
