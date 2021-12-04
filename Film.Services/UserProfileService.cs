using Film.Data;
using Film.Models;
using FilmAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Services
{
    public class UserProfileService
    {
        private readonly Guid _userId;

        public bool CreateUserProfile(UserProfileCreate model)
        {
            var entity =
                new UserProfile()
                {
                    UserId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserProfile.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserProfileCreate> GetUserProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserProfile
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new UserProfileCreate
                                {
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.Email
                                }
                        );
                return query.ToArray();
            }
        }

        public UserProfileService(Guid userId)
        {
            _userId = userId;
        }

    }
}
