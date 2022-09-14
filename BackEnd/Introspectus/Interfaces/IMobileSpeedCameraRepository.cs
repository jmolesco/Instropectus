﻿using Introspectus.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Introspectus.Api.Interfaces
{
    public interface IMobileSpeedCameraRepository
    {
        Task<List<MobileSpeedCameraResponse>> SearchMobileSpeedCamera();
    }
}
