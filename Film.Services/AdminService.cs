using Film.Data;
using Film.Models.AdminRemove;
using FilmAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Services
{
    public class AdminService
    {
        private readonly Guid _profileID;
        public AdminService(Guid profileID)
        {
            _profileID = profileID;
        }
       public bool CreateRemoval(AdminCreate model)
        {
            var entity =
                new AdminRemove()
                {
                    RemoveId = model.RemoveId,
                    Username = model.Username,
                    ProfileId = model.ProfileId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Removals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AdminListItem> GetAdminRemovals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Removals
                        .Where(e => e.ProfileId == _profileID)
                        .Select(
                        e =>
                        new AdminListItem
                        {
                            RemoveId = e.RemoveId,
                            Username = e.Username,
                            ProfileId = e.ProfileId
                        }
                        );
                return query.ToArray();
            }
        }
        public AdminDetail GetRemovalById(int removeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Removals
                    .Single(e => e.RemoveId == removeId && e.ProfileId == _profileID);
                return
                    new AdminDetail
                    {
                        RemoveId = entity.RemoveId,
                        Username = entity.Username
                    };
            }
        }
        public bool UpdateRemoval(AdminEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Removals
                        .Single(e => e.RemoveId == model.RemoveId);

                entity.RemoveId = model.RemoveId;
                entity.Username = model.Username;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRemoval(int removeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Removals
                        .Single(e => e.RemoveId == removeId);
                ctx.Removals.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
