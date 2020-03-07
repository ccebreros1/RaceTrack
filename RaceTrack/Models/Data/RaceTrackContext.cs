﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RaceTrack.Models;

namespace RaceTrack.Data
{
    public class RaceTrackContext : DbContext
    {
        public RaceTrackContext(DbContextOptions<RaceTrackContext> options) : base(options)
        {
        }

        public DbSet<RaceTrackInfo> RaceTracksInfo { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceVehicle> RaceVehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RaceTrackInfo>().ToTable("RaceTrackInfo");
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<RaceVehicle>().ToTable("RaceVehicle");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<VehicleType>().ToTable("VehicleType");
        }
    }
}