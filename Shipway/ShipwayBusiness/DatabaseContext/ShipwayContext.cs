using ShipwayBusiness.Entities;
using ShipwayBusiness.Entities.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.DatabaseContext
{
    public class ShipwayContext:DbContext
    {
        static ShipwayContext()
        {
            Database.SetInitializer<ShipwayContext>(null);
        }
        public ShipwayContext(): base("Name= ShipwayConnectionString")
        {

        }

        public DbSet<Agency> Agency { get; set; }
        public DbSet<Exhibition> Exhibition { get; set; }
        public DbSet<ExhibitionStatus> ExhibitionStatus { get; set; }
        public DbSet<KindService> KindService { get; set; }
        public DbSet<KindTimeReceived> KindTimeReceived { get; set; }
        public DbSet<NoteRequired> NoteRequired { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<ServiceCharge> ServiceCharge { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Ward> Ward { get; set; }
        public DbSet<Router> Router { get; set; }
        public DbSet<HistoryTrip> HistoryTrips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AgencyMap());
            modelBuilder.Configurations.Add(new ExhibitionMap());
            modelBuilder.Configurations.Add(new ExhibitionStatusMap());
            modelBuilder.Configurations.Add(new KindServiceMap());
            modelBuilder.Configurations.Add(new KindTimeReceivedMap());
            modelBuilder.Configurations.Add(new NoteRequiredMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
            modelBuilder.Configurations.Add(new ServiceChargeMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new WardMap());
            modelBuilder.Configurations.Add(new RouterMap());
            modelBuilder.Configurations.Add(new HistoryTripMap());
        }
    }
}