﻿// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using ExtCore.Data.EntityFramework;
using Manufactures.Domain.FabricConstructions.ReadModels;
using Manufactures.Domain.Estimations.Productions.Entities;
using Manufactures.Domain.Estimations.Productions.ReadModels;
using Manufactures.Domain.Materials.ReadModels;
using Manufactures.Domain.Orders.ReadModels;
using Manufactures.Domain.YarnNumbers.ReadModels;
using Manufactures.Domain.Suppliers.ReadModels;
using Manufactures.Domain.Yarns.ReadModels;
using Microsoft.EntityFrameworkCore;
using Manufactures.Domain.Machines.ReadModels;
using Manufactures.Domain.MachineTypes.ReadModels;
using Manufactures.Domain.MachinesPlanning.ReadModels;
using Manufactures.Domain.DailyOperations.Loom.Entities;
using Manufactures.Domain.DailyOperations.Loom.ReadModels;
using Manufactures.Domain.Shifts.ReadModels;
using Manufactures.Domain.Operators.ReadModels;
using Manufactures.Domain.DailyOperations.Sizing.Entities;
using Manufactures.Domain.DailyOperations.Sizing.ReadModels;
using Manufactures.Domain.Beams.ReadModels;
using Manufactures.Domain.Movements.ReadModels;
using Manufactures.Domain.DailyOperations.Warping.ReadModels;
using Manufactures.Domain.DailyOperations.Warping.Entities;
using Manufactures.Domain.StockCard.ReadModels;
using Manufactures.Domain.DailyOperations.Reaching.Entities;
using Manufactures.Domain.DailyOperations.Reaching.ReadModels;
using Manufactures.Domain.Defects.FabricDefect.ReadModels;
using Manufactures.Domain.BeamStockMonitoring.ReadModels;

namespace Manufactures.Data.EntityFrameworkCore
{
    public class EntityRegistrar : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FabricDefectReadModel>(etb =>
            {
                etb.ToTable("Weaving_FabricDefectDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(e => e.DefectCode).HasMaxLength(255);
                etb.Property(e => e.DefectType).HasMaxLength(255);
                etb.Property(e => e.DefectCategory).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<BeamStockMonitoringReadModel>(etb =>
            {
                etb.ToTable("Weaving_BeamStockMonitoringDocuments");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationReachingHistory>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationReachingHistories");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationReachingReadModel>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationReachingDocuments");
                etb.HasKey(e => e.Identity);

                etb.HasMany(e => e.ReachingHistories)
                    .WithOne(e => e.DailyOperationReachingDocument)
                    .HasForeignKey(e => e.DailyOperationReachingDocumentId);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<StockCardReadModel>(etb =>
            {
                etb.ToTable("Weaving_StockCardDocuments");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationWarpingBeamProduct>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationWarpingBeamProducts");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationWarpingHistory>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationWarpingHistories");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationWarpingReadModel>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationWarpingDocuments");
                etb.HasKey(e => e.Identity);

                etb.HasMany(e => e.WarpingBeamProducts)
                    .WithOne(e => e.DailyOperationWarpingDocument)
                    .HasForeignKey(e => e.DailyOperationWarpingDocumentId);

                etb.HasMany(e => e.WarpingHistories)
                    .WithOne(e => e.DailyOperationWarpingDocument)
                    .HasForeignKey(e => e.DailyOperationWarpingDocumentId);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<MovementReadModel>(etb =>
            {
                etb.ToTable("Weaving_MovementDocuments");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<BeamReadModel>(etb =>
            {
            etb.ToTable("Weaving_BeamDocuments");
            etb.HasKey(e => e.Identity);

            etb.Property(p => p.Number).HasMaxLength(255);
            etb.Property(p => p.Type).HasMaxLength(255);

            etb.ApplyAuditTrail();
            etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationSizingBeamProduct>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationSizingBeamProducts");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationSizingHistory>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationSizingHistories");
                etb.HasKey(e => e.Identity);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationSizingReadModel>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationSizingDocuments");
                etb.HasKey(e => e.Identity);

                etb.HasMany(e => e.SizingBeamProducts)
                    .WithOne(e => e.DailyOperationSizingDocument)
                    .HasForeignKey(e => e.DailyOperationSizingDocumentId);

                etb.HasMany(e => e.SizingHistories)
                    .WithOne(e => e.DailyOperationSizingDocument)
                    .HasForeignKey(e => e.DailyOperationSizingDocumentId);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<OperatorReadModel>(etb =>
            {
                etb.ToTable("Weaving_OperatorDocuments");
                etb.HasKey(e => e.Identity);
                etb.Property(e => e.Assignment).HasMaxLength(255);
                etb.Property(e => e.Type).HasMaxLength(255);
                etb.Property(e => e.Group).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<ShiftReadModel>(etb =>
            {
                etb.ToTable("Weaving_ShiftDocuments");
                etb.HasKey(e => e.Identity);
                etb.Property(e => e.Name).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<DailyOperationLoomDetail>(etb =>
        {
            etb.ToTable("Weaving_DailyOperationLoomDetails");
            etb.HasKey(e => e.Identity);

            etb.ApplyAuditTrail();
            etb.ApplySoftDelete();
        });

            modelBuilder.Entity<DailyOperationLoomReadModel>(etb =>
            {
                etb.ToTable("Weaving_DailyOperationLoomDocuments");
                etb.HasKey(e => e.Identity);

                etb.HasMany(e => e.DailyOperationLoomDetails)
                    .WithOne(e => e.DailyOperationLoomDocument)
                    .HasForeignKey(e => e.DailyOperationLoomDocumentId);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<MachinesPlanningReadModel>(etb =>
            {
                etb.ToTable("Weaving_MachinesPlanningDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(e => e.Area).HasMaxLength(255);
                etb.Property(e => e.Blok).HasMaxLength(255);
                etb.Property(e => e.BlokKaizen).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<MachineTypeReadModel>(etb =>
            {
                etb.ToTable("Weaving_MachineTypeDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(e => e.TypeName).HasMaxLength(255);
                etb.Property(e => e.MachineUnit).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<MachineDocumentReadModel>(etb =>
            {
                etb.ToTable("Weaving_MachineDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(e => e.MachineNumber).HasMaxLength(255);
                etb.Property(e => e.Location).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<EstimationProduct>(etb =>
            {
                etb.ToTable("Weaving_EstimationDetails");
                etb.HasKey(e => e.Identity);

                etb.Property(e => e.OrderDocument).HasMaxLength(2000);
                etb.Property(e => e.ProductGrade).HasMaxLength(2000);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<EstimatedProductionDocumentReadModel>(etb =>
            {
                etb.ToTable("Weaving_EstimationProductDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(e => e.Period).HasMaxLength(255);

                etb.HasMany(e => e.EstimationProducts)
                    .WithOne(e => e.EstimatedProductionDocument)
                    .HasForeignKey(e => e.EstimatedProductionDocumentId);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<YarnDocumentReadModel>(etb =>
            {
                etb.ToTable("Weaving_YarnDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(p => p.Code).HasMaxLength(255);
                etb.Property(p => p.Name).HasMaxLength(255);
                etb.Property(p => p.Tags).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<WeavingSupplierDocumentReadModel>(etb =>
            {
                etb.ToTable("Weaving_SupplierDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(p => p.Code).HasMaxLength(255);
                etb.Property(p => p.Name).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<YarnNumberDocumentReadModel>(etb =>
            {
                etb.ToTable("Weaving_YarnNumberDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(p => p.Code).HasMaxLength(255);
                etb.Property(p => p.Number).HasMaxLength(255);
                etb.Property(p => p.Description).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<FabricConstructionReadModel>(etb =>
            {
                etb.ToTable("Weaving_ConstructionDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(p => p.ConstructionNumber).HasMaxLength(255);
                etb.Property(p => p.WovenType).HasMaxLength(255);
                etb.Property(p => p.WarpType).HasMaxLength(255);
                etb.Property(p => p.WeftType).HasMaxLength(255);
                etb.Property(p => p.ListOfWarp).HasMaxLength(20000);
                etb.Property(p => p.ListOfWeft).HasMaxLength(20000);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<MaterialTypeReadModel>(etb =>
            {
                etb.ToTable("Weaving_MaterialTypeDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(p => p.Code).HasMaxLength(255);
                etb.Property(p => p.Name).HasMaxLength(255);
                etb.Property(p => p.Description).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });

            modelBuilder.Entity<OrderDocumentReadModel>(etb =>
            {
                etb.ToTable("Weaving_OrderDocuments");
                etb.HasKey(e => e.Identity);

                etb.Property(p => p.ConstructionId).HasMaxLength(255);
                etb.Property(p => p.Period).HasMaxLength(255);
                etb.Property(p => p.WarpComposition).HasMaxLength(255);
                etb.Property(p => p.WeftComposition).HasMaxLength(255);
                etb.Property(p => p.OrderStatus).HasMaxLength(255);

                etb.ApplyAuditTrail();
                etb.ApplySoftDelete();
            });
        }
    }
}