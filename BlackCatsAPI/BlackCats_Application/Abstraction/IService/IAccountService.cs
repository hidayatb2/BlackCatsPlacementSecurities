﻿using BlackCats_Application.RRModels;
using BlackCats_Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IService;

public interface IAccountService
{
    Task<APIResponse<LoginResponse>> Login(LoginDto loginDto);
}
