using Introspectus.Api.DTO;
using Introspectus.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Introspectus.Api.Interfaces
{
    public interface IMobileSpeedCameraService
    {
        Task<List<MobileSpeedCameraResponse>> SearchMobileSpeedCameraList(SearchMobileSpeedCameraRequest dtoModel);
        Task<List<MobileSpeedCameraPostedSpeedResponse>> GetGroupPostedSpeed();
    }
}
