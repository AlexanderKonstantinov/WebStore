using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;

namespace WebStore.Services.CustomIdentity
{
    public class CustomUserStore : UserStore<User>
    {
        public CustomUserStore(DbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
