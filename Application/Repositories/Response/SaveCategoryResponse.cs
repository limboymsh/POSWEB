using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories.Response
{
    class SaveCategoryResponse : BaseResponse
    {
        public InventoryCategory Category { get; private set; }
        public string bab = "lomom";

        public SaveCategoryResponse(bool success, string message, InventoryCategory category) : base(success, message)
        {
            Category = category;
        }

        public SaveCategoryResponse(InventoryCategory category) : this(true, string.Empty, category)
        { }

        public SaveCategoryResponse(string message) : this(false, message, null)
        { }
    }
}
