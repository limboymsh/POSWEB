using Application.Common.Interfaces;
using Application.Common.Mappings;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Handlers.Inventories.Commands.Create
{

    public class CreateInventoryCommand: CreateInventoryDtoCommand , IRequest
    {

    }

    public class CreateInventoryDtoCommand : CreateInventoryDTO, IAuthorizeUserOnlyCommand
    {
        //public Company Company { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public User User { get; set; }
    }
    public class CreateInventoryDTO : IMapTo<CreateInventoryCommand>
    {

        public Guid CompanyId { get; set; }
        public Guid OutletId { get; set; }
        public string Name { get; set; }
        public Guid InventoryCategoryId { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsServices { get; set; }

    }


}