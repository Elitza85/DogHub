﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Services.Data
{
    public interface ISearchesService
    {
        IEnumerable<T> GetAllColors<T>();
    }
}
