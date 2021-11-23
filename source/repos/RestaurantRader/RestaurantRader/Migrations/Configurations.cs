using RestaurantRader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

internal sealed class Configuration : DbMigrationsConfiguration<RestaurantRader.Models.RestaurantDbContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(RestaurantRader.Models.RestaurantDbContext context)
    {
     
    }
}