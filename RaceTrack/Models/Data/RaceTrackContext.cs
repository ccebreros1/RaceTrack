using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RaceTrack.Models;

namespace RaceTrack.Data
{
    public class RaceTrackContext : DbContext
    {
        public RaceTrackContext()
        {
        }

        public RaceTrackContext(DbContextOptions<RaceTrackContext> options) : base(options)
        {
        }

        public virtual  DbSet<RaceTrackInfo> RaceTracksInfo { get; set; }
        public virtual  DbSet<Race> Races { get; set; }
        public virtual  DbSet<RaceVehicle> RaceVehicles { get; set; }
        public virtual  DbSet<Vehicle> Vehicles { get; set; }
        public virtual  DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RaceTrackInfo>().ToTable("RaceTrackInfo");
            modelBuilder.Entity<RaceTrackInfo>()
            .HasKey(r => r.Id);
            modelBuilder.Entity<RaceTrackInfo>()
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<Race>()
           .HasKey(r => r.Id);
            modelBuilder.Entity<Race>()
           .Property(r => r.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<RaceVehicle>().ToTable("RaceVehicle");
            modelBuilder.Entity<RaceVehicle>()
           .HasKey(r => r.Id);
            modelBuilder.Entity<RaceVehicle>()
           .Property(r => r.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Vehicle>()
           .HasKey(v => v.Id);
            modelBuilder.Entity<Vehicle>()
           .Property(v => v.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<VehicleType>().ToTable("VehicleType");
            modelBuilder.Entity<VehicleType>()
           .HasKey(v => v.Id);
            modelBuilder.Entity<VehicleType>()
           .Property(v => v.Id)
           .ValueGeneratedOnAdd();
        }
    }
}
