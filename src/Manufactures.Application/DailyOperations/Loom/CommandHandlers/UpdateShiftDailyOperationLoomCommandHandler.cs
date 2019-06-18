﻿using ExtCore.Data.Abstractions;
using Infrastructure.Domain.Commands;
using Manufactures.Application.Helpers;
using Manufactures.Domain.DailyOperations.Loom;
using Manufactures.Domain.DailyOperations.Loom.Commands;
using Manufactures.Domain.DailyOperations.Loom.Entities;
using Manufactures.Domain.DailyOperations.Loom.Repositories;
using Microsoft.EntityFrameworkCore;
using Moonlay;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manufactures.Application.DailyOperations.Loom.CommandHandlers
{
    public class UpdateShiftDailyOperationLoomCommandHandler
        : ICommandHandler<UpdateShiftDailyOperationLoomCommand,
                          DailyOperationLoomDocument>
    {
        private readonly IStorage _storage;
        private readonly IDailyOperationLoomRepository
            _dailyOperationalDocumentRepository;

        public UpdateShiftDailyOperationLoomCommandHandler(IStorage storage)
        {
            _storage = storage;
            _dailyOperationalDocumentRepository =
                _storage.GetRepository<IDailyOperationLoomRepository>();
        }
        public async Task<DailyOperationLoomDocument>
            Handle(UpdateShiftDailyOperationLoomCommand request,
                   CancellationToken cancellationToken)
        {
            //Add query
            var query =
                _dailyOperationalDocumentRepository
                    .Query
                    .Include(o => o.DailyOperationLoomDetails);
            //Get existing daily operation
            var existingDailyOperation =
                _dailyOperationalDocumentRepository
                    .Find(query)
                    .Where(o => o.Identity.Equals(request.Id)).FirstOrDefault();
            //Get[0] detail from existing daily operation
            var detail =
                existingDailyOperation
                    .DailyOperationMachineDetails
                    .OrderByDescending(e => e.DateTimeOperation)
                    .FirstOrDefault();
            //Compare if has status Entry or Finish
            if (detail.OperationStatus.Equals(DailyOperationMachineStatus.ONENTRY) ||
                detail.OperationStatus.Equals(DailyOperationMachineStatus.ONFINISH))
            {
                throw Validator.ErrorValidation(("Status", "Can't Change Shift, check your latest status"));
            }
            //Break datetime to match timezone
            var year = request.ChangeShiftDate.Year;
            var month = request.ChangeShiftDate.Month;
            var day = request.ChangeShiftDate.Day;
            var hour = request.ChangeShifTime.Hours;
            var minutes = request.ChangeShifTime.Minutes;
            var seconds = request.ChangeShifTime.Seconds;
            var dateTimeOperation =
                new DateTimeOffset(year, month, day, hour, minutes, seconds, new TimeSpan(+7, 0, 0));
            //Check laters status machine operation
            var statusUp = false;
            var statusDown = false;

            if (detail.OperationStatus.Equals(DailyOperationMachineStatus.ONSTOP))
            {
                statusDown = true;
            }
            else
            {
                statusUp = true;
            }
            //Add new operation / detail
            var newOperation =
                new DailyOperationLoomDetail(Guid.NewGuid(),
                                             request.ShiftId,
                                             request.OperatorId,
                                             dateTimeOperation,
                                             DailyOperationMachineStatus.ONCHANGESHIFT,
                                             statusUp,
                                             statusDown);

            existingDailyOperation.AddDailyOperationMachineDetail(newOperation);

            await _dailyOperationalDocumentRepository.Update(existingDailyOperation);
            _storage.Save();

            return existingDailyOperation;
        }
    }
}
