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
        //        public DeleteRemoval (int removeId)
        //        {
        //            using (var ctx = new ApplicationDbContext())
        //                var entity =
        //                    ctx
        //                    .Removals
        //                    .Single(e => e.RemoveID == removeID && e.ProfileID == _profileID);

        //            ctx.Removals.Remove(entity);
        //            return ctx.SaveChanges() == 1;
        //        }

        //    }

        public AdminDetail GetRemovalById(int removeId)
        {
            using (var ctx =  new ApplicationDbContext())
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
    }
}
