using Introspectus.Api.Interfaces;
using Introspectus.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Introspectus.Api.DTO;
using Introspectus.Api.Infrastructure.Enum;
using Introspectus.Api.Infrastructure.Extensions;

namespace Introspectus.Api.Services
{
    public class MobileSpeedCameraService : BaseService<MobileSpeedCameraService>, IMobileSpeedCameraService
    {
        private readonly IMobileSpeedCameraRepository _mobileSpeedCameraRepository;

        public MobileSpeedCameraService(IBaseDependenciesService<MobileSpeedCameraService> dependencies,
                                                    IMobileSpeedCameraRepository mobileSpeedCameraRepository) : base(dependencies)
        {
            _mobileSpeedCameraRepository = mobileSpeedCameraRepository;
        }
        public async Task<List<MobileSpeedCameraResponse>> SearchMobileSpeedCameraList(SearchMobileSpeedCameraRequest dtoModel) {

            var result = await _mobileSpeedCameraRepository.SearchMobileSpeedCamera();
            if (result == null || result.Count == 0)
            {
                return new List<MobileSpeedCameraResponse>(0);
            }

            if (dtoModel.OrderByField != null)
            {
                var fieldName = dtoModel.OrderByField.FieldName;
                var orderBy = dtoModel.OrderByField.OrderBy;
                if (fieldName.HasValue)
                {
                    if (fieldName == (int)EnumFieldName.Date)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Date).ToList();
                            else
                                result = result.OrderByDescending(x => x.Date).ToList();
                        }
                    }

                    if (fieldName == (int)EnumFieldName.TimeSiteInHours)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Timeatsiteinhours).ToList();
                            else
                                result = result.OrderByDescending(x => x.Timeatsiteinhours).ToList();
                        }
                    }

                    if (fieldName == (int)EnumFieldName.Description)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Description_of_site).ToList();
                            else
                                result = result.OrderByDescending(x => x.Description_of_site).ToList();
                        }
                    }
                    if (fieldName == (int)EnumFieldName.CameraLocation)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Camera_Location).ToList();
                            else
                                result = result.OrderByDescending(x => x.Camera_Location).ToList();
                        }
                    }
                    if (fieldName == (int)EnumFieldName.Street)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Street).ToList();
                            else
                                result = result.OrderByDescending(x => x.Street).ToList();
                        }
                    }
                    if (fieldName == (int)EnumFieldName.NumberChecked)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Number_Checked).ToList();
                            else
                                result = result.OrderByDescending(x => x.Number_Checked).ToList();
                        }
                    }
                    if (fieldName == (int)EnumFieldName.HighestSpeed)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Highest_Speed).ToList();
                            else
                                result = result.OrderByDescending(x => x.Highest_Speed).ToList();
                        }
                    }
                    if (fieldName == (int)EnumFieldName.AverageSpeed)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Average_Speed).ToList();
                            else
                                result = result.OrderByDescending(x => x.Average_Speed).ToList();
                        }
                    }
                    if (fieldName == (int)EnumFieldName.PostedSpeed)
                    {
                        if (orderBy.HasValue)
                        {
                            if (orderBy == (int)EnumOrderByType.ASC)
                                result = result.OrderBy(x => x.Posted_Speed).ToList();
                            else
                                result = result.OrderByDescending(x => x.Posted_Speed).ToList();
                        }
                    }
                }
            }

            if (dtoModel.FilterByField != null)
            {
                var fieldName = dtoModel.FilterByField.FieldName;
                var filterKeyword = dtoModel.FilterByField.FilterKeyword;
                if (fieldName.HasValue)
                {
                    if (fieldName == (int)EnumFieldName.Date)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Date == filterKeyword).ToList();

                    }

                    if (fieldName == (int)EnumFieldName.TimeSiteInHours)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Timeatsiteinhours == filterKeyword).ToList();
                    }

                    if (fieldName == (int)EnumFieldName.Description)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Description_of_site.Contains(filterKeyword)).ToList();
                    }
                    if (fieldName == (int)EnumFieldName.CameraLocation)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Camera_Location == filterKeyword).ToList();
                    }
                    if (fieldName == (int)EnumFieldName.Street)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Street.Contains(filterKeyword)).ToList();
                    }
                    if (fieldName == (int)EnumFieldName.NumberChecked)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Number_Checked == Convert.ToInt32(filterKeyword)).ToList();
                    }
                    if (fieldName == (int)EnumFieldName.HighestSpeed)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Highest_Speed == Convert.ToInt32(filterKeyword)).ToList();
                    }
                    if (fieldName == (int)EnumFieldName.AverageSpeed)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Average_Speed == Convert.ToInt32(filterKeyword)).ToList();
                    }
                    if (fieldName == (int)EnumFieldName.PostedSpeed)
                    {
                        if (filterKeyword.HasValue())
                            result = result.Where(x => x.Posted_Speed == Convert.ToInt32(filterKeyword)).ToList();
                    }
                }
            }
            result.ForEach(x =>
            {
                x.Date = DateTime.Parse(x.Date).ToString("MM/dd/yyyy");
            });
            return result;
        }

        public async Task<List<MobileSpeedCameraPostedSpeedResponse>> GetGroupPostedSpeed()
        {

            var result = await _mobileSpeedCameraRepository.SearchMobileSpeedCamera();
            if (result == null || result.Count == 0)
            {
                return new List<MobileSpeedCameraPostedSpeedResponse>(0);
            }
            var groupByRecord = result.GroupBy(x => x.Posted_Speed).Select(g => new MobileSpeedCameraPostedSpeedResponse
            { 
                Date = g.FirstOrDefault()?.Date,
                Timeatsiteinhours = g.FirstOrDefault()?.Timeatsiteinhours,
                Description_of_site = g.FirstOrDefault()?.Description_of_site,
                Camera_Location = g.FirstOrDefault()?.Camera_Location,
                Street = g.FirstOrDefault()?.Street,
                Number_Checked = g.FirstOrDefault().Number_Checked,
                Highest_Speed = g.FirstOrDefault().Highest_Speed,
                Average_Speed = g.FirstOrDefault().Average_Speed,
                Posted_Speed = g.FirstOrDefault().Posted_Speed,
                Count = g.Count()
            }).OrderBy(x=>Convert.ToInt32(x.Posted_Speed)).ToList();

            return groupByRecord;
        }

    }
}
