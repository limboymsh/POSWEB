using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController: Controller
    {
        private IMediator _mediator;
        private User _user;
        private IPOSDbContext _dbContext;
        private Company _company;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        protected IPOSDbContext DbContext => _dbContext ?? (_dbContext = HttpContext.RequestServices.GetService<IPOSDbContext>());

        /// <summary>
        /// User login Id, NULL jika Annonymous user
        /// </summary>
        protected Guid? UserId
        {
            get
            {
                try
                {
                    return HttpContext.User.Identity.IsAuthenticated ? Guid.Parse(User.Identity.Name) : (Guid?)null;
                }
                catch (FormatException)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// User login Data, NULL jika Annonymous user
        /// </summary>
        protected User UserData => _user ?? (_user = UserId.HasValue ? DbContext.User
            .AsNoTracking()
            .First(x => x.Id == UserId.Value) : null);

        /// <summary>
        /// Company Data
        /// Akses Property ini hanya jika lolos CompanyFilterAttribute
        /// </summary>
        /*protected Company Company
        {
            get
            {
                if (_company == null)
                {
                    string companyId = HttpContext.Request.Headers
                        .FirstOrDefault(x => x.Key.ToLower() == CompanyFilterAttribute.companyHeader.ToLower()).Value.FirstOrDefault();

                    if (!companyId.IsNullOrEmpty())
                    {
                        _company = DbContext.Companies
                            .AsNoTracking()
                            .First(x => x.Id == Guid.Parse(companyId));
                    }
                }

                return _company;
            }
        }*/
    }
}
